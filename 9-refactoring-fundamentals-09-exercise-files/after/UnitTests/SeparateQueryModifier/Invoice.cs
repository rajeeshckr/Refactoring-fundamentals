using System;

namespace UnitTests.SeparateQueryModifier
{
    public class Invoice
    {
        public DateTime InvoiceDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public bool Paid { get; set; }
    }
}