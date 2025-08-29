namespace Application.UseCases
{
    public class UpdateUserService(IUserRepository repository)
    {
        private readonly IUserRepository _repository = repository;

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
