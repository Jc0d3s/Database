using Web.Models;

namespace Web.Handler
{
    public class HeaderSectionHandler
    {
        public interface IHeaderSectionHandler
        {
            Task<IEnumerable<HeaderSection>> GetAllHeaderSectionsAsync();
            Task<HeaderSection> GetHeaderSectionByIdAsync(int id);
            Task AddHeaderSectionAsync(HeaderSection headerSection);
            Task UpdateHeaderSectionAsync(HeaderSection headerSection);
            Task DeleteHeaderSectionAsync(int id);
        }

        public class HeaderSectionHandler : IHeaderSectionHandler
        {
            private readonly HeaderSectionRepository _repository;

            public HeaderSectionHandler(HeaderSectionRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<HeaderSection>> GetAllHeaderSectionsAsync()
            {
                return await _repository.GetAllAsync();
            }

            public async Task<HeaderSection> GetHeaderSectionByIdAsync(int id)
            {
                var headerSection = await _repository.GetByIdAsync(id);
                if (headerSection == null)
                {
                    throw new KeyNotFoundException("Header section not found.");
                }
                return headerSection;
            }

            public async Task AddHeaderSectionAsync(HeaderSection headerSection)
            {
                headerSection.CreatedDate = DateTime.UtcNow;
                await _repository.AddAsync(headerSection);
            }

            public async Task UpdateHeaderSectionAsync(HeaderSection headerSection)
            {
                var existingHeader = await _repository.GetByIdAsync(headerSection.OrderNumber);
                if (existingHeader == null)
                {
                    throw new KeyNotFoundException("Header section not found.");
                }
                existingHeader.Title = headerSection.Title;
                existingHeader.Description = headerSection.Description;
                await _repository.UpdateAsync(existingHeader);
            }

            public async Task DeleteHeaderSectionAsync(int id)
            {
                var existingHeader = await _repository.GetByIdAsync(id);
                if (existingHeader == null)
                {
                    throw new KeyNotFoundException("Header section not found.");
                }
                await _repository.DeleteAsync(id);
            }
        }
    }
}
