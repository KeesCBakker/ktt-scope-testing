namespace Ktt.ScopeTest.Business.Context.Exceptions;

public class NoLabelException : Exception
{
    public NoLabelException() : base("No label was provided") { }
}
