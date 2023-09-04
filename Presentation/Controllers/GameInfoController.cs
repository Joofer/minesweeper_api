using Contracts.Requests;
using Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers;

[Route("/")]
[ApiController]
public class GameInfoController : ControllerBase
{
    private readonly IServiceWrapper _service;

    public GameInfoController(IServiceWrapper service) =>
        _service = service;

    [HttpPost("new")]
    public async Task<IActionResult> NewAsync(NewGameRequest newGameRequest, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _service.GameInfoService.CreateGameAsync(newGameRequest, cancellationToken);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new ErrorResponse { error = ex.Message });
        }
    }
}