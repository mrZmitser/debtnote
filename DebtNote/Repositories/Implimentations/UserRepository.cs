using DebtNote.Database;
using DebtNote.Repositories.Interfaces;

namespace DebtNote.Repositories.Implimentations
{
    public class UserRepository<User> : IUserRepository<User>
    {
        private ApplicationContext Context { get; set; }
        public UserRepository(ApplicationContext context)
        {
            Context = context;
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Get(User id)
        {
            throw new NotImplementedException();
        }

        public User Create(User model)
        {
            throw new NotImplementedException();
        }

        public User Update(User model)
        {
            throw new NotImplementedException();
        }

        public void Delete(User id)
        {
            throw new NotImplementedException();
        }
    }
}
