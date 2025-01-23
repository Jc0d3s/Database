using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

public class TestimonialRepository
{
    private readonly AppDbContext _context;

    public TestimonialRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Testimonial>> GetAllAsync()
    {
        return await _context.Testimonials.ToListAsync();
    }

    public async Task<Testimonial> GetByIdAsync(int id)
    {
        return await _context.Testimonials.FindAsync(id);
    }

    public async Task AddAsync(Testimonial testimonial)
    {
        await _context.Testimonials.AddAsync(testimonial);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Testimonial testimonial)
    {
        _context.Testimonials.Update(testimonial);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Testimonials.FindAsync(id);
        if (entity != null)
        {
            _context.Testimonials.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}

