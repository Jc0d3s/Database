using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

public class CombinedRepository
{
    private readonly AppDbContext _context;

    public CombinedRepository(AppDbContext context)
    {
        _context = context;
    }

    // ContactDetails Methods
    public async Task<IEnumerable<ContactDetail>> GetAllContactDetailsAsync()
    {
        return await _context.ContactDetails.ToListAsync();
    }

    public async Task<ContactDetail> GetContactDetailByIdAsync(int id)
    {
        return await _context.ContactDetails.FindAsync(id);
    }

    public async Task AddContactDetailAsync(ContactDetail contactDetail)
    {
        await _context.ContactDetails.AddAsync(contactDetail);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateContactDetailAsync(ContactDetail contactDetail)
    {
        _context.ContactDetails.Update(contactDetail);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteContactDetailAsync(int id)
    {
        var entity = await _context.ContactDetails.FindAsync(id);
        if (entity != null)
        {
            _context.ContactDetails.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    // HeaderSection Methods
    public async Task<IEnumerable<HeaderSection>> GetAllHeaderSectionsAsync()
    {
        return await _context.HeaderSections.ToListAsync();
    }

    public async Task<HeaderSection> GetHeaderSectionByIdAsync(int id)
    {
        return await _context.HeaderSections.FindAsync(id);
    }

    public async Task AddHeaderSectionAsync(HeaderSection headerSection)
    {
        await _context.HeaderSections.AddAsync(headerSection);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateHeaderSectionAsync(HeaderSection headerSection)
    {
        _context.HeaderSections.Update(headerSection);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHeaderSectionAsync(int id)
    {
        var entity = await _context.HeaderSections.FindAsync(id);
        if (entity != null)
        {
            _context.HeaderSections.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    // Logo Methods
    public async Task<IEnumerable<Logo>> GetAllLogosAsync()
    {
        return await _context.Logos.ToListAsync();
    }

    public async Task<Logo> GetLogoByIdAsync(int id)
    {
        return await _context.Logos.FindAsync(id);
    }

    public async Task AddLogoAsync(Logo logo)
    {
        await _context.Logos.AddAsync(logo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateLogoAsync(Logo logo)
    {
        _context.Logos.Update(logo);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteLogoAsync(int id)
    {
        var entity = await _context.Logos.FindAsync(id);
        if (entity != null)
        {
            _context.Logos.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    // Menu Methods
    public async Task<IEnumerable<Menu>> GetAllMenusAsync()
    {
        return await _context.Menus.ToListAsync();
    }

    public async Task<Menu> GetMenuByIdAsync(int id)
    {
        return await _context.Menus.FindAsync(id);
    }

    public async Task AddMenuAsync(Menu menu)
    {
        await _context.Menus.AddAsync(menu);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMenuAsync(Menu menu)
    {
        _context.Menus.Update(menu);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMenuAsync(int id)
    {
        var entity = await _context.Menus.FindAsync(id);
        if (entity != null)
        {
            _context.Menus.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    // Navbar Methods
    public async Task<IEnumerable<Navbar>> GetAllNavbarsAsync()
    {
        return await _context.Navbars.ToListAsync();
    }

    public async Task<Navbar> GetNavbarByIdAsync(int id)
    {
        return await _context.Navbars.FindAsync(id);
    }

    public async Task AddNavbarAsync(Navbar navbar)
    {
        await _context.Navbars.AddAsync(navbar);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateNavbarAsync(Navbar navbar)
    {
        _context.Navbars.Update(navbar);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteNavbarAsync(int id)
    {
        var entity = await _context.Navbars.FindAsync(id);
        if (entity != null)
        {
            _context.Navbars.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    // News Methods
    public async Task<IEnumerable<News>> GetAllNewsAsync()
    {
        return await _context.News.ToListAsync();
    }

    public async Task<News> GetNewsByIdAsync(int id)
    {
        return await _context.News.FindAsync(id);
    }

    public async Task AddNewsAsync(News news)
    {
        await _context.News.AddAsync(news);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateNewsAsync(News news)
    {
        _context.News.Update(news);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteNewsAsync(int id)
    {
        var entity = await _context.News.FindAsync(id);
        if (entity != null)
        {
            _context.News.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    // Service Methods
    public async Task<IEnumerable<Service>> GetAllServicesAsync()
    {
        return await _context.Services.ToListAsync();
    }

    public async Task<Service> GetServiceByIdAsync(int id)
    {
        return await _context.Services.FindAsync(id);
    }

    public async Task AddServiceAsync(Service service)
    {
        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateServiceAsync(Service service)
    {
        _context.Services.Update(service);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteServiceAsync(int id)
    {
        var entity = await _context.Services.FindAsync(id);
        if (entity != null)
        {
            _context.Services.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    // Team Methods
    public async Task<IEnumerable<Team>> GetAllTeamsAsync()
    {
        return await _context.Teams.ToListAsync();
    }

    public async Task<Team> GetTeamByIdAsync(int id)
    {
        return await _context.Teams.FindAsync(id);
    }

    public async Task AddTeamAsync(Team team)
    {
        await _context.Teams.AddAsync(team);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTeamAsync(Team team)
    {
        _context.Teams.Update(team);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTeamAsync(int id)
    {
        var entity = await _context.Teams.FindAsync(id);
        if (entity != null)
        {
            _context.Teams.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    // Testimonial Methods
    public async Task<IEnumerable<Testimonial>> GetAllTestimonialsAsync()
    {
        return await _context.Testimonials.ToListAsync();
    }

    public async Task<Testimonial> GetTestimonialByIdAsync(int id)
    {
        return await _context.Testimonials.FindAsync(id);
    }

    public async Task AddTestimonialAsync(Testimonial testimonial)
    {
        await _context.Testimonials.AddAsync(testimonial);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTestimonialAsync(Testimonial testimonial)
    {
        _context.Testimonials.Update(testimonial);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTestimonialAsync(int id)
    {
        var entity = await _context.Testimonials.FindAsync(id);
        if (entity != null)
        {
            _context.Testimonials.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    // User Methods
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        var entity = await _context.Users.FindAsync(id);
        if (entity != null)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
