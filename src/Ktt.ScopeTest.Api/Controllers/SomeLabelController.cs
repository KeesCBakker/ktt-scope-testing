using Ktt.ScopeTest.Business;
using Microsoft.AspNetCore.Mvc;

namespace Ktt.ScopeTest.Controllers;

[ApiController]
[Route("some-label")]
public class SomeLabelController(MyService myService) : ControllerBase
{
    private readonly MyService _myService = myService;

    [HttpGet("execute")]
    public string Execute()
    {
        return _myService.DoSomethingThatNeedsALabel();
    }

    [HttpGet("{label}/execute")]
    public string ExecuteWithSpecificLabel()
    {
        return _myService.DoSomethingThatNeedsALabel();
    }
}
