using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Proxy
{
    public class ConcreteService : IService
    {
        public void Login(int age)
        {
            Console.WriteLine($"You are logged in. Your age is {age}.");
        }
    }
}
