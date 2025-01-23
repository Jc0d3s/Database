using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Data;
using Web.Models;

// Define a generic repository interface
public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}

// Implement the generic repository
public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}

[ApiController]
[Route("api/[controller]")]
public class MainController : ControllerBase
{
    private readonly IRepository<ContactDetail> _contactDetailsRepository;
    private readonly IRepository<HeaderSection> _headerSectionRepository;
    private readonly IRepository<Logo> _logoRepository;
    private readonly IRepository<Menu> _menuRepository;
    private readonly IRepository<Navbar> _navbarRepository;
    private readonly IRepository<News> _newsRepository;
    private readonly IRepository<Service> _serviceRepository;
    private readonly IRepository<Team> _teamRepository;
    private readonly IRepository<Testimonial> _testimonialRepository;
    private readonly IRepository<User> _userRepository;

    public MainController(
        IRepository<ContactDetail> contactDetailsRepository,
        IRepository<HeaderSection> headerSectionRepository,
        IRepository<Logo> logoRepository,
        IRepository<Menu> menuRepository,
        IRepository<Navbar> navbarRepository,
        IRepository<News> newsRepository,
        IRepository<Service> serviceRepository,
        IRepository<Team> teamRepository,
        IRepository<Testimonial> testimonialRepository,
        IRepository<User> userRepository)
    {
        _contactDetailsRepository = contactDetailsRepository;
        _headerSectionRepository = headerSectionRepository;
        _logoRepository = logoRepository;
        _menuRepository = menuRepository;
        _navbarRepository = navbarRepository;
        _newsRepository = newsRepository;
        _serviceRepository = serviceRepository;
        _teamRepository = teamRepository;
        _testimonialRepository = testimonialRepository;
        _userRepository = userRepository;
    }

    // ContactDetails endpoints
    [HttpGet("contactdetails")]
    public async Task<ActionResult<IEnumerable<ContactDetail>>> GetContactDetails()
    {
        return Ok(await _contactDetailsRepository.GetAllAsync());
    }

    [HttpGet("contactdetails/{id}")]
    public async Task<ActionResult<ContactDetail>> GetContactDetail(int id)
    {
        var contactDetail = await _contactDetailsRepository.GetByIdAsync(id);
        if (contactDetail == null)
        {
            return NotFound();
        }
        return Ok(contactDetail);
    }

    [HttpPost("contactdetails")]
    public async Task<ActionResult<ContactDetail>> CreateContactDetail(ContactDetail contactDetail)
    {
        await _contactDetailsRepository.AddAsync(contactDetail);
        return CreatedAtAction(nameof(GetContactDetail), new { id = contactDetail.Id }, contactDetail);
    }

    [HttpPut("contactdetails/{id}")]
    public async Task<IActionResult> UpdateContactDetail(int id, ContactDetail contactDetail)
    {
        if (id != contactDetail.Id)
        {
            return BadRequest();
        }

        await _contactDetailsRepository.UpdateAsync(contactDetail);
        return NoContent();
    }

    [HttpDelete("contactdetails/{id}")]
    public async Task<IActionResult> DeleteContactDetail(int id)
    {
        await _contactDetailsRepository.DeleteAsync(id);
        return NoContent();
    }

    // HeaderSections endpoints
    [HttpGet("headersections")]
    public async Task<ActionResult<IEnumerable<HeaderSection>>> GetHeaderSections()
    {
        return Ok(await _headerSectionRepository.GetAllAsync());
    }

    [HttpGet("headersections/{id}")]
    public async Task<ActionResult<HeaderSection>> GetHeaderSection(int id)
    {
        var headerSection = await _headerSectionRepository.GetByIdAsync(id);
        if (headerSection == null)
        {
            return NotFound();
        }
        return Ok(headerSection);
    }

    [HttpPost("headersections")]
    public async Task<ActionResult<HeaderSection>> CreateHeaderSection(HeaderSection headerSection)
    {
        await _headerSectionRepository.AddAsync(headerSection);
        return CreatedAtAction(nameof(GetHeaderSection), new { id = headerSection.OrderNumber }, headerSection);
    }

    [HttpPut("headersections/{id}")]
    public async Task<IActionResult> UpdateHeaderSection(int id, HeaderSection headerSection)
    {
        if (id != headerSection.OrderNumber)
        {
            return BadRequest();
        }

        await _headerSectionRepository.UpdateAsync(headerSection);
        return NoContent();
    }

    [HttpDelete("headersections/{id}")]
    public async Task<IActionResult> DeleteHeaderSection(int id)
    {
        await _headerSectionRepository.DeleteAsync(id);
        return NoContent();
    }

