using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal interface IClass
    {
        void Do();
    }

    internal class A : IClass
    {
        public void Do() 
        {
            Console.WriteLine("A");
        }
    }

    internal class B : A
    {
        public new void Do()
        {
            Console.WriteLine("B");
        }
    }
}
