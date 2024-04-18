using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Decorator
{
    public class Pizza : IPizza
    {
        public string GetPizzaType()
        {
            return "This is a normal pizza";
        }
    }
}
