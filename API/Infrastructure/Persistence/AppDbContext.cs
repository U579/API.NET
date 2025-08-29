/// <summary>
/// Represents the application's database context, providing access to the database entities.
/// </summary>
/// <param name="options">The options to be used by the DbContext.</param>
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
    }
}
