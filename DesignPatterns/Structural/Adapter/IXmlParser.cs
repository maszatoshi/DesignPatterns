using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Adapter
{
    public interface IXmlParser<T>
    {
        // Adaptee - The interface that is incompatible with the targer interface

        T Parse(string data);
        String ConverToXml(T obj);
    }
}
