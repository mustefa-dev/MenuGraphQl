using MenuGraph.Models;

namespace MenuGraph.GraphQL
{
    public class CategoryMutation
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMutation(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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
            
            return await _categoryRepository.UpdateCategoryAsync(id, existingCategory);
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            return await _categoryRepository.DeleteCategoryAsync(id);
        }
    }
}