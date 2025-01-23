using Microsoft.EntityFrameworkCore;
using Web.Models;  // Make sure to use the correct namespace where your models like User, News, etc. are defined

namespace Web.Data // The namespace where your DbContext is located
{
    public class AppDbContext : DbContext
    {
        // Constructor to pass the DbContextOptions to the base class.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

       
        public DbSet<User> Users { get; set; }  
        public DbSet<News> News { get; set; }    
        public DbSet<Team> Teams { get; set; }   // Assuming 'Team' class is located in the Web.Models namespace
        public DbSet<Testimonial> Testimonials { get; set; } // Assuming 'Testimonial' class is located in the Web.Models namespace
        public DbSet<ContactDetail> ContactDetails { get; set; } // Assuming 'ContactDetail' class is located in the Web.Models namespace
        public DbSet<Logo> Logos { get; set; }  // Assuming 'Logo' class is located in the Web.Models namespace
        public DbSet<Navbar> Navbars { get; set; } // Assuming 'Navbar' class is located in the Web.Models namespace
        public DbSet<Menu> Menus { get; set; } // Assuming 'Menu' class is located in the Web.Models namespace
        public DbSet<HeaderSection> HeaderSections { get; set; } // Assuming 'HeaderSection' class is located in the Web.Models namespace
        public DbSet<Service> Services { get; set; } // Assuming 'Service' class is located in the Web.Models namespace
    }
}
