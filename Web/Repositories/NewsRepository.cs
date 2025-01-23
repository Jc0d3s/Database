using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

public class NewsRepository
{
    private readonly AppDbContext _context;

    public NewsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<News>> GetAllAsync()
    {
        return await _context.News.ToListAsync();
    }

    public async Task<News> GetByIdAsync(int id)
    {
        return await _context.News.FindAsync(id);
    }

    public async Task AddAsync(News news)
    {
        await _context.News.AddAsync(news);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(News news)
    {
        _context.News.Update(news);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.News.FindAsync(id);
        if (entity != null)
        {
            _context.News.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}