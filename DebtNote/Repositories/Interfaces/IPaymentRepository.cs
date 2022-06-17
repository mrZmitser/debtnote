namespace DebtNote.Repositories.Interfaces
{
    public interface IPaymentRepository<Payment>
    {
        public List<Payment> GetAll();
        public Payment Get(Payment id);
        public Payment Create(Payment model);
        public Payment Update(Payment model);
        public void Delete(Payment id);
    }
}
