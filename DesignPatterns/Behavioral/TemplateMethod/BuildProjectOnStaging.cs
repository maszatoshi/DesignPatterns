using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.TemplateMethod
{
    public class BuildProjectOnStaging : BuildProject
    {
        public BuildProjectOnStaging() : base()
        {
            
        }

        public override void DeployCode()
        {
            Console.WriteLine("Deployed to Staging server");
        }
    }
}
