namespace Ktt.ScopeTest.Business.Context.Exceptions;

public class InvalidLabelException(string? label) : Exception($"Invalid label: {label ?? "<null>"}")
{
}
