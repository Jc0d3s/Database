using Web.Data;
using Web.Models;

public class MenuRepository
{
    private readonly AppDbContext _context;

    public MenuRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Menu>> GetAllAsync()
    {
        return await _context.Menus.ToListAsync();
    }

    public async Task<Menu> GetByIdAsync(int id)
    {
        return await _context.Menus.FindAsync(id);
    }

    public async Task AddAsync(Menu menu)
    {
        await _context.Menus.AddAsync(menu);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Menu menu)
    {
        _context.Menus.Update(menu);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Menus.FindAsync(id);
        if (entity != null)
        {
            _context.Menus.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}