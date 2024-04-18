using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Decorator
{
    internal class OnionDecorator : PizzaDecorator
    {
        private readonly IPizza _pizza;
        public OnionDecorator(IPizza pizza) : base(pizza)
        {
            _pizza = pizza;
        }

        public override string GetPizzaType()
        {
            string type = base.GetPizzaType();
            type += "\r\n with extra onion";
            return type;
        }
    }
}
