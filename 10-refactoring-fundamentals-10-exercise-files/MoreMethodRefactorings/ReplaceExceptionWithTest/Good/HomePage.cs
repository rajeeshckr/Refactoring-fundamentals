using System;
using System.Collections.Generic;
using System.Linq;

namespace MoreMethodRefactorings.ReplaceExceptionWithTest.Good
{
    public class HomePage
    {
        private readonly string _customerKey = "abc123";

        public Dictionary<string, Customer> Cache { get; set; }
        public string GetGreeting()
        {
            Customer customer = Cache[_customerKey];
            if (customer == null)
            {
                customer = new Customer(_customerKey);
                Cache.Add(_customerKey, customer);
            }
            return customer.Greeting();
        }
    }
}