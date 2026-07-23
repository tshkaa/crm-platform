namespace DirectoryService.Domain.ValueObjects;

public record LocationAddress
{
    public LocationAddress(string city, string street, string building,  string apartment = "")
    {
        if (string.IsNullOrWhiteSpace(city)) 
            throw new ArgumentException("City cannot be null or whitespace.", nameof(city));
        City = city;
        
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street cannot be null or whitespace.", nameof(street));
        Street = street;
        
        if (string.IsNullOrWhiteSpace(building))
            throw new ArgumentException("Building cannot be null or whitespace.", nameof(building));
        Building = building;
        
        Apartment = apartment;
    }
    
    public string City { get; }
    
    public string Street { get; }
    
    public string Building { get; }

    public string Apartment { get; }
}