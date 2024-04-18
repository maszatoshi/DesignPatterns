

namespace DesignPatterns.Structural.Composite
{
    // Composite
    internal class Branch : GitComponent
    {
        private readonly string _name;

        public Branch(string name)
        {
            _name = name;
        }
        public override void ShowDetailes()
        {
            Console.WriteLine($"Branch {_name} with commits:");
            foreach (var component in _component)
            {
                component.ShowDetailes();
            }
        }
    }
}
