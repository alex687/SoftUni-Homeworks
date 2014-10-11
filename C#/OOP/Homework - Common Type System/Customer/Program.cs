using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer(9502030405, "hasan", "hasan", "hasan", "0884899549", "hasan@abv.bg", "sadasd",
                CustomerType.Diamond, new List<Payment>());
            
            var newCustomer = customer.Clone();
        }
    }
}
