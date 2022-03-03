namespace ExceptisGame;
internal class SuccessException : Exception
{
    public SuccessException () { }
    public SuccessException (string message) : base (message) { }
}
