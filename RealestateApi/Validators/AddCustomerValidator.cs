﻿using FluentValidation;
using RealEstateApi.Dto.Request;


namespace RealEstateApi.Validators
{
    public class AddCustomerValidator : AbstractValidator<CustomerRequestDto>
    {
        public AddCustomerValidator()
        {
            RuleFor(x => x.Name).Length(5, 100).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Email).Length(8, 150).EmailAddress().NotEmpty().WithMessage("A valid email is required");
            RuleFor(x => x.Password).Length(5, 150).NotEmpty().WithMessage("Password is required.");
        }
    }
}