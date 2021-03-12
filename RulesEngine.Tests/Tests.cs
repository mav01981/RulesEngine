using RulesEngine.Tests.Models;
using RulesEngineLibrary;
using System;
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
                DOB = new DateTime(),
                Duration = 5,
                Offer = 100
            };

            //Act
            var discount = engine.CalculateDiscount(customer);

            //Assert
            Assert.Equal(15, discount);
        }
    }
}
