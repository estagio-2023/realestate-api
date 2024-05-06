using FluentValidation;
using RealEstateApi.Dto.Request;
using RealEstateApi.Repository.Interfaces;
using System.Xml;

namespace RealEstateApi.Validators
{
    public class AddRealEstateValidator : AbstractValidator<AddRealEstateRequestDto>
    {
        private readonly IReferenceDataRepository _referenceDataRepository;

        public AddRealEstateValidator(IReferenceDataRepository referenceDataRepository)
        {
            _referenceDataRepository = referenceDataRepository;

            RuleFor(x => x.Title).NotEmpty().Length(5, 100).Matches("[A-Za-z]").WithMessage("Title is required.");
            RuleFor(x => x.Address).NotEmpty().Length(10, 200).WithMessage("A valid adress is required.");
            RuleFor(x => x.ZipCode).NotEmpty().Length(4, 8).WithMessage("A valid zip code is required.");
            RuleFor(x => x.Description).NotEmpty().Length(5, 200).WithMessage("A valid description is required.");
            RuleFor(x => x.Build_Date).NotEmpty();
            RuleFor(x => x.Price).NotEmpty().GreaterThan(0).WithMessage("A valid price is required.");
            RuleFor(x => x.SquareMeter).NotEmpty().GreaterThan(0).WithMessage("A valid square meter value is required.");
            RuleFor(x => x.EnergyClass).NotEmpty().MaximumLength(1).WithMessage("Energy Class is required.");
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.AgentId).NotEmpty();
            RuleFor(x => x.RealEstateTypeId).NotEmpty().MustAsync(async (dto, realestateId) => await realEstateTypeIdInRefDataValidation("realestate", realestateId)).WithMessage("RealEstate ID is not valid.");
            RuleFor(x => x.CityId).NotEmpty().MustAsync(async (dto, cityId) => await cityIdInRefDataValidation("city", cityId)).WithMessage("City ID is not valid.");
            RuleFor(x => x.TypologyId).NotEmpty().MustAsync(async (dto, typologyId) => await typologyIdInRefDataValidation("typology", typologyId)).WithMessage("Typology ID is not valid.");
        }

        public async Task<bool> realEstateTypeIdInRefDataValidation(string refDataType, int refDataId)
        {
            var realEstateType = await _referenceDataRepository.GetRealEstateReferenceDataAsync(refDataType, refDataId);

            return realEstateType.Result.Id != 0;
        }

        public async Task<bool> cityIdInRefDataValidation(string refDataType, int refDataId)
        {
            var city = await _referenceDataRepository.GetCityReferenceDataAsync(refDataType, refDataId);

            return city.Result.Id != 0;
        }

        public async Task<bool> typologyIdInRefDataValidation(string refDataType, int refDataId)
        {
            var typology = await _referenceDataRepository.GetTypologyReferenceDataAsync(refDataType, refDataId);

            return typology.Result.Id != 0;
        }
    }
}