using FluentValidation;
using RealEstateApi.Dto.Request;

namespace RealEstateApi.Validators
{
    public class AddReferenceDataValidator : AbstractValidator<ReferenceDataRequestDto>
    {
        public AddReferenceDataValidator() 
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}