    // Logos endpoints
    [HttpGet("logos")]
    public async Task<ActionResult<IEnumerable<Logo>>> GetLogos()
    {
        return Ok(await _logoRepository.GetAllAsync());
    }

    [HttpGet("logos/{id}")]
    public async Task<ActionResult<Logo>> GetLogo(int id)
    {
        var logo = await _logoRepository.GetByIdAsync(id);
        if (logo == null)
        {
            return NotFound();
        }
        return Ok(logo);
    }

    [HttpPost("logos")]
    public async Task<ActionResult<Logo>> CreateLogo(Logo logo)
    {
        await _logoRepository.AddAsync(logo);
        return CreatedAtAction(nameof(GetLogo), new { id = logo.Id }, logo);
    }

    [HttpPut("logos/{id}")]
    public async Task<IActionResult> UpdateLogo(int id, Logo logo)
    {
        if (id != logo.Id)
        {
            return BadRequest();
        }

        await _logoRepository.UpdateAsync(logo);
        return NoContent();
    }

    [HttpDelete("logos/{id}")]
    public async Task<IActionResult> DeleteLogo(int id)
    {
        await _logoRepository.DeleteAsync(id);
        return NoContent();
    }

    // Menus endpoints
    [HttpGet("menus")]
    public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
    {
        return Ok(await _menuRepository.GetAllAsync());
    }

    [HttpGet("menus/{id}")]
    public async Task<ActionResult<Menu>> GetMenu(int id)
    {
        var menu = await _menuRepository.GetByIdAsync(id);
        if (menu == null)
        {
            return NotFound();
        }
        return Ok(menu);
    }

    [HttpPost("menus")]
    public async Task<ActionResult<Menu>> CreateMenu(Menu menu)
    {
        await _menuRepository.AddAsync(menu);
        return CreatedAtAction(nameof(GetMenu), new { id = menu.Id }, menu);
    }

    [HttpPut("menus/{id}")]
    public async Task<IActionResult> UpdateMenu(int id, Menu menu)
    {
        if (id != menu.Id)
        {
            return BadRequest();
        }

        await _menuRepository.UpdateAsync(menu);
        return NoContent();
    }

    [HttpDelete("menus/{id}")]
    public async Task<IActionResult> DeleteMenu(int id)
    {
        await _menuRepository.DeleteAsync(id);
        return NoContent();
    }

    // Navbars endpoints
    [HttpGet("navbars")]
    public async Task<ActionResult<IEnumerable<Navbar>>> GetNavbars()
    {
        return Ok(await _navbarRepository.GetAllAsync());
    }

    [HttpGet("navbars/{id}")]
    public async Task<ActionResult<Navbar>> GetNavbar(int id)
    {
        var navbar = await _navbarRepository.GetByIdAsync(id);
        if (navbar == null)
        {
            return NotFound();
        }
        return Ok(navbar);
    }

    [HttpPost("navbars")]
    public async Task<ActionResult<Navbar>> CreateNavbar(Navbar navbar)
    {
        await _navbarRepository.AddAsync(navbar);
        return CreatedAtAction(nameof(GetNavbar), new { id = navbar.Id }, navbar);
    }

    [HttpPut("navbars/{id}")]
    public async Task<IActionResult> UpdateNavbar(int id, Navbar navbar)
    {
        if (id != navbar.Id)
        {
            return BadRequest();
        }

        await _navbarRepository.UpdateAsync(navbar);
        return NoContent();
    }

    [HttpDelete("navbars/{id}")]
    public async Task<IActionResult> DeleteNavbar(int id)
    {
        await _navbarRepository.DeleteAsync(id);
        return NoContent();
    }

    // News endpoints
    [HttpGet("news")]
    public async Task<ActionResult<IEnumerable<News>>> GetNews()
    {
        return Ok(await _newsRepository.GetAllAsync());
    }

    [HttpGet("news/{id}")]
    public async Task<ActionResult<News>> GetNewsItem(int id)
    {
        var newsItem = await _newsRepository.GetByIdAsync(id);
        if (newsItem == null)
        {
            return NotFound();
        }
        return Ok(newsItem);
    }

    [HttpPost("news")]
    public async Task<ActionResult<News>> CreateNews(News news)
    {
        await _newsRepository.AddAsync(news);
        return CreatedAtAction(nameof(GetNewsItem), new { id = news.Id }, news);
    }

