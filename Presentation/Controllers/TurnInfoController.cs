using Contracts.Requests;
using Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

public class TurnInfoController : ControllerBase
{
    private readonly IServiceWrapper _service;

    public TurnInfoController(IServiceWrapper service) =>
        _service = service;

    [HttpPost]
    public async Task<IActionResult> TurnAsync(GameTurnRequest gameTurnRequest, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _service.TurnInfoService.AddTurnAsync(gameTurnRequest, cancellationToken);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new ErrorResponse { error = ex.Message });
        }
    }
}