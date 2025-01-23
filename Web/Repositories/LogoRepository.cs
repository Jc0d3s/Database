using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

public class LogoRepository
{
    private readonly AppDbContext _context;

    public LogoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Logo>> GetAllAsync()
    {
        return await _context.Logos.ToListAsync();
    }

    public async Task<Logo> GetByIdAsync(int id)
    {
        return await _context.Logos.FindAsync(id);
    }

    public async Task AddAsync(Logo logo)
    {
        await _context.Logos.AddAsync(logo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Logo logo)
    {
        _context.Logos.Update(logo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Logos.FindAsync(id);
        if (entity != null)
        {
            _context.Logos.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
