namespace DirectoryService.Domain.ValueObjects;

public record LocationAddress
{
    public LocationAddress(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) 
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
        Value = value;
    }
    
    public string Value { get; }
}