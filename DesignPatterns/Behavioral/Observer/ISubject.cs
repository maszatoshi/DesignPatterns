using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Observer
{
    public interface ISubject
    {
        /// <summary>
        /// Observer ezzel attach-eli fel magát
        /// </summary>
        /// <param name="observer"></param>
        void Attach(IObserver observer);

        /// <summary>
        /// Minden tárolt obseerver ezzel lesz notifyolva a változásról
        /// </summary>
        void Notify(); 
    }
}
