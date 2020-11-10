using ConsoleExpressionCalculator.Symbols;
using ConsoleExpressionCalculator.Tree.BinaryOperationNodes;
using ConsoleExpressionCalculator.Tree.UnaryOperationNodes;
using System;
using System.Collections.Generic;

namespace ConsoleExpressionCalculator.Tree
{
    public class TreeBuilder : ITreeBuilder
    {
        public TreeNode CreateTree(IList<Symbol> symbols)
        {
            TreeNode tree = GetAddSubNode(symbols, 0, out _);

            return tree;
        }

        private TreeNode GetAddSubNode(IList<Symbol> symbols, int index, out int currentIndex)
        {
            var leftSideNode = GetMultiplyDevideNode(symbols, index, out index);

            while (index < symbols.Count)
            {
                if (!(symbols[index] is OperationSymbol currentSymbol) || currentSymbol.OperationType == OperationTypes.Multiply ||
                    currentSymbol.OperationType == OperationTypes.Divide)
                {
                    currentIndex = index;
                    return leftSideNode;
                }

                index += 1;

                TreeNode rightSideNode = GetMultiplyDevideNode(symbols, index, out index);

                switch (currentSymbol.OperationType)
                {
                    case OperationTypes.Add:
                        leftSideNode = new AdditionBinaryNode(leftSideNode, rightSideNode);
                        break;
                    case OperationTypes.Subtract:
                        leftSideNode = new SubtractBinaryNode(leftSideNode, rightSideNode);
                        break;
                }
            }
            currentIndex = index;
            return leftSideNode;
        }

        private TreeNode GetMultiplyDevideNode(IList<Symbol> symbols, int index, out int currentIndex)
        {
            var leftSideNode = GetUnaryNode(symbols, index, out index);

            while (index < symbols.Count)
            {
                if (!(symbols[index] is OperationSymbol currentSymbol) || currentSymbol.OperationType == OperationTypes.Add ||
                    currentSymbol.OperationType == OperationTypes.Subtract)
                {
                    currentIndex = index;
                    return leftSideNode;
                }

                index += 1;

                var rightSideNode = GetUnaryNode(symbols, index, out index);

                switch (currentSymbol.OperationType)
                {
                    case OperationTypes.Multiply:
                        leftSideNode = new MultiplyBinaryNode(leftSideNode, rightSideNode);
                        break;
                    case OperationTypes.Divide:
                        leftSideNode = new DivideBinaryNode(leftSideNode, rightSideNode);
                        break;
                }
            }
            currentIndex = index;
            return leftSideNode;
        }


        private TreeNode GetUnaryNode(IList<Symbol> symbols, int index, out int currentIndex)
        {
            while (index < symbols.Count)
            {
                if (symbols[index] is OperationSymbol currentSymbol)
                {
                    switch (currentSymbol.OperationType)
                    {
                        case OperationTypes.Add:
                            index += 1;
                            continue;
                        case OperationTypes.Subtract:
                            index += 1;
                            var rightSideNode = GetUnaryNode(symbols, index, out index);
                            currentIndex = index;
                            return new SubtractUnaryNode(rightSideNode);
                    }
                }
                var nodeLeaf = GetNodeLeaf(symbols, index, out index);
                currentIndex = index;
                return nodeLeaf;
            }
            throw new FormatException("GetUnaryNode");
        }

        private TreeNode GetNodeLeaf(IList<Symbol> symbols, int index, out int currentIndex)
        {
            if (symbols[index] is NumberSymbol)
            {
                var currentSymbol = symbols[index] as NumberSymbol;
                var node = new NumberNode(currentSymbol.Number);

                currentIndex = index + 1;

                return node;
            }

            if (symbols[index] is SpecialSymbol)
            {
                var currentSymbol = symbols[index] as SpecialSymbol;

                if (currentSymbol.SpecialType == SpecialSymbolTypes.OpenBracket)
                {
                    index += 1;

                    var node = GetAddSubNode(symbols, index, out index);

                    currentIndex = index + 1;

                    return node;
                }
            }

            throw new FormatException($"Unexpected symbol: {symbols[index]}");
        }
    }
}
