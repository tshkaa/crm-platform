using DirectoryService.Contracts.Positions;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Web.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class PositionsController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<PositionResponse>> Post(
        [FromBody] CreatePositionRequest request,
        CancellationToken cancellationToken
        )
    {
        var stub = new PositionResponse(
            Guid.NewGuid(),
            request.Name,
            DateTime.Now,
            DateTime.Now
            );
        
        return CreatedAtAction(nameof(GetById), new { positionId = stub.Id }, stub);
    }
    
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<PositionResponse>>> Get(
        [FromQuery] GetPositionRequest request,
        CancellationToken cancellationToken
        )
    {
        var stub = new List<PositionResponse>();
            
        return Ok(stub);
    }
    
    [HttpGet("{positionId:guid}")]
    public async Task<ActionResult<PositionResponse>> GetById(
        [FromRoute] Guid positionId,
        CancellationToken cancellationToken
    )
    {
        return NotFound("Position not found");
    }
    
    [HttpPut("{positionId:guid}")]
    public async Task<ActionResult<PositionResponse>> Update(
        [FromRoute] Guid positionId,
        [FromBody] UpdatePositionRequest request,
        CancellationToken cancellationToken
    )
    {
        var stub = new PositionResponse(
            Guid.NewGuid(),
            request.Name,
            DateTime.Now,
            DateTime.Now
        );
        
        return Ok(stub);
    }
    
    [HttpDelete("{positionId:guid}")]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid positionId,
        CancellationToken cancellationToken
    )
    {
        return NoContent();
    }
}