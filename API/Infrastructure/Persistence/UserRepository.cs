using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Repository for managing user entities.
/// </summary>
namespace Infrastructure.Persistence
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository"/> class.
    /// </summary>
    /// <param name="context"></param>
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context"></param>
        private readonly AppDbContext _context = context;

        /// <summary>
        /// Gets all users asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _context.Users.ToListAsync();

        /// <summary>
        /// Gets a user by their ID asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User?> GetByIdAsync(Guid id) =>
            await _context.Users.FindAsync(id);

        /// <summary>
        /// Adds a new user asynchronously.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing user asynchronously.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a user asynchronously.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
