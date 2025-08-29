using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases
{
    public class GetUserService(IUserRepository repository)
    {
        private readonly IUserRepository _repository = repository;

        /// <summary>
        /// Asynchronously retrieves all <see cref="User"/> entities from the repository.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an <see cref="IEnumerable{User}"/>
        /// with all users.
        /// </returns>
        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _repository.GetAllAsync();

        public async Task<User?> GetByIdAsync(Guid id) =>
            await _repository.GetByIdAsync(id);
    }
}
