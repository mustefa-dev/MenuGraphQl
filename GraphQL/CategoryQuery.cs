using MenuGraph.Models;

public class CategoryQuery
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryQuery(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<Category>> GetCategories()
    {
        return await _categoryRepository.GetCategoriesAsync();
    }

    public async Task<Category?> GetCategory(Guid id)
    {
        return await _categoryRepository.GetCategoryAsync(id);
    }
}
