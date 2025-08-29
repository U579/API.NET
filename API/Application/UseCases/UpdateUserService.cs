using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases
{
    public class UpdateUserService(IUserRepository repository)
    {
        private readonly IUserRepository _repository = repository;

        /// <summary>
        /// Updates an existing user's information asynchronously.
        /// Throws a <see cref="KeyNotFoundException"/> if the user is not found.
        /// </summary>
        /// <param name="user">The <see cref="User"/> object containing updated user information.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task ExecuteAsync(User user)
        {
            var existingUser = await _repository.GetByIdAsync(user.Id) ?? throw new KeyNotFoundException("Usuario no encontrado.");
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Phone = user.Phone;

            await _repository.UpdateAsync(existingUser);
        }
    }
}
