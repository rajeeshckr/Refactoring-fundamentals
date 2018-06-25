using System;
using System.Linq;

namespace MoreMethodRefactorings.ReplaceErrorCodeException.Good
{
    public class Account
    {
        private decimal _currentBalance;

public int Withdraw(decimal amount)
{
    try
    {
        Withdraw2(amount);
    }
    catch (InsufficientFundsException ex)
    {
        return -1;
    }
    return 0;
}

        public void Withdraw2(decimal amount)
        {
            if (amount > _currentBalance)
            {
                throw new InsufficientFundsException("Insufficient funds");
            }
            _currentBalance -= amount;
        }
    }

    public class InsufficientFundsException : ApplicationException
    {
        public InsufficientFundsException(string message) : base(message)
        {

        }
    }
}