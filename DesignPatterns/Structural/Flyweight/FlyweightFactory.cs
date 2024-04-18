using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Flyweight
{
    /// <summary>
    /// The Flyweight Factory creates and mamages the Flyweight objects.
    /// It esures that flyweights are shared correctly.
    /// When the client requests a flywight, the factory either returns an existing instance 
    /// or creates a new one, if it doesn't exist yet.
    /// </summary>
    public class FlyweightFactory
    {
        private List<Tuple<Flyweight, string>> flyweights = new List<Tuple<Flyweight, string>>();

        public FlyweightFactory(params Car[] args)
        {
            foreach (var car in args) 
            {
                flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(car), this.getKey(car)));
            }
        }

        /// <summary>
        /// Returns a Flywight's string hash for a given state.
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public string getKey(Car car)
        {
            List<string> elements = new List<string>();

            elements.Add(car.Model);
            elements.Add(car.Color);
            elements.Add(car.Company);

            if (car.Owner != null && car.Number != null) 
            {
                elements.Add(car.Number);
                elements.Add(car.Owner);
            }

            elements.Sort();

            return string.Join("_", elements);
        }

        /// <summary>
        /// Returns an esxisting Flywight with a given state or creates a new one.
        /// </summary>
        /// <param name="sharedState"></param>
        /// <returns></returns>
        public Flyweight GetFlyweight(Car sharedState)
        {
            string key = this.getKey(sharedState);

            if (flyweights.Where(t => t.Item2 == key).Count() == 0)
            {
                Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
                this.flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(sharedState), key));
            }
            else
            {
                Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
            }

            return this.flyweights.Where(t => t.Item2 == key).FirstOrDefault().Item1;
        }

        public void ListFlyweights()
        {
            var count = flyweights.Count();
            Console.WriteLine($"\nFlyweightFactory: I have {count} flyweights:");
            foreach (var flyweight in flyweights)
            {
                Console.WriteLine(flyweight.Item2);
            }
        }
    }
}
