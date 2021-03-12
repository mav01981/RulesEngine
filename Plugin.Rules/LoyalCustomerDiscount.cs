using RulesEngine.Library.Models;
using RulesEngineLibrary;

namespace Plugin.Library
{
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
}
