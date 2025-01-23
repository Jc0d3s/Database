using Web.Models;

namespace Web.Handler
{
    public class LogoHandler
    {
        public interface ILogoHandler
        {
            Task<IEnumerable<Logo>> GetAllLogosAsync();
            Task<Logo> GetLogoByIdAsync(int id);
            Task AddLogoAsync(Logo logo);
            Task UpdateLogoAsync(Logo logo);
            Task DeleteLogoAsync(int id);
        }

        public class LogoHandler : ILogoHandler
        {
            private readonly LogoRepository _repository;

            public LogoHandler(LogoRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Logo>> GetAllLogosAsync()
            {
                return await _repository.GetAllAsync();
            }

            public async Task<Logo> GetLogoByIdAsync(int id)
            {
                var logo = await _repository.GetByIdAsync(id);
                if (logo == null)
                {
                    throw new KeyNotFoundException("Logo not found.");
                }
                return logo;
            }

            public async Task AddLogoAsync(Logo logo)
            {
                logo.CreatedDate = DateTime.UtcNow;
                await _repository.AddAsync(logo);
            }

            public async Task UpdateLogoAsync(Logo logo)
            {
                var existingLogo = await _repository.GetByIdAsync(logo.Id);
                if (existingLogo == null)
                {
                    throw new KeyNotFoundException("Logo not found.");
                }
                existingLogo.Name = logo.Name;
                await _repository.UpdateAsync(existingLogo);
            }

            public async Task DeleteLogoAsync(int id)
            {
                var existingLogo = await _repository.GetByIdAsync(id);
                if (existingLogo == null)
                {
                    throw new KeyNotFoundException("Logo not found.");
                }
                await _repository.DeleteAsync(id);
            }
        }

    }
}
