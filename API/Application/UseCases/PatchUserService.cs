using Domain.Entities;
using Domain.Repositories;

namespace Application.UseCases
{
    public class PatchUserService(IUserRepository repository)
    {
        private readonly IUserRepository _repository = repository;

        /// <summary>
        /// Asynchronously updates specified fields of a user entity identified by the given <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The unique identifier of the user to update.</param>
        /// <param name="updates">
        /// A dictionary containing the fields to update and their new values. 
        /// Supported keys are "name", "email", and "phone".
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous operation. 
        /// The task result contains <c>true</c> if the user was found and updated; otherwise, <c>false</c>.
        /// </returns>
        public async Task<bool> ExecuteAsync(Guid id, Dictionary<string, object> updates)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return false;

            foreach (var entry in updates)
            {
                switch (entry.Key.ToLower())
                {
                    case "name":
                        user.Name = entry.Value?.ToString() ?? user.Name;
                        break;
                    case "email":
                        user.Email = entry.Value?.ToString() ?? user.Email;
                        break;
                    case "phone":
                        user.Phone = entry.Value?.ToString() ?? user.Phone;
                        break;
                }
            }

            await _repository.UpdateAsync(user);
            return true;
        }
    }
}
