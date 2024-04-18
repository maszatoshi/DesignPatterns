using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.TemplateMethod
{
    public class BuildProject
    {
        public BuildProject()
        {
            CompileCode();
            RunTests();
            DeployCode();
        }

        public virtual void CompileCode()
        {
            Console.WriteLine("Code is Compiled");
        }

        public virtual void RunTests()
        {
            Console.WriteLine("Tests ran successfully!");
        }
        public virtual void DeployCode()
        {
            Console.WriteLine("Deployed to QE server");
        }
    }
}
