using RulesEngine.Library.Models;
using RulesEngineLibrary;
using Xunit;

namespace RulesEngineTests
{
    public class Tests
    {
        //The Given-When-Then pattern
        [Fact]
        public void CustomerWith_FiveYearsOrMoreLoyalty_RecievesFiftenPercentDiscount()
        {
            //Arrange
            var engine = new DiscountEngine();

            var customer = new Customer
            {
                LengthOfService = 5,
                Offer = 100
            };

            //Act
            var discount = engine.CalculateDiscount(customer);

            //Assert
            Assert.Equal(15, discount);
        }
    }
}
