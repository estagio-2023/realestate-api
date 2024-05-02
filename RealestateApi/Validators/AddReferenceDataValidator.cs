using FluentValidation;
using RealEstateApi.Dto.Request;
using RealEstateApi.Enums;
using RealEstateApi.Model;

namespace RealEstateApi.Validators
{
    public class AddReferenceDataValidator : AbstractValidator<ReferenceDataRequestDto>
    {
        public AddReferenceDataValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .Length(2,50).WithMessage("Description length must be between 2 and 50 characters");
        }
    }
}
