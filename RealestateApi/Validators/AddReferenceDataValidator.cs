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
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.Description).MinimumLength(5).WithMessage("Description must be at least 5 characters long");
            RuleFor(x => x.Description).MaximumLength(50).WithMessage("Description must not exceed 50 characters");
        }
    }
}
