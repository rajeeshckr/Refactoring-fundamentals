using System;
using System.Collections.Generic;
using System.Linq;

namespace MoreMethodRefactorings.ReplaceExceptionWithTest.Bad
{
    public class HomePage
    {
        private readonly string _customerKey = "abc123";

        public Dictionary<string, Customer> Cache { get; set; }
        public string GetGreeting()
        {
            Customer customer = null;
            try
            {
                customer = Cache[_customerKey];
                return customer.Greeting();
            }
            catch (NullReferenceException)
            {
                customer = new Customer(_customerKey);
                Cache.Add(_customerKey, customer);
                return customer.Greeting();
            }
        }
    }
}