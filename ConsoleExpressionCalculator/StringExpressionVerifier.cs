using System;
using System.Linq;

namespace ConsoleExpressionCalculator
{
    public class StringExpressionVerifier
    {
        public static void VerifyExpression(string expression)
        {
            if(string.IsNullOrWhiteSpace(expression))
                throw new FormatException("Expression is empty!");

            var openBracketsCount = expression.Count(c => c == '(');
            var closeBracketsCount = expression.Count(c => c == ')');
            if (openBracketsCount != closeBracketsCount)
                throw new FormatException("Wrong number of brackets in the expression!");

            var bracketsOrder = expression
                .Where(c => c == '(' || c == ')')
                .Aggregate("", (current, next) => current + next);

            while(bracketsOrder.Contains("(" + ")"))
            {
                bracketsOrder = bracketsOrder.Replace("(" + ")", "");
            }

            if (!string.IsNullOrEmpty(bracketsOrder))
                throw new FormatException("Wrong order of brackets in the expression!");
        }
    }
}
