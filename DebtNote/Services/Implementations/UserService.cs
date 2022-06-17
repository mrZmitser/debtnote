using DebtNote.Database;
using DebtNote.Models;
using DebtNote.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DebtNote.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;
        public UserService(ApplicationContext context) => _context = context;
        public List<User> GetAll() => _context.Users.ToList();
        public User GetById(int id) => _context.Set<User>().FirstOrDefault(user => user.Id == id);
        public User CreateUser(User user)
        {
            _context.AddAsync(user);
            _context.SaveChanges();
            return user;
        }
        public User UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return user;
        }
        public void DeleteUser(int id)
        {
            var toDelete = _context.Set<User>().FirstOrDefault(user => user.Id == id);
            if (toDelete != null)
            {
                _context.Set<User>().Remove(toDelete);
                _context.SaveChanges();
            }
        }
        
    }
}
