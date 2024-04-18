

namespace DesignPatterns.Structural.Composite
{
    // Leaf
    public class Commit : GitComponent
    {
        private readonly string _commitId;

        public Commit(string commitId)
        {
            _commitId = commitId;
        }
        public override void ShowDetailes()
        {
            Console.WriteLine($"- commit ID: {_commitId}");
        }
    }
}
