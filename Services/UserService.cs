using PoliceStation.Models;
using PoliceStation.Services;

namespace PoliceStation.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private static readonly List<User> _users = new(); // In-memory storage for demo
        private static int _nextId = 1;

        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
            
            // Add default admin user if none exists
            if (!_users.Any())
            {
                var adminUser = new User
                {
                    Id = _nextId++,
                    Username = "admin",
                    Email = "admin@police.gov",
                    FullName = "Chief Inspector",
                    Role = "Chief",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    StationId = 1
                };
                _users.Add(adminUser);
            }
        }

        public async Task<User?> ValidateUserAsync(string username, string password)
        {
            await Task.Delay(100); // Simulate async operation
            
            var user = _users.FirstOrDefault(u => 
                (u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) || 
                 u.Email.Equals(username, StringComparison.OrdinalIgnoreCase)) && 
                u.IsActive);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return user;
            }

            return null;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            await Task.Delay(50);
            return _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            await Task.Delay(50);
            return _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await Task.Delay(100);
            user.Id = _nextId++;
            user.CreatedAt = DateTime.UtcNow;
            _users.Add(user);
            return user;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            await Task.Delay(50);
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public async Task UpdateUserAsync(User user)
        {
            await Task.Delay(100);
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                var index = _users.IndexOf(existingUser);
                _users[index] = user;
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            await Task.Delay(100);
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.IsActive = false; // Soft delete
            }
        }
    }
}