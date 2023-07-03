using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MenuGraph.Models;

public class Query
{
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

        public async Task<Task<Category>?> GetCategory(Guid id)
        {
            return Task.FromResult(await _categoryRepository.GetCategoryAsync(id));
        }
    }

}