using Web.Data;
using Web.Models;

public class NavbarRepository
{
    private readonly AppDbContext _context;

    public NavbarRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Navbar>> GetAllAsync()
    {
        return await _context.Navbars.ToListAsync();
    }

    public async Task<Navbar> GetByIdAsync(int id)
    {
        return await _context.Navbars.FindAsync(id);
    }

    public async Task AddAsync(Navbar navbar)
    {
        await _context.Navbars.AddAsync(navbar);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Navbar navbar)
    {
        _context.Navbars.Update(navbar);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Navbars.FindAsync(id);
        if (entity != null)
        {
            _context.Navbars.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}