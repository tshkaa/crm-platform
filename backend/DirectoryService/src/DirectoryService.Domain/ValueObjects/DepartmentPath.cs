namespace DirectoryService.Domain.ValueObjects;

public sealed record DepartmentPath
{
    public DepartmentPath(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Path cannot be null or whitespace.", nameof(value));

        var normalized = value.Trim();
        normalized = normalized.Trim('/');
        if (string.IsNullOrEmpty(normalized))
            throw new ArgumentException("Path must contain at least one segment.", nameof(value));

        var segments = normalized.Split('/');
        foreach (var s in segments)
        {
            _ = new DepartmentSlug(s);
        }

        Value = string.Join('/', segments);
    }

    public string Value { get; }

    public IReadOnlyList<string> Segments => Value.Split('/');

    public DepartmentPath Append(DepartmentSlug slug)
    {
         return new DepartmentPath(string.IsNullOrEmpty(Value) ? slug.Value : $"{Value}/{slug.Value}");
    }

    public override string ToString() => Value;
}