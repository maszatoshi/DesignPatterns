using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Interpreter
{
    public class Context
    {
        private Stack<IExpression> _expressionStack = new Stack<IExpression>();
        private Stack<string> _operatorStack = new Stack<string>();

        public int InsertExpression(string expressions)
        {
            for (int i = 0; i < expressions.Length; i++)
            {
                string singleValue = expressions[i].ToString();
                switch (singleValue) 
                {
                    case "+":
                        _operatorStack.Push(singleValue);
                        break;
                    case "-":
                        _operatorStack.Push(singleValue);
                        break;
                    default:
                        if (Int32.TryParse(singleValue, out int number))
                        {
                            IExpression expresssion = new NumberExpression(number);
                            _expressionStack.Push(expresssion);
                        }
                        break;

                }

                if (_operatorStack.Count == 1 && _expressionStack.Count == 2)
                {
                    IExpression rightExpression = null;
                    IExpression leftExpression = null;
                    switch (_operatorStack.Pop()) 
                    {
                        case "+":
                            rightExpression = _expressionStack.Pop();
                            leftExpression = _expressionStack.Pop();
                            IExpression plusExpression = new PlusExpression(leftExpression, rightExpression);
                            _expressionStack.Push(plusExpression);
                            break;
                        case "-":
                            rightExpression = _expressionStack.Pop();
                            leftExpression = _expressionStack.Pop();
                            IExpression minusExpression = new MinusExpression(leftExpression, rightExpression);
                            _expressionStack.Push(minusExpression);
                            break;
                        default:
                            break;
                    }
                }
            }
            return _expressionStack.Pop().Interpret();
        }
    }
}
