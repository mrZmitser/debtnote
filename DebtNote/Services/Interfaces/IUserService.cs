using DebtNote.Models;

namespace DebtNote.Services.Interfaces
{
    public interface IUserService
    {
        public List<User> GetAll();
        public User GetById(int id);
        public Task<User> CreateUser(User user);
        public User UpdateUser(User user);
        public Task DeleteUserAsync(int id);
    }
}
