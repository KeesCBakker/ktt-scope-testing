using Ktt.ScopeTest.Services.Context;
namespace Ktt.ScopeTest.Services;

public class MyService
{
    private LabelContext _labelContext;

    public MyService(LabelContext labelContext)
    {
        _labelContext = labelContext;
    }

    public string DoSomethingThatNeedsALabel()
    {
        _labelContext.EnsureLabel();

        return "Executed with label: " + _labelContext.Label!;
    }
}
