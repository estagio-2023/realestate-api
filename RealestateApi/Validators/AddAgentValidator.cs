using FluentValidation;
using RealEstateApi.Dto.Request;

namespace RealEstateApi.Validators
{
    public class AddAgentValidator: AbstractValidator<AgentRequestDto>
    {
        public AddAgentValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(5, 100).WithMessage("Name length must be between 5 and 100 characters.");
            RuleFor(x => x.Phone_Number)
                .NotEmpty().WithMessage("Phone number is required.")
                .Length(9, 13).WithMessage("Phone number length must be between 9 and 13 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .Length(8, 150).WithMessage("Email length must be between 8 and 150 characters")
                .EmailAddress().WithMessage("A valid email is required");
        }
    }
}