    [HttpPut("news/{id}")]
    public async Task<IActionResult> UpdateNews(int id, News news)
    {
        if (id != news.Id)
        {
            return BadRequest();
        }

        await _newsRepository.UpdateAsync(news);
        return NoContent();
    }

    [HttpDelete("news/{id}")]
    public async Task<IActionResult> DeleteNews(int id)
    {
        await _newsRepository.DeleteAsync(id);
        return NoContent();
    }

    // Services endpoints
    [HttpGet("services")]
    public async Task<ActionResult<IEnumerable<Service>>> GetServices()
    {
        return Ok(await _serviceRepository.GetAllAsync());
    }

    [HttpGet("services/{id}")]
    public async Task<ActionResult<Service>> GetService(int id)
    {
        var service = await _serviceRepository.GetByIdAsync(id);
        if (service == null)
        {
            return NotFound();
        }
        return Ok(service);
    }

    [HttpPost("services")]
    public async Task<ActionResult<Service>> CreateService(Service service)
    {
        await _serviceRepository.AddAsync(service);
        return CreatedAtAction(nameof(GetService), new { id = service.Id }, service);
    }

    [HttpPut("services/{id}")]
    public async Task<IActionResult> UpdateService(int id, Service service)
    {
        if (id != service.Id)
        {
            return BadRequest();
        }

        await _serviceRepository.UpdateAsync(service);
        return NoContent();
    }

    [HttpDelete("services/{id}")]
    public async Task<IActionResult> DeleteService(int id)
    {
        await _serviceRepository.DeleteAsync(id);
        return NoContent();
    }

    // Teams endpoints
    [HttpGet("teams")]
    public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
    {
        return Ok(await _teamRepository.GetAllAsync());
    }

    [HttpGet("teams/{id}")]
    public async Task<ActionResult<Team>> GetTeamMember(int id)
    {
        var teamMember = await _teamRepository.GetByIdAsync(id);
        if (teamMember == null)
        {
            return NotFound();
        }
        return Ok(teamMember);
    }

    [HttpPost("teams")]
    public async Task<ActionResult<Team>> CreateTeamMember(Team team)
    {
        await _teamRepository.AddAsync(team);
        return CreatedAtAction(nameof(GetTeamMember), new { id = team.Id }, team);
    }

    [HttpPut("teams/{id}")]
    public async Task<IActionResult> UpdateTeamMember(int id, Team team)
    {
        if (id != team.Id)
        {
            return BadRequest();
        }

        await _teamRepository.UpdateAsync(team);
        return NoContent();
    }

    [HttpDelete("teams/{id}")]
    public async Task<IActionResult> DeleteTeamMember(int id)
    {
        await _teamRepository.DeleteAsync(id);
        return NoContent();
    }

    // Testimonials endpoints
    [HttpGet("testimonials")]
    public async Task<ActionResult<IEnumerable<Testimonial>>> GetTestimonials()
    {
        return Ok(await _testimonialRepository.GetAllAsync());
    }

    [HttpGet("testimonials/{id}")]
    public async Task<ActionResult<Testimonial>> GetTestimonial(int id)
    {
        var testimonial = await _testimonialRepository.GetByIdAsync(id);
        if (testimonial == null)
        {
            return NotFound();
        }
        return Ok(testimonial);
    }

    [HttpPost("testimonials")]
    public async Task<ActionResult<Testimonial>> CreateTestimonial(Testimonial testimonial)
    {
        await _testimonialRepository.AddAsync(testimonial);
        return CreatedAtAction(nameof(GetTestimonial), new { id = testimonial.Id }, testimonial);
    }

    [HttpPut("testimonials/{id}")]
    public async Task<IActionResult> UpdateTestimonial(int id, Testimonial testimonial)
    {
        if (id != testimonial.Id)
        {
            return BadRequest();
        }

        await _testimonialRepository.UpdateAsync(testimonial);
        return NoContent();
    }

    [HttpDelete("testimonials/{id}")]
    public async Task<IActionResult> DeleteTestimonial(int id)
    {
        await _testimonialRepository.DeleteAsync(id);
        return NoContent();
    }

    // Users endpoints
    [HttpGet("users")]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return Ok(await _userRepository.GetAllAsync());
    }

    [HttpGet("users/{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost("users")]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        await _userRepository.AddAsync(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("users/{id}")]
    public async Task<IActionResult> UpdateUser(int id, User user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }

        await _userRepository.UpdateAsync(user);
        return NoContent();
    }

    [HttpDelete("users/{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _userRepository.DeleteAsync(id);
        return NoContent();
    }
}
