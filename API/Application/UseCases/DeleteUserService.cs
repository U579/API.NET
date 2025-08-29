using Domain.Repositories;

namespace Application.UseCases
{
    public class DeleteUserService(IUserRepository repository)
    /// <summary>
    /// Service responsible for deleting a user by their unique identifier.
    /// </summary>
    /// <remarks>
    /// This service interacts with the <see cref="IUserRepository"/> to retrieve and delete a user.
    /// If the user is not found, a <see cref="KeyNotFoundException"/> is thrown.
    /// </remarks>
    /// <param name="id">The unique identifier of the user to delete.</param>
    /// <exception cref="KeyNotFoundException">Thrown when the user with the specified ID does not exist.</exception>
    {
        private readonly IUserRepository _repository = repository;

        public async Task ExecuteAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Usuario no encontrado.");
            await _repository.DeleteAsync(id);
        }
    }
}
