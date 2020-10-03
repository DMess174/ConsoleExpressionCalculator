using System;

namespace ConsoleExpressionCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculate(GetExpression());
        }

        static void Calculate(string expression)
        {
            Console.WriteLine(StringExpressionParser.Parse(expression).Evaluate());

            CalculateAnotherExpression();
        }

        static string GetExpression()
        {
            Console.WriteLine("Введите выражение для расчета");
            return Console.ReadLine().Replace(" ", "");
        }

        static void CalculateAnotherExpression()
        {
            Console.WriteLine("Для ввода нового выражения введите \"y\"");

            if (Console.ReadLine() == "y")
                Calculate(GetExpression());
        }

    }
}
