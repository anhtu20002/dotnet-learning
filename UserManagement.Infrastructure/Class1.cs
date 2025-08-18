using UserManagement.Domain.Entities;
using UserManagement.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserManagement.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private List<User> _users = new List<User>();

        public Task<User> GetByIdAsync(int id)
        {
            return Task.FromResult(_users.Find(u => u.Id == id));
        }

        public Task AddAsync(User user)
        {
            user.Id = _users.Count + 1;
            _users.Add(user);
            return Task.CompletedTask;
        }
    }
}