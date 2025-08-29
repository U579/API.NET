using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository
    /// <summary>
    /// Defines the contract for user repository operations.
    /// </summary>
    /// <remarks>
    /// Provides asynchronous methods for retrieving, adding, updating, and deleting <see cref="User"/> entities.
    /// </remarks>
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
    }
}
