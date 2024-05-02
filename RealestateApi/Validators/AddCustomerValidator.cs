using FluentValidation;
using RealEstateApi.Dto.Request;


namespace RealEstateApi.Validators
{
    public class AddCustomerValidator : AbstractValidator<CustomerRequestDto>
    {
        public AddCustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(5, 100).WithMessage("Name is required.");
            RuleFor(x => x.Email).NotEmpty().Length(8, 150).EmailAddress().WithMessage("A valid email is required");
            RuleFor(x => x.Password).NotEmpty().Length(5, 150).WithMessage("Password is required.");
        }
    }
}