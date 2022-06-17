using DebtNote.Models;
using DebtNote.Repositories.Interfaces;

namespace DebtNote.Services.Interfaces
{
    public interface ITransferService
    {
        public void Transfer(int amount, IUserRepository<User>? users);
    }
}
