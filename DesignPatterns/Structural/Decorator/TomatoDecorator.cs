using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Decorator
{
    public class TomatoDecorator : PizzaDecorator
    {
        private readonly IPizza _pizza;
        public TomatoDecorator(IPizza pizza) : base(pizza)
        {
            _pizza = pizza;
        }

        public override string GetPizzaType()
        {
            string type = base.GetPizzaType();
            type += "\r\n with extra tomato";
            return type;
        }
    }
}
