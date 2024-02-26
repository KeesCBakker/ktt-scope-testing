namespace Ktt.ScopeTest.Services.Context.Exceptions;

public class InvalidLabelException(string? label) : Exception($"Invalid label: {label ?? "<null>"}")
{
}
