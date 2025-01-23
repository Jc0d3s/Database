using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

public class ServiceRepository
{
    private readonly AppDbContext _context;

    public ServiceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Service>> GetAllAsync()
    {
        return await _context.Services.ToListAsync();
    }

    public async Task<Service> GetByIdAsync(int id)
    {
        return await _context.Services.FindAsync(id);
    }

    public async Task AddAsync(Service service)
    {
        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Service service)
    {
        _context.Services.Update(service);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Services.FindAsync(id);
        if (entity != null)
        {
            _context.Services.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}