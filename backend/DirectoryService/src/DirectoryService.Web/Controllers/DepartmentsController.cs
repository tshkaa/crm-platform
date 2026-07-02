using DirectoryService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Web.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class DepartmentsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateDepartmentRequest request,
        CancellationToken cancellationToken
        )
    {
        return Ok("Department created successfully");
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] GetDepartmentRequest request,
        CancellationToken cancellationToken
        )
    {
        return Ok("Get all departments");
    }

    [HttpGet("{departmentId:guid}")]
    public async Task<IActionResult> GetById(
        [FromRoute] Guid departmentId,
        CancellationToken cancellationToken
        )
    {
        return Ok($"Get chosen department");
    }
    
    [HttpPut("{departmentId:guid}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid departmentId,
        [FromBody] UpdateDepartmentRequest request,
        CancellationToken cancellationToken
        )
    {
        return Ok($"Department updated successfully");
    }
    
    [HttpDelete("{departmentId:guid}")]
    public async Task<IActionResult> Delete(
        [FromRoute] Guid departmentId,
        CancellationToken cancellationToken
        )
    {
        return Ok("Department deleted successfully");
    }
}