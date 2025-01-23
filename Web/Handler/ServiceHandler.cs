using Web.Models;

namespace Web.Handler
{
    public class ServiceHandler
    {
        public interface IServiceHandler
        {
            Task<IEnumerable<Service>> GetAllServicesAsync();
            Task<Service> GetServiceByIdAsync(int id);
            Task AddServiceAsync(Service service);
            Task UpdateServiceAsync(Service service);
            Task DeleteServiceAsync(int id);
        }

        public class ServiceHandler : IServiceHandler
        {
            private readonly ServiceRepository _repository;

            public ServiceHandler(ServiceRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Service>> GetAllServicesAsync()
            {
                return await _repository.GetAllAsync();
            }

            public async Task<Service> GetServiceByIdAsync(int id)
            {
                var service = await _repository.GetByIdAsync(id);
                if (service == null)
                {
                    throw new KeyNotFoundException("Service not found.");
                }
                return service;
            }

            public async Task AddServiceAsync(Service service)
            {
                service.CreatedDate = DateTime.UtcNow;
                await _repository.AddAsync(service);
            }

            public async Task UpdateServiceAsync(Service service)
            {
                var existingService = await _repository.GetByIdAsync(service.Id);
                if (existingService == null)
                {
                    throw new KeyNotFoundException("Service not found.");
                }
                existingService.Name = service.Name;
                existingService.Description = service.Description;
                await _repository.UpdateAsync(existingService);
            }

            public async Task DeleteServiceAsync(int id)
            {
                var existingService = await _repository.GetByIdAsync(id);
                if (existingService == null)
                {
                    throw new KeyNotFoundException("Service not found.");
                }
                await _repository.DeleteAsync(id);
            }
        }

    }
}
