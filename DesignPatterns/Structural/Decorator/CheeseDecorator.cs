using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Decorator
{
    public class CheeseDecorator : PizzaDecorator
    {
        public readonly IPizza _pizza;
        public CheeseDecorator(IPizza pizza) : base(pizza)
        {
            _pizza = pizza;
        }

        public override string GetPizzaType()
        {
            string type = base.GetPizzaType();
            type += "\r\n with extra cheese";
            return type;
        }
    }
}
