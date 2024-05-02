using FluentValidation;
using RealEstateApi.Dto.Request;
namespace RealEstateApi.Validators
{
    public class DeleteRefDataValidator : AbstractValidator<DeleteRefDataRequestDto>
    {
        public DeleteRefDataValidator() 
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("refDataId is required.");
                
        }
    }
}