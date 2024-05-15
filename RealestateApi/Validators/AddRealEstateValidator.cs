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
                .NotEmpty()
                .Length(5, 100).WithMessage("Title length must be between 5 and 100 characters.")
                .Matches("[A-Za-z]").WithMessage("Title must contain only letters.");
            RuleFor(x => x.Address)
                .NotEmpty()
                .Length(10, 200).WithMessage("Address length must be between 10 and 200 characters.");
            RuleFor(x => x.ZipCode)
                .NotEmpty()
                .Length(4, 8).WithMessage("Zip code length must be between 4 and 8 characters.");
            RuleFor(x => x.Description)
                .NotEmpty()
                .Length(5, 200).WithMessage("Description length must be between 5 and 200 characters.");
            RuleFor(x => x.BuildDate)
                .NotEmpty();
            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
            RuleFor(x => x.SquareMeter)
                .NotEmpty()
                .GreaterThan(0).WithMessage("Square meter must be greater than 0.");
            RuleFor(x => x.EnergyClass)
                .NotEmpty()
                .MaximumLength(1).WithMessage("Energy class length must be 1.");
            RuleFor(x => x.CustomerId)
                .NotEmpty();
            RuleFor(x => x.AgentId)
                .NotEmpty();
            RuleFor(x => x.RealEstateTypeId)
                .NotEmpty()
                .Must((dto, realestateId) => ExistInRefData(RefDataEnum.realestate_type.ToString(), realestateId)).WithMessage("RealEstate id is not valid.");
            RuleFor(x => x.CityId)
                .NotEmpty()
                .Must((dto, cityId) => ExistInRefData(RefDataEnum.city.ToString(), cityId)).WithMessage("City id is not valid.");
            RuleFor(x => x.TypologyId)
                .NotEmpty()
                .Must((dto, typologyId) => ExistInRefData(RefDataEnum.typology.ToString(), typologyId)).WithMessage("Typology id is not valid.");
        }

        /// <summary>
        /// 
        /// Validate if reference data id exists in RefData
        /// 
        /// </summary>
        /// <param name="refDataType"> Reference Data Type </param>
        /// <param name="refDataId"> Reference Data Id </param>
        /// <returns> True/false if reference data exists or not in RefData </returns>
        private bool ExistInRefData(string refDataType, int refDataId)
        {
            return _referenceDataService.GetReferenceDataByIdAsync(refDataType, refDataId).Result.IsSuccess == true;
        }
    }
}