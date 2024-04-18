using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Observer
{
    public interface IObserver
    {
        /// <summary>
        /// Ez lesz meghívva, mikor a Subject Notify() metódusa meghívásra kerül.
        /// </summary>
        /// <param name="subject"></param>
        void Update(ISubject subject);
    }
}
