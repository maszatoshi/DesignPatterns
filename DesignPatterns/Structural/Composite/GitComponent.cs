using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite
{
    public abstract class GitComponent
    {
        protected readonly List<GitComponent> _component = new List<GitComponent>();
        public abstract void ShowDetailes();

        public void Add(GitComponent component) 
        {
            _component.Add(component);
        }

        public void Remove(GitComponent component) 
        {
            _component.Remove(component);
        }
    }


}
