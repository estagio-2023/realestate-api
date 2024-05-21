using FluentValidation;
using RealEstateApi.Dto.Request;

namespace RealEstateApi.Validators
{
    public class AddAgentValidator: AbstractValidator<AgentRequestDto>
    {
        public AddAgentValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(5, 100);
            RuleFor(x => x.Phone_Number)
                .NotEmpty()
                .Matches("[0-9]").WithMessage("Phone number must contain only numbers.")
                .Length(9, 13);
            RuleFor(x => x.Email)
                .NotEmpty()
                .Length(8, 150)
                .EmailAddress();
        }
    }
}
