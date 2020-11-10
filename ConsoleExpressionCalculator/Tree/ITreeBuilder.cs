using ConsoleExpressionCalculator.Symbols;
using System.Collections.Generic;

namespace ConsoleExpressionCalculator.Tree
{
    public interface ITreeBuilder
    {
        TreeNode CreateTree(IList<Symbol> symbols);
    }
}
