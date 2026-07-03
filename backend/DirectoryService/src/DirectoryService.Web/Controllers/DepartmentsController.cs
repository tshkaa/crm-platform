using DirectoryService.Contracts;
using DirectoryService.Contracts.Departments;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Web.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class DepartmentsController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<DepartmentResponse>> Create(
        [FromBody] CreateDepartmentRequest request,
        CancellationToken cancellationToken
        )
    {
        var stub = new DepartmentResponse(
            Guid.NewGuid(),
            request.Name,
            request.Slug,
            request.Path,
            null,
            DateTime.Now,
            DateTime.Now
        );
        
        return CreatedAtAction(nameof(GetById), new { departmentId = stub.Id }, stub);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<DepartmentResponse>>> Get(
        [FromQuery] GetDepartmentRequest request,
        CancellationToken cancellationToken
        )
    {
        var stub = new List<DepartmentResponse>();
        
        return Ok(stub);
    }

    [HttpGet("{departmentId:guid}")]
    public async Task<IActionResult> GetById(
        [FromRoute] Guid departmentId,
        CancellationToken cancellationToken
        )
    {
        return NotFound("Department not found");
    }

    [HttpPut("{departmentId:guid}")]
    public async Task<ActionResult<DepartmentResponse>> Update(
        [FromRoute] Guid departmentId,
        [FromBody] UpdateDepartmentRequest request,
        CancellationToken cancellationToken
        )
    {
        var stub = new DepartmentResponse(
            Guid.NewGuid(),
            request.Name,
            request.Slug,
            request.Path,
            null,
            DateTime.Now,
            DateTime.Now
        );
        
        return Ok(stub);
    }

    [HttpDelete("{departmentId:guid}")]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid departmentId,
        CancellationToken cancellationToken
        )
    {
        return NoContent();
    }
}