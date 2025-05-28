using PoliceStation.Models;

namespace PoliceStation.Services
{
    public interface IUserService
    {
        Task<User?> ValidateUserAsync(string username, string password);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(User user);
        Task<User?> GetUserByIdAsync(int id);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}