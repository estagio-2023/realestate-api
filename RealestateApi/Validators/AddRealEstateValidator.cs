using FluentValidation;
using RealEstateApi.Dto.Request;
using RealEstateApi.Enums;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service.Interfaces;
using System.Xml;

namespace RealEstateApi.Validators
{
    public class AddRealEstateValidator : AbstractValidator<AddRealEstateRequestDto>
    {
        private readonly IReferenceDataService _referenceDataService;

        public AddRealEstateValidator(IReferenceDataService referenceDataService)
        {
            _referenceDataService = referenceDataService;

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(5, 100).WithMessage("Title length must be between 5 and 100 characters.")
                .Matches("[A-Za-z]").WithMessage("Title must contain only letters.");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adress is required.")
                .Length(10, 200).WithMessage("Address length must be between 10 and 200 characters.");
            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("Zip code is required.")
                .Length(4, 8).WithMessage("Zip code length must be between 4 and 8 characters.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .Length(5, 200).WithMessage("Description length must be between 5 and 200 characters.");
            RuleFor(x => x.Build_Date)
                .NotEmpty().WithMessage("Build date is required.");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required.")
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
            RuleFor(x => x.SquareMeter)
                .NotEmpty().WithMessage("Square meter value is required.")
                .GreaterThan(0).WithMessage("Square meter must be greater than 0.");
            RuleFor(x => x.EnergyClass)
                .NotEmpty().WithMessage("Energy class is required.")
                .MaximumLength(1).WithMessage("Energy class length must be 1.");
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer id is required.");
            RuleFor(x => x.AgentId)
                .NotEmpty().WithMessage("Agent id is required.");
            RuleFor(x => x.RealEstateTypeId)
                .NotEmpty().WithMessage("RealEstate type id is required.");
                //.Must((dto, realestateId) => ExistInRefData(RefDataEnum.realestate_type.ToString(), realestateId)).WithMessage("RealEstate id is not valid.");
            RuleFor(x => x.CityId)
                .NotEmpty().WithMessage("City id is required.");
                //.Must((dto, cityId) => ExistInRefData(RefDataEnum.city.ToString(), cityId)).WithMessage("City id is not valid.");
            RuleFor(x => x.TypologyId)
                .NotEmpty().WithMessage("Typology id is required.")
                .Must((dto, typologyId) => ExistInRefData(RefDataEnum.typology.ToString(), typologyId)).WithMessage("Typology id is not valid.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refDataType"></param>
        /// <param name="refDataId"></param>
        /// <returns></returns>
        public bool ExistInRefData(string refDataType, int refDataId)
        {
            var referenceData = _referenceDataService.GetReferenceDataByIdAsync(refDataType, refDataId);
            // var test2 = referenceData.Id;

            return referenceData != null;
        }
    }
}