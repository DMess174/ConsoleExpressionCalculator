using System;

namespace ConsoleExpressionCalculator.Tree.BinaryOperationNodes
{
    public abstract class BinaryOperationNode : TreeNode
    {
        private readonly TreeNode _leftSideNode;
        private readonly TreeNode _rightSideNode;
        private readonly Func<double, double, double> _operator;

        public BinaryOperationNode(TreeNode leftSideNode, TreeNode rightSideNode, Func<double, double, double> @operator)
        {
            _leftSideNode = leftSideNode;
            _rightSideNode = rightSideNode;
            _operator = @operator;
        }

        public override double Evaluate()
        {
            var leftSideValue = _leftSideNode.Evaluate();
            var rightSideValue = _rightSideNode.Evaluate();

            return _operator(leftSideValue, rightSideValue);
        }
    }
}
