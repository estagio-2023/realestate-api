using FluentValidation;
using RealEstateApi.Dto.Request;

namespace RealEstateApi.Validators
{
    public class AddCustomerValidator : AbstractValidator<CustomerRequestDto>
    {
        public AddCustomerValidator()
        {
            RuleFor(x => x.Name).Length(5, 100);
            RuleFor(x => x.Email).Length(8, 150).EmailAddress();
            RuleFor(x => x.Password).Length(5, 150);
        }
    }
}