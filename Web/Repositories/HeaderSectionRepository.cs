using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

public class HeaderSectionRepository
{
    private readonly AppDbContext _context;

    public HeaderSectionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<HeaderSection>> GetAllAsync()
    {
        return await _context.HeaderSections.ToListAsync();
    }

    public async Task<HeaderSection> GetByIdAsync(int id)
    {
        return await _context.HeaderSections.FindAsync(id);
    }

    public async Task AddAsync(HeaderSection headerSection)
    {
        await _context.HeaderSections.AddAsync(headerSection);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(HeaderSection headerSection)
    {
        _context.HeaderSections.Update(headerSection);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.HeaderSections.FindAsync(id);
        if (entity != null)
        {
            _context.HeaderSections.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}