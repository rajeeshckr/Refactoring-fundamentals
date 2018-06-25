using System;
using System.Linq;

namespace MoreMethodRefactorings.ReplaceErrorCodeException.Bad
{
    public class Account
    {
        private decimal _currentBalance;

        public int Withdraw(decimal amount)
        {
            if (amount > _currentBalance)
            {
                return -1;
            }
            _currentBalance -= amount;
            return 0;
        }
    }
}