using AutoMapper;
using MenuGraph.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ISectionRepository
{
    Task<List<Section>> GetSectionsAsync();
    Task<Section> GetSectionAsync(Guid id);
    Task<List<Section>> GetSectionsByCategoryIdAsync(Guid categoryId);
    Task<Section> CreateSectionAsync(Section section);
    Task<Section> UpdateSectionAsync(Guid id, Section section);
    Task<bool> DeleteSectionAsync(Guid id);
    Task<bool> DeleteSectionsByCategoryIdAsync(Guid categoryId);

    Task<bool> DeleteItemsBySectionIdAsync(Guid sectionId);
}

public class SectionRepository : ISectionRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public SectionRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Section>> GetSectionsAsync()
    {
        var sections = await _context.Sections.ToListAsync();
        return _mapper.Map<List<Section>>(sections);
    }

    public async Task<Section> GetSectionAsync(Guid id)
    {
        var section = await _context.Sections.FindAsync(id);
        return section;
    }

    public async Task<List<Section>> GetSectionsByCategoryIdAsync(Guid categoryId)
    {
        var sections = await _context.Sections
            .Include(s => s.Category)
            .Include(s => s.Items)
            .Where(s => s.CategoryId == categoryId)
            .ToListAsync();
    
        return sections;
    }


    public async Task<Section> CreateSectionAsync(Section section)
    {
        _context.Sections.Add(section);
        await _context.SaveChangesAsync();
        return section;
    }

    public async Task<Section> UpdateSectionAsync(Guid id, Section section)
    {
        var existingSection = await _context.Sections.FindAsync(id);
        if (existingSection == null)
        {
            throw new ArgumentException($"Section with ID {id} not found.");
        }

        _mapper.Map(section, existingSection);

        await _context.SaveChangesAsync();
        return existingSection;
    }

    public async Task<bool> DeleteSectionAsync(Guid id)
    {
        var section = await _context.Sections.FindAsync(id);
        if (section == null)
        {
            return false;
        }

        _context.Sections.Remove(section);
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
    public async Task<bool> DeleteSectionsByCategoryIdAsync(Guid categoryId)
    {
        var sections = await _context.Sections.Where(s => s.CategoryId == categoryId).ToListAsync();
        _context.Sections.RemoveRange(sections);
        await _context.SaveChangesAsync();
        return true;
    }



}
