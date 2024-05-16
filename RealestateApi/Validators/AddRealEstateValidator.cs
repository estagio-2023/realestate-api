using FluentValidation;
using RealEstateApi.Dto.Request;
using RealEstateApi.Enums;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service.Interfaces;
using System.Xml;

namespace RealEstateApi.Validators
{
    public class AddRealEstateValidator : AbstractValidator<AddRealEstateRequestDto>
    {
        private readonly IReferenceDataService _referenceDataService;

        public AddRealEstateValidator(IReferenceDataService referenceDataService)
        {
            _referenceDataService = referenceDataService;

            RuleFor(x => x.Title)
                .NotEmpty()
                .Length(5, 100)
                .Matches("[A-Za-z]");
            RuleFor(x => x.Address)
                .NotEmpty()
                .Length(10, 200);
            RuleFor(x => x.ZipCode)
                .NotEmpty()
                .Length(4, 8);
            RuleFor(x => x.Description)
                .NotEmpty()
                .Length(5, 200);
            RuleFor(x => x.BuildDate)
                .NotEmpty();
            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
            RuleFor(x => x.SquareMeter)
                .NotEmpty()
                .GreaterThan(0).WithMessage("Square meter must be greater than 0.");
            RuleFor(x => x.EnergyClass)
                .NotEmpty()
                .MaximumLength(1);
            RuleFor(x => x.CustomerId)
                .NotEmpty();
            RuleFor(x => x.AgentId)
                .NotEmpty();
            RuleFor(x => x.RealEstateTypeId)
                .NotEmpty();
            RuleFor(x => x.CityId)
                .NotEmpty();
            RuleFor(x => x.TypologyId)
                .NotEmpty();                
        }        
    }
}