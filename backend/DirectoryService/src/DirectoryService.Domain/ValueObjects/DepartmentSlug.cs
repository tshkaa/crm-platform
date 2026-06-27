using System.Text.RegularExpressions;

namespace DirectoryService.Domain.ValueObjects;

public partial class DepartmentSlug
{
    public const int MinLength = 2;
    public const int MaxLength = 100;

    public DepartmentSlug(string value)
    {
#pragma warning disable CA1308 // Нормализуйте строки до прописных букв
        string normalized = value.Trim().ToLowerInvariant();
#pragma warning restore CA1308 // Нормализуйте строки до прописных букв

        if (normalized.Length < MinLength || normalized.Length > MaxLength)
        {
            throw new ArgumentException(
                $"Slug must be between {MinLength} and {MaxLength} characters", 
                nameof(value));
        }
        
        if (!SlugPattern().IsMatch(normalized))
        {
            throw new ArgumentException(
                "Slug must contain only lowercase letters, numbers, and hyphens", 
                nameof(value));
        }
        
        Value = normalized;
    }
    
    public string Value { get; }

    [GeneratedRegex(@"^[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$",
        RegexOptions.NonBacktracking, 1000)] // таймаут 1 секунда
    private static partial Regex SlugPattern();
}