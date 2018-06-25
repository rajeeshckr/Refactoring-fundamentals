using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.SeparateQueryModifier.Good
{
    public class CallingCode
    {
        public void ProcessAccounts(IEnumerable<Account> accounts)
        {
            foreach (var account in accounts)
            {
                var overdueInvoices = account.ListPastDueInvoices(DateTime.Now);
                account.ProcessOverdueInvoices(DateTime.Now);

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

        public void ProcessOverdueInvoices(DateTime processDate)
        {
            foreach (var invoice in ListPastDueInvoices(processDate))
            {
                EnsureAccountStatusIsOverdue();
                SendPastDueNotice(invoice);
            }
        }

        private void EnsureAccountStatusIsOverdue()
        {
            if (Status != AccountStatus.Overdue)
            {
                Status = AccountStatus.Overdue;
            }
        }

        public void SendPastDueNotice(Invoice invoice)
        { }

        public IEnumerable<Invoice> ListPastDueInvoices(DateTime processDate)
        {
            return Invoices.Where(i => (!i.Paid && i.PaymentDueDate < processDate));
        }
    }
}
