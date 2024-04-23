using FluentValidation;
using RealEstateApi.Dto.Request;

namespace RealEstateApi.Validators
{
    public class AddReferenceDataValidator : AbstractValidator<ReferenceDataRequestDto>
    {
        public AddReferenceDataValidator() 
        {
            RuleFor(x => x.Description).NotNull().WithMessage("This is a test");
            
        }
    }
}
