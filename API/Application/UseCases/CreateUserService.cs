namespace Application.UseCases{
    public class CreateUserService(IRepositoryClient repository)
    {
        private readonly IRepositoryClient _repository = repository;

        public async Task ExecuteAsync(Cliente cliente)
        {
            await _repository.AddAsync(cliente);
        }
    }
}
