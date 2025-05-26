using DataStructures;

namespace Exam1
{
    
/// 1. Expression Evaluator with Undo

///Description:

///Build a simple calculator that supports:

///1. EnterNumber(double x) and EnterOperator(char op) (where op is +, -, *, or /) to build up an infix expression.

///2. Evaluate(): Compute and return the current result.

///3. Undo(): Remove the last entered number or operator.

///Users can chain operations (e.g. 5, +, 3, *, 2), then call Undo() multiple times to step back. After each change, `Evaluate()` should reflect the current expression.

/// Structure > In my case I used Stack because it is more easy to use UNDO with this structure
    public class ExpressionEvaluator
    {
        private readonly CustomStack<string> _expression = new();

        public void EnterNumber(double number) {
            _expression.Push(number.ToString());
        }

        public void EnterOperator(char character) {
            if ("+-*/".Contains(character))
            {
                _expression.Push(character.ToString());
            }
            else throw new ArgumentException("Invalid operator");
        }

        public void Undo() {
            if (_expression.Count > 0)
            {
                _expression.Pop();
            }
            else throw new ArgumentException("No hay nada para quitar");
        }

        public string[] Evaluate()
        {
            return _expression.ToArray().Reverse().ToArray();
        }
    }
}
