using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Strategy
{
    public abstract class TravelStrategy
    {
        public int KilometerCost;

        public abstract decimal Drive(int kilometers);
    }
}
