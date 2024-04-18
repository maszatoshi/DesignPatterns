using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Bridge
{
    // Abstraction
    public abstract class CarInsurance
    {
        private readonly Discount _discount;
        public CarInsurance(int year, string make, string model, Discount discount) 
        {
            Year = year;
            Make = make;
            Model = model;

            _discount = discount;
        }

        public int Year { get; }
        public string Make { get; }
        public string Model { get; }

        public decimal CalculatePremium()
        {
            decimal normalPrice = GetPremium();
            decimal discountPortion = normalPrice * (_discount.GetDiscount() / 100m);
            return normalPrice - discountPortion;
        }

        protected abstract decimal GetPremium();
    }
}
