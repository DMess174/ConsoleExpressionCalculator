namespace ConsoleExpressionCalculator.Tree.BinaryOperationNodes
{
    public class DivideBinaryNode : BinaryOperationNode
    {
        public DivideBinaryNode(TreeNode leftSideNode,
            TreeNode rightSideNode) : base(leftSideNode, rightSideNode, (a, b) => a / b)
        {
        }
    }
}
