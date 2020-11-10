using System;

namespace ConsoleExpressionCalculator.Tree.UnaryOperationNodes
{
    public abstract class UnaryOperationNode : TreeNode
    {
        private readonly TreeNode _rightSideNode;
        private readonly Func<double, double> _operator;

        public UnaryOperationNode(TreeNode rightSideNode, Func<double, double> @operator)
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
