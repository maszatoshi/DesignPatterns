﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Iterator
{
    /// <summary>
    /// A collection item.
    /// </summary>
    public class Item
    {
		private string _name;

        public Item(string name)
        {
            _name = name;
        }

        public string Name
		{
			get { return _name; }
		}

	}
}
