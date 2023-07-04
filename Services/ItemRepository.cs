using AutoMapper;
using MenuGraph.Data;
using Microsoft.EntityFrameworkCore;

public interface IItemRepository
{
    Task<List<Item>> GetItemsAsync();
    Task<Item> GetItemAsync(Guid id);
    Task<List<Item>> GetItemsBySectionIdAsync(Guid sectionId);
    Task<Item> CreateItemAsync(Item item);
    Task<Item> UpdateItemAsync(Guid id, Item item);
    Task<bool> DeleteItemsByCategoryIdAsync(Guid categoryId);

    Task<bool> DeleteItemAsync(Guid id);
}

public class ItemRepository : IItemRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ItemRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Item>> GetItemsAsync()
    {
        var items = await _context.Items.ToListAsync();
        return _mapper.Map<List<Item>>(items);
    }

    public async Task<Item> GetItemAsync(Guid id)
    {
        var item = await _context.Items.FindAsync(id);
        return item;
    }

    public async Task<List<Item>> GetItemsBySectionIdAsync(Guid sectionId)
    {
        var items = await _context.Items.Where(i => i.SectionId == sectionId).ToListAsync();
        return _mapper.Map<List<Item>>(items);
    }

    public async Task<Item> CreateItemAsync(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<Item> UpdateItemAsync(Guid id, Item item)
    {
        var existingItem = await _context.Items.FindAsync(id);
        if (existingItem == null)
        {
            throw new ArgumentException($"Item with ID {id} not found.");
        }

        _mapper.Map(item, existingItem);

        await _context.SaveChangesAsync();
        return existingItem;
    }

    public async Task<bool> DeleteItemAsync(Guid id)
    {
        var item = await _context.Items.FindAsync(id);
        if (item == null)
        {
            return false;
        }

        _context.Items.Remove(item);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteItemsByCategoryIdAsync(Guid categoryId)
    {
        var sections = await _context.Sections.Where(s => s.CategoryId == categoryId).ToListAsync();
        var sectionIds = sections.Select(s => s.Id).ToList();

        var items = await _context.Items.Where(i => sectionIds.Contains(i.SectionId)).ToListAsync();
        _context.Items.RemoveRange(items);

        await _context.SaveChangesAsync();
        return true;
    }

}
