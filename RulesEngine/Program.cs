using Lib.RulesEngine;
using System;

namespace RulesEngine
{

    class Program
    {
        static void Main(string[] args)
        {
            var reflection = new RulesEngine();
            var customer = new Customer
            {
                DOB = new DateTime(),
                Duration = 4
            };

            var engine = new DiscountEngine(reflection.discounts);

            var discount = engine.CalculateDiscount(customer);
        }
    }
}
