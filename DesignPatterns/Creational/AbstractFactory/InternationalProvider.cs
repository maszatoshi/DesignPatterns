using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory
{
    public class InternationalProvider
    {
        public static ILanguage CreateLanguage(Country country)
        {
            switch (country)
            {
                case Country.ENGLAND:
                    return new English();
                case Country.SPAIN:
                    return new Spanish();
                default:
                    throw new InvalidOperationException($"Invalid country {country}");
            }
        }

        public static ICapitalCity CreateCapitalCity(Country country)
        {
            switch (country)
            {
                case Country.ENGLAND:
                    return new London();
                case Country.SPAIN:
                    return new Madrid();
                default:
                    throw new InvalidOperationException($"Invalid country {country}");
            }
        }
    }
}
