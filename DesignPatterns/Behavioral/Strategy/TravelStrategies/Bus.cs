using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Strategy.TravelStrategies
{
    public class Bus : TravelStrategy
    {
        public Bus()
        {
            KilometerCost = 20;
        }
        public override decimal Drive(int kilometers)
        {
            return kilometers * KilometerCost;
        }
    }
}
