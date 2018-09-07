using System.Collections.Generic;

namespace Decorator
{
    public interface IPizza
    {
        List<string> GetToppings();
        double GetCost();
    }

    public class PizzaBase : IPizza
    {
        public double GetCost()
        {
            return 8;
        }

        public List<string> GetToppings()
        {
            return new List<string>();
        }
    }

    public class Decorator : IPizza
    {
        IPizza _pizza;

        protected List<string> _toppings = new List<string>();
        protected double _cost = 8;

        public Decorator(IPizza pizza)
        {
            _pizza = pizza;
        }

        public List<string> GetToppings()
        {
            _toppings.AddRange(_pizza.GetToppings());
            return _toppings;
        }

        public double GetCost()
        {
            return _pizza.GetCost() + _cost;
        }
    }

    public class PepperoniPizza : Decorator
    {
        public PepperoniPizza(IPizza pizza) : base(pizza)
        {
            _toppings = new List<string>() { "Pepperoni" };
            _cost = 2;
        }
    }

    public class SausagePizza : Decorator
    {
        public SausagePizza(IPizza pizza) : base(pizza)
        {
            _toppings = new List<string>() { "Sausage" };
            _cost = 3;
        }
    }
}
