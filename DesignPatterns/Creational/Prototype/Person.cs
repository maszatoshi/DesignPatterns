using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Prototype
{
    //Prototype
    public abstract class Person
    {
        protected Person(string name) 
        { 
            Name = name;
        }
        public string Name { get; set; }
        public abstract Person Clone();
    }
}
