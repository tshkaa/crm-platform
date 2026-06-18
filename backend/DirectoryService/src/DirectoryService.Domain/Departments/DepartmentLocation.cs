namespace DirectoryService.Domain.Departments;

public sealed class DepartmentLocation
{
    public DepartmentLocation(Guid departmentId, Guid locationId, bool isPrimary)
    {
        if (departmentId == Guid.Empty)
            throw new ArgumentException("Department ID cannot be empty.", nameof(departmentId));
        if (locationId == Guid.Empty)
            throw new ArgumentException("Location ID cannot be empty.", nameof(locationId));
        
        Id = Guid.CreateVersion7();
        DepartmentId = departmentId;
        LocationId = locationId;
        IsPrimary = isPrimary;
    }
    
    public Guid Id { get; private set; }
    
    public Guid DepartmentId { get; private set; }
    
    public Guid LocationId { get; private set; }
    
    public bool IsPrimary { get; private set; }
    
    private void SetPrimaryStatus(bool isPrimary) => IsPrimary = isPrimary;

    public void SetAsPrimary(IEnumerable<DepartmentLocation> departmentLocations)
    {
        foreach (var l in departmentLocations)
            if (l != this && l.DepartmentId == DepartmentId)
                l.SetPrimaryStatus(false);
        SetPrimaryStatus(true);
    }
}