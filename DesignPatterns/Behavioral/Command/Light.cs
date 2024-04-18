using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command
{
    // Receiver
    public class Light
    {
        public void On()
        {
            Console.WriteLine("Light is ON");
        }

        public void Off()
        {
            Console.WriteLine("Light is OFF");
        }
    }
}
