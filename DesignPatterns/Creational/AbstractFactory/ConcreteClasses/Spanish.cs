using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory
{
    // ConcreteProductA2
    public class Spanish : ILanguage
    {
        public void Greet()
        {
            Console.WriteLine("Hola!");
        }
    }
}
