namespace DirectoryService.Domain;

public sealed class DepartmentPosition
{
    public DepartmentPosition(Guid departmentId, Guid positionId)
    {
        Id = Guid.CreateVersion7();
        DepartmentId = departmentId;
        PositionId = positionId;
    }
    
    public Guid Id { get; private set; }
    
    public Guid DepartmentId { get; private set; }
    
    public Guid PositionId { get; private set; }
    
}