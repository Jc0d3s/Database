using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

public class ContactDetailsRepository
{
    private readonly AppDbContext _context;

    public ContactDetailsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ContactDetail>> GetAllAsync()
    {
        return await _context.ContactDetails.ToListAsync();
    }

    public async Task<ContactDetail> GetByIdAsync(int id)
    {
        return await _context.ContactDetails.FindAsync(id);
    }

    public async Task AddAsync(ContactDetail contactDetail)
    {
        await _context.ContactDetails.AddAsync(contactDetail);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ContactDetail contactDetail)
    {
        _context.ContactDetails.Update(contactDetail);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.ContactDetails.FindAsync(id);
        if (entity != null)
        {
            _context.ContactDetails.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
