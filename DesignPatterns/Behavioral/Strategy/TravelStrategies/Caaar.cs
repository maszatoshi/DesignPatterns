using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Strategy.TravelStrategies
{
    public class Caaar : TravelStrategy
    {
        public Caaar()
        {
            KilometerCost = 25;
        }
        public override decimal Drive(int kilometers)
        {
            return kilometers * KilometerCost;
        }
    }
}
