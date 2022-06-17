namespace DebtNote.Repositories.Interfaces
{
    public interface IUserRepository<User> 
    {
        public List<User> GetAll();
        public User Get(User id);
        public User Create(User model);
        public User Update(User model);
        public void Delete(User id);
    }
}
