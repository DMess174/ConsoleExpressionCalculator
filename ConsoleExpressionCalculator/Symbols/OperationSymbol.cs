namespace ConsoleExpressionCalculator.Symbols
{
    public class OperationSymbol : Symbol
    {
        public override SymbolType Type => SymbolType.Operation;

        public OperationTypes OperationType { get; }

        public OperationSymbol(OperationTypes operationType)
        {
            OperationType = operationType;
        }
    }
}