using System;

namespace ConsoleExpressionCalculator.Tree
{
    public class UnaryOperatorNode : TreeNode
    {
        private readonly TreeNode _rightSideNode;
        private readonly Func<double, double> _operator;

        public UnaryOperatorNode(TreeNode rightSideNode, Func<double, double> @operator)
        {
            _rightSideNode = rightSideNode;
            _operator = @operator;
        }

        public override double Evaluate()
        {
            var rightSideValue = _rightSideNode.Evaluate();
            return _operator(rightSideValue);
        }
    }
}
