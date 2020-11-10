namespace ConsoleExpressionCalculator.Tree.BinaryOperationNodes
{
    public class SubtractBinaryNode : BinaryOperationNode
    {
        public SubtractBinaryNode(TreeNode leftSideNode,
            TreeNode rightSideNode) : base(leftSideNode, rightSideNode, (a, b) => a - b)
        {
        }
    }
}
