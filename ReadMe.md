# Discount Engine


Add RulesEngine.Library.dll to solution.


     var engine = new DiscountEngine();
    
        var customer = new Customer
        {
            Duration = 5,
            Offer = 100
        };
    
        var discount = engine.CalculateDiscount(customer);

# Add new discount rule.

Create a new library and add reference to **RulesEngine.Library.dll**.

and create a new discount rule that inherits **IDiscount**

e. g.

    /// <summary>
    /// 15 % discount rule for loyal customers that have has 5 years.
    /// </summary>
    
      public class LoyalCustomerDiscount : IDiscount
        {
            public bool IsMatch(Customer customer)
            {
                return customer.LengthOfService >= 5;
            }
    
            public decimal Calculate(Customer customer)
            {
                return (customer.Offer / 100 * 15);
            }
        }
    
    


