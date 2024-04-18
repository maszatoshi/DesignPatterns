using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Bridge.Discounts
{
    // ConcreteImplementorC
    public class AutoOwnersDiscount : Discount
    {
        public override int GetDiscount()
        {
            return 5;
        }
    }
}
