using DebtNote.Services.Interfaces;
using DebtNote.Repositories.Interfaces;
using DebtNote.Models;

namespace DebtNote.Services.Implimentations
{
    public class TransferService : ITransferService
    {
        private IPaymentRepository<Payment>? Payments { get; set; }
        private IUserRepository<User>? Users { get; set; }

        public IUserRepository<User>? GetUsers()
        {
            return Users;
        }

        public void Transfer(int amount, IUserRepository<User>? users)
        {

            User user1 = users.Create(new User
            {
                Id = 1,
                Name = "John",
                Money = 100
            }) ;
            User user2 = Users.Create(new User
            {
                Id = 2,
                Name = "Dave",
                Money = 10
            });

            Payments.Create(new Payment
            {
                Id =1,
                Money =amount,
            });
            if(user1.Money>= amount)
            {
                user1.Money-=amount;
                user2.Money+=amount;
            }
            else
            {
                //message : no enouhg money!
            }
            //take money from 1st give to 2nd
        }
    }
}
