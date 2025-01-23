using Web.Models;

namespace Web.Handler
{
    public class NewsHandler
    {
        public interface INewsHandler
        {
            Task<IEnumerable<News>> GetAllNewsAsync();
            Task<News> GetNewsByIdAsync(int id);
            Task AddNewsAsync(News news);
            Task UpdateNewsAsync(News news);
            Task DeleteNewsAsync(int id);
        }

        public class NewsHandler : INewsHandler
        {
            private readonly NewsRepository _repository;

            public NewsHandler(NewsRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<News>> GetAllNewsAsync()
            {
                return await _repository.GetAllAsync();
            }

            public async Task<News> GetNewsByIdAsync(int id)
            {
                var news = await _repository.GetByIdAsync(id);
                if (news == null)
                {
                    throw new KeyNotFoundException("News not found.");
                }
                return news;
            }

            public async Task AddNewsAsync(News news)
            {
                news.CreatedDate = DateTime.UtcNow;
                await _repository.AddAsync(news);
            }

            public async Task UpdateNewsAsync(News news)
            {
                var existingNews = await _repository.GetByIdAsync(news.Id);
                if (existingNews == null)
                {
                    throw new KeyNotFoundException("News not found.");
                }
                existingNews.Title = news.Title;
                existingNews.Description = news.Description;
                existingNews.UpdatedDate = DateTime.UtcNow;
                await _repository.UpdateAsync(existingNews);
            }

            public async Task DeleteNewsAsync(int id)
            {
                var existingNews = await _repository.GetByIdAsync(id);
                if (existingNews == null)
                {
                    throw new KeyNotFoundException("News not found.");
                }
                await _repository.DeleteAsync(id);
            }
        }

    }
}
