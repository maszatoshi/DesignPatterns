using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Strategy.TravelStrategies
{
    public class Plane : TravelStrategy
    {

        public Plane()
        {
            KilometerCost = 50;
        }
        public override decimal Drive(int kilometers)
        {
            if (kilometers > 1000) 
            {
                KilometerCost = 15;
            }
            return kilometers * KilometerCost;
        }
    }
}
