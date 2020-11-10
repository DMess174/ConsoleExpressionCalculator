namespace ConsoleExpressionCalculator.Tree.UnaryOperationNodes
{
    public class SubtractUnaryNode : UnaryOperationNode
    {
        public SubtractUnaryNode(TreeNode rightSideNode) : base(rightSideNode, (a) => -a)
        {
        }
    }
}
