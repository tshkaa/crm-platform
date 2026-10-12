using DirectoryService.Contracts.Locations;
using DirectoryService.Domain.Locations;
using DirectoryService.Domain.ValueObjects;
using FluentValidation;

namespace DirectoryService.Core.Locations;

public class LocationsService : ILocationsService
{
    private readonly ILocationsRepository _locationsRepository;
    private readonly IValidator<CreateLocationRequest> _validator;

    public LocationsService(
        ILocationsRepository locationsRepository, 
        IValidator<CreateLocationRequest> validator)
    {
        _locationsRepository = locationsRepository;
        _validator = validator;
    }

    public async Task<Guid> Create(CreateLocationRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var requestResult = await _locationsRepository.NameIsUniqueAsync(request.Name, cancellationToken);
        
        if (!requestResult)
        {
            throw new ArgumentException($"Имя {request.Name} уже используется.", nameof(request));
        }
        
        var location = new Location
        (
            new Title(request.Name),
            new LocationAddress(request.Address.City, 
                request.Address.Street, 
                request.Address.Building, 
                request.Address.Apartment)
        );
        
        await _locationsRepository.AddAsync(location, cancellationToken);
        
        return location.Id;
    }
}