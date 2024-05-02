using FluentValidation;
using RealEstateApi.Dto.Request;

namespace RealEstateApi.Validators
{
    public class AddRealEstateValidator : AbstractValidator<AddRealEstateRequestDto>
    {
        public AddRealEstateValidator()
        {
            RuleFor(x => x.Title).Length(5, 100).Matches("[A-Za-z]").WithMessage("Title is required.");
            RuleFor(x => x.Address).Length(10, 200).WithMessage("A valid adress is required.");
            RuleFor(x => x.ZipCode).Length(4, 8).WithMessage("A valid zip code is required.");
            RuleFor(x => x.Description).Length(5, 200).WithMessage("A valid description is required.");
            RuleFor(x => x.Build_Date);
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("A valid price is required.");
            RuleFor(x => x.SquareMeter).GreaterThan(0).WithMessage("A valid square meter value is required.");
            RuleFor(x => x.EnergyClass).MaximumLength(1).WithMessage("Energy Class is required.");
            RuleFor(x => x.CustomerId);
            RuleFor(x => x.AgentId);
            RuleFor(x => x.RealEstateTypeId);
            RuleFor(x => x.CityId);
            RuleFor(x => x.TypologyId);
        }

        /* private bool ExistsInRefData(string RealEstateTypeId, string cityId, string typologyId)
        {
        } */
    }
}