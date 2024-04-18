using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Observer
{
    public class WeatherStation : ISubject
    {
        private List<IObserver> _observers;

        private float _temperature;

        public float Tempreature
        {
            get { return _temperature; }
            set 
            { 
                _temperature = value;
                Notify();
            }
        }


        public WeatherStation()
        {
            _observers = new List<IObserver>();
        }
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify()
        {
            _observers.ForEach(o =>
            {
                o.Update(this);
            });
        }
    }
}
