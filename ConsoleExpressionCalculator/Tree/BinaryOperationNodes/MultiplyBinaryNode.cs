namespace ConsoleExpressionCalculator.Tree.BinaryOperationNodes
{
    public class MultiplyBinaryNode : BinaryOperationNode
    {
        public MultiplyBinaryNode(TreeNode leftSideNode,
            TreeNode rightSideNode) : base(leftSideNode, rightSideNode, (a, b) => a * b)
        {
        }
    }
}
