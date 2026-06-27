namespace DirectoryService.Domain.ValueObjects;

public record Title
{
    public Title(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) 
            throw new ArgumentException("Title cannot be null or whitespace.", nameof(value));
        Value = value;
    }

    public string Value { get; }
}