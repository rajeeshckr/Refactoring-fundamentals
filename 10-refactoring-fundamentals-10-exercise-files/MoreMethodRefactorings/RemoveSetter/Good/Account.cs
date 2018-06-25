using System;
using System.Linq;

namespace MoreMethodRefactorings.RemoveSetter.Good
{
public class Account
{
    public int Id { get; private set; }

    public Account(int id)
    {
        this.Id = id;
    }
}

public class PremiumAccount : Account
{
    public PremiumAccount(int id) : base(id)
    {
    }
}
}