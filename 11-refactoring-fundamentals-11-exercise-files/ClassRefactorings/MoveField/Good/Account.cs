namespace ClassRefactorings.MoveField.Good
{
    public class AccountType
    {
        public decimal InterestRate { get; private set; }
    }

    public class Account
    {
        private AccountType _type;

        // other methods that use InterestRate

        public decimal CalculateInterest(decimal amount, int days)
        {
            return amount * _type.InterestRate * days / 365;
        }
    }
}
