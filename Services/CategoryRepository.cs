using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MenuGraph.Data;

public interface ICategoryRepository
{
    Task<List<Category>> GetCategoriesAsync();
    Task<Category> GetCategoryAsync(Guid id);
    Task<Category> CreateCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Guid id, Category category);
    Task<bool> DeleteCategoryAsync(Guid id);
    Task<bool> DeleteSectionsByCategoryIdAsync(Guid categoryId);
    Task<bool> DeleteItemsBySectionIdAsync(Guid sectionId);
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

    public async Task<bool> DeleteSectionsByCategoryIdAsync(Guid categoryId)
    {
        var sections = await _context.Sections.Where(s => s.CategoryId == categoryId).ToListAsync();
        if (sections == null || sections.Count == 0)
        {
            return false;
        }

        _context.Sections.RemoveRange(sections);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteItemsBySectionIdAsync(Guid sectionId)
    {
        var items = await _context.Items.Where(i => i.SectionId == sectionId).ToListAsync();
        if (items == null || items.Count == 0)
        {
            return false;
        }

        _context.Items.RemoveRange(items);
        await _context.SaveChangesAsync();
        return true;
    }
}
