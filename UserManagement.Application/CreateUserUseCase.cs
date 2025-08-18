using UserManagement.Domain.Entities; // Tham chiếu Entity
using UserManagement.Application.Interfaces; // Tham chiếu Interface
using System.Threading.Tasks;
using System;

namespace UserManagement.Application.UseCases
{
    public class CreateUserUseCase
    {
        private readonly IUserRepository _repository;

        public CreateUserUseCase(IUserRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task ExecuteAsync(User user)
        {
            // Business rule: Kiểm tra email không được rỗng
            if (string.IsNullOrEmpty(user.Email))
            {
                throw new Exception("Email is required.");
            }
            await _repository.AddAsync(user); // Gọi Repository để lưu
        }
    }
}