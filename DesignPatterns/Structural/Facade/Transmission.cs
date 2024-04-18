using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Facade
{
    public class Transmission
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Transmission(string protocolName)
        {
            this.Name = protocolName;
        }

        public void SendTransmission()
        {
            Console.WriteLine("Sent Transmission");
        }
    }
}
