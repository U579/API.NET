namespace Application.UseCases
{
    public class DeleteUserService(IUserRepository repository)
    {
        private readonly IUserRepository _repository = repository;

        public async Task ExecuteAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Usuario no encontrado.");
            await _repository.DeleteAsync(id);
        }
    }
}
