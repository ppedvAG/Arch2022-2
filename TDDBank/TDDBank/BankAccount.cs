namespace TDDBank
{
    public class BankAccount
    {
        public decimal Balance { get; private set; } = 0;

        public void Deposit(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException(nameof(value));

            Balance += value;
        }

        public void Withdraw(decimal value)
        {
            if (value <= 0)
                throw new ArgumentException(nameof(value));
            
            if (value > Balance)
                throw new InvalidOperationException();

            Balance -= value;
        }
    }
}