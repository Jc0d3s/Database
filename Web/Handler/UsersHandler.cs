using Web.Models;

namespace Web.Handler
{
    public class UsersHandler
    {
        public interface IUserHandler
        {
            Task<IEnumerable<User>> GetAllUsersAsync();
            Task<User> GetUserByIdAsync(int id);
            Task AddUserAsync(User user);
            Task UpdateUserAsync(User user);
            Task DeleteUserAsync(int id);
        }

        public class UserHandler : IUserHandler
        {
            private readonly UserRepository _repository;

            public UserHandler(UserRepository repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<User>> GetAllUsersAsync()
            {
                return await _repository.GetAllAsync();
            }

            public async Task<User> GetUserByIdAsync(int id)
            {
                var user = await _repository.GetByIdAsync(id);
                if (user == null)
                {
                    throw new KeyNotFoundException("User not found.");
                }
                return user;
            }

            public async Task AddUserAsync(User user)
            {
                user.CreatedDate = DateTime.UtcNow;
                await _repository.AddAsync(user);
            }

            public async Task UpdateUserAsync(User user)
            {
                var existingUser = await _repository.GetByIdAsync(user.Id);
                if (existingUser == null)
                {
                    throw new KeyNotFoundException("User not found.");
                }
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                await _repository.UpdateAsync(existingUser);
            }

            public async Task DeleteUserAsync(int id)
            {
                var existingUser = await _repository.GetByIdAsync(id);
                if (existingUser == null)
                {
                    throw new KeyNotFoundException("User not found.");
                }
                await _repository.DeleteAsync(id);
            }
        }

    }
}
