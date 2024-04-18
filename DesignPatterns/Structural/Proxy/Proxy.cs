using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Proxy
{
    public class Proxy : IService
    {
        private IService _service;

        public Proxy(IService service)
        {
            _service = service;
        }

        public void Login(int age)
        {
            if (age < 18) 
            {
                Console.WriteLine($"You are too young.");
            }
            else 
            { 
                _service.Login(age);
            }
        }
    }
}
