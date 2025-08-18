using UserManagement.Domain.Entities; // Tham chiếu đến Entity từ Domain
using System.Threading.Tasks;

namespace UserManagement.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id); // Lấy User theo ID
        Task AddAsync(User user); // Thêm User mới
    }
}