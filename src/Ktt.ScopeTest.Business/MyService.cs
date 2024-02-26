using Ktt.ScopeTest.Business.Context;

namespace Ktt.ScopeTest.Business;

public class MyService(LabelContext labelContext)
{
    private LabelContext _labelContext = labelContext;

    public string DoSomethingThatNeedsALabel()
    {
        _labelContext.EnsureLabel();

        return "Executed with label: " + _labelContext.Label!;
    }
}
