namespace ConsoleExpressionCalculator.Symbols
{
    public class SpecialSymbol : Symbol
    {
        public override SymbolType Type => SymbolType.Special;

        public SpecialSymbolTypes SpecialType { get; }

        public SpecialSymbol(SpecialSymbolTypes type)
        {
            SpecialType = type;
        }
    }
}
