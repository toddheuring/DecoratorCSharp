using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Decorator
{
    public class Tests
    {
        [Test]
        public void ShouldGetPizzaBase()
        {
            var result = new PizzaBase();

            AssertResults(result, 8, new List<string>());
        }

        [Test]
        public void ShouldGetPepperoniPizza()
        {
            var result = new PepperoniPizza(new PizzaBase());

            AssertResults(result, 10, new List<string>() { "Pepperoni" });
        }

        [Test]
        public void ShouldGetSausagePizza()
        {
            var result = new SausagePizza(new PizzaBase());

            AssertResults(result, 11, new List<string>() { "Sausage" });
        }

        [Test]
        public void ShouldGetSausageandPepperoniPizza()
        {
            var result = new SausagePizza(new PepperoniPizza(new PizzaBase()));

            AssertResults(result, 13, new List<string>() { "Sausage", "Pepperoni" });
        }

        private void AssertResults(IPizza pizza, double expectedCost, List<string> expectedToppings)
        {
            Assert.AreEqual(pizza.GetCost(), expectedCost);
            Assert.IsTrue(pizza.GetToppings().SequenceEqual(expectedToppings));
        }
    }
}