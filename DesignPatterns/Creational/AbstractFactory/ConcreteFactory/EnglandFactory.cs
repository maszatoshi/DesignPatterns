using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory.ConcreteFactory
{
    // ConcreteFactory1
    public class EnglandFactory : IInternationalFactory
    {
        public ICapitalCity CreateCapital()
        {
            return new London();
        }

        public ILanguage CreateLanguage()
        {
            return new English();
        }
    }
}
