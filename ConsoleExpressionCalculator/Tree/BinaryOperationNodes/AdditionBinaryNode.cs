namespace ConsoleExpressionCalculator.Tree.BinaryOperationNodes
{
    public class AdditionBinaryNode : BinaryOperationNode
    {
        public AdditionBinaryNode(TreeNode leftSideNode,
            TreeNode rightSideNode) : base(leftSideNode, rightSideNode, (a, b) => a + b)
        {
        }
    }
}
