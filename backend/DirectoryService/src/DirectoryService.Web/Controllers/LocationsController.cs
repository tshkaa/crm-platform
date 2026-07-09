using DirectoryService.Contracts.Locations;
using DirectoryService.Core.Locations;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Web.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class LocationsController : ControllerBase
{
    public readonly ILocationsService LocationsService;

    public LocationsController(ILocationsService locationsService)
    {
        LocationsService = locationsService;
    }

    [HttpPost]
    public async Task<ActionResult> Create(
        [FromBody] CreateLocationRequest request,
        CancellationToken cancellationToken
    )
    {
        var locationId = await LocationsService.Create(request, cancellationToken);
        
        return CreatedAtAction(nameof(GetById),
            new { locationId },
            new { locationId });
    }   

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<LocationResponse>>> Get(
        [FromQuery] GetLocationRequest request,
        CancellationToken cancellationToken
    )
    {
        var stub = new List<LocationResponse>();
        
        return Ok(stub);
    }

    [HttpGet("{locationId:guid}")]
    public async Task<ActionResult<LocationResponse>> GetById(
        [FromRoute] Guid locationId,
        CancellationToken cancellationToken
    )
    {
        return NotFound("Location not found");
    }

    [HttpPut("{locationId:guid}")]
    public async Task<ActionResult<LocationResponse>> Update(
        [FromRoute] Guid locationId,
        [FromBody] UpdateLocationRequest request,
        CancellationToken cancellationToken
    )
    {
        var stub = new LocationResponse(
            Guid.NewGuid(),
            request.Name,
            request.Address,
            DateTime.Now,
            DateTime.Now
        );
        
        return Ok(stub);
    }

    [HttpDelete("{locationId:guid}")]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid locationId,
        CancellationToken cancellationToken
    )
    {
        return NoContent();
    }
}