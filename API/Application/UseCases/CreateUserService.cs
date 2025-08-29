using Domain.Entities;
using Domain.Repositories;


namespace Application.UseCases
{
    public class CreateUserService(IUserRepository repository)
    {
        private readonly IUserRepository _repository = repository;
        /// <summary>
        /// Asynchronously executes the operation to add a new user to the repository.
        /// </summary>
        /// <param name="user">The <see cref="User"/> entity to be added.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task ExecuteAsync(User user)
        {
            await _repository.AddAsync(user);
        }
    }
}
