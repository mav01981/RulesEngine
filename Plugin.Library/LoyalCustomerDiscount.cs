using RulesEngineLibrary;

namespace Plugin.Library
{
    /// <summary>
    /// 15 % discount rule for loyal customers that have has 5 years.
    /// </summary>
    public class LoyalCustomerDiscount : IDiscount
    {
        public bool IsMatch<T>(T customer)
        {
            var value = (int)customer.GetType().GetProperty("Duration").GetValue(customer, null);

            return value >= 5;
        }

        public decimal Calculate<T>(T customer)
        {
            var value = (decimal)customer.GetType().GetProperty("Offer").GetValue(customer, null);

            return (value / 100 * 15);
        }
    }
}
