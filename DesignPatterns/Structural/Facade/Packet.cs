using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Facade
{
    public class Packet
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string IP { get; set; }

        public Packet(string ip)
        {
            this.IP = ip;
        }

        public void PacketBuilt()
        {
            Console.WriteLine("Packet built");
        }
    }
}
