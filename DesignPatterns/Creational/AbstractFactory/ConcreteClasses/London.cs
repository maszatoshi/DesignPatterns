using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory
{
    // ConcreteProductB1
    public class London : ICapitalCity
    {
        public int GetPolulation()
        {
            return 890000;
        }

        public List<string> ListTopAttractions()
        {
            return new List<string>() { "Tower Bridge","Buckingham Palace","Big Ben"};
        }
    }
}
