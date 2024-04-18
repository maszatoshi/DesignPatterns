using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Iterator
{
    public class Iterator : IAbstractIterator
    {
        private Collection _collection;
        int current = 0;
        int step = 1;

        public Iterator(Collection collection)
        {
            _collection = collection;
        }

        public Item First()
        {
            current = 0;
            return _collection[current] as Item;
        }

        public Item Next()
        {
            current += step;
            if (!IsDone)
                return _collection[current] as Item;
            else
                return null;
        }

        public int Step
        {
            get { return step; }
            set { step = value; }
        }

        public Item CurrentItem
        {
            get { return _collection[current] as Item; }
        }

        public bool IsDone
        {
            get { return current >= _collection.Count; }
        }
    }
}
