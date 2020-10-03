namespace ConsoleExpressionCalculator.Tree
{
    public class NumberNode : TreeNode
    {
        private readonly double _number;

        public NumberNode(double number)
        {
            _number = number;
        }

        public override double Evaluate()
        {
            return _number;
        }
    }
}
