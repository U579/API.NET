namespace Application.UseCases
{
    public class PatchUserService
    {
        private readonly IUserRepository _repository;

        public PatchUserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public PatchUserService(IUserRepository repository)
        {
            _repository = repository;
        }

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
