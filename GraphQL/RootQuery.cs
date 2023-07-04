using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MenuGraph.Data;

public class RootQuery
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ISectionRepository _sectionRepository;
    private readonly IItemRepository _itemRepository;

    public RootQuery(ICategoryRepository categoryRepository, ISectionRepository sectionRepository, IItemRepository itemRepository)
    {
        _categoryRepository = categoryRepository;
        _sectionRepository = sectionRepository;
        _itemRepository = itemRepository;
    }

    public async Task<List<Category>> GetCategories()
    {
        return await _categoryRepository.GetCategoriesAsync();
    }

    public async Task<Category> GetCategory(Guid id)
    {
        return await _categoryRepository.GetCategoryAsync(id);
    }

    public async Task<List<Section>> GetSectionsByCategoryId(Guid categoryId)
    {
        return await _sectionRepository.GetSectionsByCategoryIdAsync(categoryId);
    }

    public async Task<Section> GetSection(Guid id)
    {
        return await _sectionRepository.GetSectionAsync(id);
    }

    public async Task<List<Item>> GetItemsBySectionId(Guid sectionId)
    {
        return await _itemRepository.GetItemsBySectionIdAsync(sectionId);
    }

    public async Task<Item> GetItem(Guid id)
    {
        return await _itemRepository.GetItemAsync(id);
    }

    public async Task<List<Section>> GetAllSections()
    {
        return await _sectionRepository.GetSectionsAsync();
    }

    public async Task<List<Item>> GetAllItems()
    {
        return await _itemRepository.GetItemsAsync();
    }
}