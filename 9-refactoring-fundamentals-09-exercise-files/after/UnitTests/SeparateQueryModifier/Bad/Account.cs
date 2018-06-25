using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.SeparateQueryModifier.Bad
{
    public class CallingCode
    {
public void ProcessAccounts(IEnumerable<Account> accounts)
{
    foreach (var account in accounts)
    {
        var overdueInvoices = account.ProcessOverdueInvoices(DateTime.Now);

        UpdateReport(overdueInvoices);
    }
}

private void UpdateReport(IEnumerable<Invoice> overdueInvoices)
{
}


    }

    public class Account
    {
        public IReadOnlyCollection<Invoice> Invoices { get; private set; }
        public AccountStatus Status { get; set; }

public IEnumerable<Invoice> ProcessOverdueInvoices(DateTime processDate)
{
    foreach (var invoice in Invoices.Where(i => (!i.Paid && i.PaymentDueDate < processDate)))
    {
        if (Status != AccountStatus.Overdue)
        {
            Status = AccountStatus.Overdue;
        }
        SendPastDueNotice(invoice);
    }
    return Invoices.Where(i => (!i.Paid && i.PaymentDueDate < processDate));
}

        public void SendPastDueNotice(Invoice invoice)
        { }
    }
}
