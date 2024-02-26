namespace Ktt.ScopeTest.Services.Context;

public class LabelContextProvider(IHttpContextAccessor accessor)
{
    private readonly IHttpContextAccessor _accessor = accessor;
    private LabelContext? _labelContext;

    public LabelContext Context
    {
        get
        {
            if (_labelContext == null)
            {
                TryInitFromHttp();
            }

            return _labelContext ?? new LabelContext(string.Empty);
        }
        set
        {
            _labelContext = value;
        }
    }

    private bool TryInitFromHttp()
    {
        if (_accessor == null || _accessor.HttpContext == null) return false;

        var label = LabelValidationMiddleware.GetLabelFromHttpContext(_accessor.HttpContext);
        _labelContext = new LabelContext(label);
    
        return true;
    }
}
