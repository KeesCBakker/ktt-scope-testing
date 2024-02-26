using Ktt.ScopeTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ktt.ScopeTest.Controllers;

[ApiController]
[Route("label/{label}")]
public class LabelController(MyService myService) : ControllerBase
{
    private readonly MyService _myService = myService;

    [HttpGet("execute")]
    public string Execute()
    {
        return _myService.DoSomethingThatNeedsALabel();
    }
}
