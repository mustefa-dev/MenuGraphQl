
namespace MenuGraph.GraphQL;

public class RootMutation
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ISectionRepository _sectionRepository;
    private readonly IItemRepository _itemRepository;

    public RootMutation(ICategoryRepository categoryRepository, ISectionRepository sectionRepository, IItemRepository itemRepository)
    {
        _categoryRepository = categoryRepository;
        _sectionRepository = sectionRepository;
        _itemRepository = itemRepository;
    }

    public async Task<Category> CreateCategory(Category category)
    {
        return await _categoryRepository.CreateCategoryAsync(category);
    }

    public async Task<Category> UpdateCategory(Guid id, Category category)
    {
        var existingCategory = await _categoryRepository.GetCategoryAsync(id);
        if (existingCategory == null)
        {
            throw new ArgumentException($"Category with ID {id} not found.");
        }

        existingCategory.Name = category.Name; // Update the name field

        return await _categoryRepository.UpdateCategoryAsync(id, existingCategory);
    }

    public async Task<bool> DeleteCategory(Guid id)
    {
        return await _categoryRepository.DeleteCategoryAsync(id);
    }

    public async Task<Section> CreateSection(Section section)
    {
        return await _sectionRepository.CreateSectionAsync(section);
    }

    public async Task<Section> UpdateSection(Guid id, Section section)
    {
        var existingSection = await _sectionRepository.GetSectionAsync(id);
        if (existingSection == null)
        {
            throw new ArgumentException($"Section with ID {id} not found.");
        }

        existingSection.Name = section.Name; // Update the name field

        return await _sectionRepository.UpdateSectionAsync(id, existingSection);
    }

    public async Task<bool> DeleteSection(Guid id)
    {
        return await _sectionRepository.DeleteSectionAsync(id);
    }

    public async Task<Item> CreateItem(Item item)
    {
        return await _itemRepository.CreateItemAsync(item);
    }

    public async Task<Item> UpdateItem(Guid id, Item item)
    {
        var existingItem = await _itemRepository.GetItemAsync(id);
        if (existingItem == null)
        {
            throw new ArgumentException($"Item with ID {id} not found.");
        }

        existingItem.Name = item.Name; // Update the name field
        existingItem.Price = item.Price; // Update the price field

        return await _itemRepository.UpdateItemAsync(id, existingItem);
    }

    public async Task<bool> DeleteItem(Guid id)
    {
        return await _itemRepository.DeleteItemAsync(id);
    }
}