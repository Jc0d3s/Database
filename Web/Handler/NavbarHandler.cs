using Web.Models;

namespace Web.Handler
{
    public class NavbarHandler
    {
        public interface INavbarHandler
        {
            Task<IEnumerable<Navbar>> GetAllNavbarsAsync();
            Task<Navbar> GetNavbarByIdAsync(int id);
            Task AddNavbarAsync(Navbar navbar);
            Task UpdateNavbarAsync(Navbar navbar);
            Task DeleteNavbarAsync(int id);
        }

        public class NavbarHandler : INavbarHandler
        {
            private readonly NavbarRepository _repository;

            public NavbarHandler(NavbarRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Navbar>> GetAllNavbarsAsync()
            {
                return await _repository.GetAllAsync();
            }

            public async Task<Navbar> GetNavbarByIdAsync(int id)
            {
                var navbar = await _repository.GetByIdAsync(id);
                if (navbar == null)
                {
                    throw new KeyNotFoundException("Navbar not found.");
                }
                return navbar;
            }

            public async Task AddNavbarAsync(Navbar navbar)
            {
                navbar.CreatedAt = DateTime.UtcNow;
                await _repository.AddAsync(navbar);
            }

            public async Task UpdateNavbarAsync(Navbar navbar)
            {
                var existingNavbar = await _repository.GetByIdAsync(navbar.Id);
                if (existingNavbar == null)
                {
                    throw new KeyNotFoundException("Navbar not found.");
                }
                existingNavbar.Title = navbar.Title;
                existingNavbar.UpdatedAt = DateTime.UtcNow;
                await _repository.UpdateAsync(existingNavbar);
            }

            public async Task DeleteNavbarAsync(int id)
            {
                var existingNavbar = await _repository.GetByIdAsync(id);
                if (existingNavbar == null)
                {
                    throw new KeyNotFoundException("Navbar not found.");
                }
                await _repository.DeleteAsync(id);
            }
        }

    }
}
