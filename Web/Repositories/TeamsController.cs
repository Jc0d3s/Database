using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

public class TeamRepository
{
    private readonly AppDbContext _context;

    public TeamRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Team>> GetAllAsync()
    {
        return await _context.Teams.ToListAsync();
    }

    public async Task<Team> GetByIdAsync(int id)
    {
        return await _context.Teams.FindAsync(id);
    }

    public async Task AddAsync(Team team)
    {
        await _context.Teams.AddAsync(team);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Team team)
    {
        _context.Teams.Update(team);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Teams.FindAsync(id);
        if (entity != null)
        {
            _context.Teams.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
