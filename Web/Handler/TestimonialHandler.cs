using Web.Models;

namespace Web.Handler
{
    public class TestimonialHandler
    {
        public interface ITestimonialHandler
        {
            Task<IEnumerable<Testimonial>> GetAllTestimonialsAsync();
            Task<Testimonial> GetTestimonialByIdAsync(int id);
            Task AddTestimonialAsync(Testimonial testimonial);
            Task UpdateTestimonialAsync(Testimonial testimonial);
            Task DeleteTestimonialAsync(int id);
        }

        public class TestimonialHandler : ITestimonialHandler
        {
            private readonly TestimonialRepository _repository;

            public TestimonialHandler(TestimonialRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Testimonial>> GetAllTestimonialsAsync()
            {
                return await _repository.GetAllAsync();
            }

            public async Task<Testimonial> GetTestimonialByIdAsync(int id)
            {
                var testimonial = await _repository.GetByIdAsync(id);
                if (testimonial == null)
                {
                    throw new KeyNotFoundException("Testimonial not found.");
                }
                return testimonial;
            }

            public async Task AddTestimonialAsync(Testimonial testimonial)
            {
                testimonial.CreatedDate = DateTime.UtcNow;
                await _repository.AddAsync(testimonial);
            }

            public async Task UpdateTestimonialAsync(Testimonial testimonial)
            {
                var existingTestimonial = await _repository.GetByIdAsync(testimonial.Id);
                if (existingTestimonial == null)
                {
                    throw new KeyNotFoundException("Testimonial not found.");
                }
                existingTestimonial.Content = testimonial.Content;
                existingTestimonial.Author = testimonial.Author;
                await _repository.UpdateAsync(existingTestimonial);
            }

            public async Task DeleteTestimonialAsync(int id)
            {
                var existingTestimonial = await _repository.GetByIdAsync(id);
                if (existingTestimonial == null)
                {
                    throw new KeyNotFoundException("Testimonial not found.");
                }
                await _repository.DeleteAsync(id);
            }
        }

    }
}
