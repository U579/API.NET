using Domain.Entities;
using Domain.Repositories;


namespace Application.UseCases
{
    public class CreateUserService(IUserRepository repository)
    {
        private readonly IUserRepository _repository = repository;

        public async Task ExecuteAsync(User user)
        {
            await _repository.AddAsync(user);
        }
    }
}
