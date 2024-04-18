using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Interpreter
{
    public class NumberExpression : IExpression
    {
        private int _value;
        public NumberExpression(int value)
        {
            _value = value;
        }
        public int Interpret()
        {
            return _value;
        }
    }
}
