namespace ConsoleExpressionCalculator
{
    public enum Symbol
    {
        /// <summary>
        /// End of expression
        /// </summary>
        EOE,
        /// <summary>
        /// +
        /// </summary>
        Add,
        /// <summary>
        /// -
        /// </summary>
        Subtract,
        /// <summary>
        /// *
        /// </summary>
        Multiply,
        /// <summary>
        /// /
        /// </summary>
        Divide,
        /// <summary>
        /// (
        /// </summary>
        OpenBracket,
        /// <summary>
        /// )
        /// </summary>
        CloseBracket,

        Number,
    }
}
