using System;

namespace ConsoleExpressionCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            while(true)
            {
                Console.WriteLine("Please enter the expression to calculate or 'quit' to exit:");

                var calculator = new Calculator();

                var stringExpression = Console.ReadLine();

                switch(stringExpression)
                {
                    case "quit":
                        return;

                    default:
                        try
                        {
                            StringExpressionVerifier.VerifyExpression(stringExpression);

                            var result = calculator.Calculate(stringExpression);

                            Console.WriteLine($"{stringExpression} = {result}");
                            
                            continue;
                        }
                        catch(FormatException ex)
                        {
                            Console.WriteLine(ex.Message);

                            continue;
                        }
                }
            }
        }
    }
}