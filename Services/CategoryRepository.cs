using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MenuGraph.Data;
using MenuGraph.Models;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategoriesAsync();
    Task<Category> GetCategoryAsync(Guid id);
    Task<Category> CreateCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Guid id, Category category);
    Task<bool> DeleteCategoryAsync(Guid id);
}

public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CategoryRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        var categories = await _context.Categories.ToListAsync();
        return _mapper.Map<List<Category>>(categories);
    }

    public async Task<Category> GetCategoryAsync(Guid id)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category == null)
        {
            return null;
        }

        return category;
    }


    public async Task<Category> CreateCategoryAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category> UpdateCategoryAsync(Guid id, Category category)
    {
        var existingCategory = await _context.Categories.FindAsync(id);
        if (existingCategory == null)
        {
            throw new ArgumentException($"Category with ID {id} not found.");
        }

        _mapper.Map(category, existingCategory);

        await _context.SaveChangesAsync();
        return existingCategory;
    }

    public async Task<bool> DeleteCategoryAsync(Guid id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return false;
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }
}
