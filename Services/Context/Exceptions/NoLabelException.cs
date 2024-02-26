namespace Ktt.ScopeTest.Services.Context.Exceptions;

public class NoLabelException : Exception
{
    public NoLabelException() : base("No label was provided") { }
}
