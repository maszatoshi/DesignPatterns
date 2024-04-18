using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory
{
    // ConcreteProductB2
    internal class Madrid : ICapitalCity
    {
        public int GetPolulation()
        {
            return 3200000;
        }

        public List<string> ListTopAttractions()
        {
            return new List<string>() { "Royal Palace","Prado Museum","Retiro Park"};
        }
    }
}
