using Ktt.ScopeTest.Services.Context.Exceptions;

namespace Ktt.ScopeTest.Services.Context;

public class LabelContext
{
    public LabelContext(string? label)
    {
        if(!Validate(label))
        {
            throw new InvalidLabelException(label);
        }

        Label = label;
    }

    public string? Label { get; }

    public void EnsureLabel()
    {
        if (string.IsNullOrEmpty(Label))
        {
            throw new NoLabelException();
        }
    }

    public static bool Validate(string? label)
    {
        return String.IsNullOrEmpty(label) || new[] { "localhost", "127.0.0.1", "test" }.Contains(label);
    }
}
