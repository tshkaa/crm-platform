using DirectoryService.Contracts.Locations;
using DirectoryService.Domain;
using FluentValidation;

namespace DirectoryService.Core.Locations;

public class CreateLocationValidator : AbstractValidator<CreateLocationRequest>
{
    public CreateLocationValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Название обязательно.")
            .MaximumLength(LengthConstants.Length100).WithMessage("Название слишком длинное.");

        RuleFor(x => x.Address.City)
            .NotEmpty().WithMessage("Город обязателен.")
            .MaximumLength(LengthConstants.Length100).WithMessage("Город слишком длинный.");
        
        RuleFor(x => x.Address.Street)
            .NotEmpty().WithMessage("Улица обязательна.")
            .MaximumLength(LengthConstants.Length100).WithMessage("Улица слишком длинная.");
        
        RuleFor(x => x.Address.Building)
            .NotEmpty().WithMessage("Дом обязателен.")
            .MaximumLength(LengthConstants.Length100).WithMessage("Дом слишком длинный.");
        
        RuleFor(x => x.Address.Apartment)
            .NotEmpty().WithMessage("Квартира обязательна.")
            .MaximumLength(LengthConstants.Length100).WithMessage("Квартира слишком длинная.");
    }
}