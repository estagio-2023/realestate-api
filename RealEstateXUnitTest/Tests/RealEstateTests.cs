using AutoMapper;
using AutoMapper.EquivalencyExpression;
using RealEstateApi.Dto.Request;
using RealEstateApi.Service;
using RealEstateApi.Service.Interfaces;
using RealEstateApiLibraryEF.Entity;

namespace RealEstateXUnitTest.Tests
{
    public class RealEstateTests
    {
        private readonly IMapper _mapper;
        private readonly RSFixture _fixture;

        public RealEstateTests()
        {
            _fixture = new RSFixture();
            _fixture.Initialize();
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
                cfg.AddCollectionMappers();
            }));
        }

        [Fact]
        public async Task ShouldAddRealEstate()
        {
            var realEstateService = GetInstance();

            var realestateData = new AddRealEstateRequestDto
            {
                Title = "Titleee",
                Address = "RUA tal e tal",
                ZipCode = "2950-486",
                Description = "Teste das cenas",
                BuildDate = 2021,
                Price = 125,
                SquareMeter = 7,
                EnergyClass = "A",
                CustomerId = 3,
                RealEstateTypeId = 11,
                CityId = 39,
                TypologyId = 13
            };

            var result = await realEstateService.AddRealEstateAsync(realestateData);

            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Result);
            Assert.Equal("Titleee", result.Result.Title);

            var savedRealEstate = await _fixture.DbContext.RealEstates.FindAsync(result.Result.Id);
            Assert.NotNull(savedRealEstate);
            Assert.Equal("Titleee", savedRealEstate.Title);
        }

        [Fact]
        public async Task ShouldGetAllRealEstates()
        {
            var realestateService = GetInstance();

            _fixture.DbContext.RealEstates.Add(new RealEstate
            {
                Title = "John Doe",
                Address = "RUA tal e tal",
                ZipCode = "2950-486",
                Description = "Teste das cenas",
                BuildDate = 2021,
                Price = 125,
                SquareMeter = 7,
                EnergyClass = "A",
                CustomerId = 1,
                RealEstateTypeId = 1,
                CityId = 1,
                TypologyId = 1
            });

            _fixture.DbContext.RealEstates.Add(new RealEstate 
            { 
                Title = "Lebron James",
                Address = "RUA tal e tal", 
                ZipCode = "2950-486",
                Description = "Teste das cenas",
                BuildDate = 2021,
                Price = 125,
                SquareMeter = 7, 
                EnergyClass = "A",
                CustomerId = 1, 
                RealEstateTypeId = 1,
                CityId = 1, 
                TypologyId = 1 
            });

            await _fixture.DbContext.SaveChangesAsync();

            var result = await realestateService.GetAllRealEstateAsync();

            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Result.Count);
            Assert.Contains(result.Result, realestate => realestate.Title == "John Doe");
            Assert.Contains(result.Result, realestate => realestate.Title == "Lebron James");
        }

        [Fact]
        public async Task ShouldGetRealEstateById()
        {
            var realestateService = GetInstance();

            var realestate = new RealEstate
            {
                Title = "Lebron James",
                Address = "RUA tal e tal",
                ZipCode = "2950-486",
                Description = "Teste das cenas",
                BuildDate = 2021,
                Price = 125,
                SquareMeter = 7,
                EnergyClass = "A",
                CustomerId = 1,
                RealEstateTypeId = 1,
                CityId = 1,
                TypologyId = 1
            };
            _fixture.DbContext.RealEstates.Add(realestate);
            await _fixture.DbContext.SaveChangesAsync();

            var result = await realestateService.GetRealEstateByIdAsync(realestate.Id);

            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Result);
            Assert.Equal("Lebron James", result.Result.Title);
        }

        [Fact]
        public async Task ShouldDeleteRealEstate()
        {
            var realestateService = GetInstance();

            var realestate = new RealEstate
            {
                Title = "Lebron James",
                Address = "RUA tal e tal",
                ZipCode = "2950-486",
                Description = "Teste das cenas",
                BuildDate = 2021,
                Price = 125,
                SquareMeter = 7,
                EnergyClass = "A",
                CustomerId = 1,
                RealEstateTypeId = 1,
                CityId = 1,
                TypologyId = 1
            };
            _fixture.DbContext.RealEstates.Add(realestate);
            await _fixture.DbContext.SaveChangesAsync();

            var result = await realestateService.DeleteRealEstateByIdAsync(realestate.Id);

            Assert.True(result.IsSuccess);

            var deletedRealEstate = await _fixture.DbContext.RealEstates.FindAsync(realestate.Id);
            Assert.Null(deletedRealEstate);
        }

        private IRealEstateService GetInstance()
        {
            return new RealEstateService(_fixture.DbContext, _mapper);
        }
    }
}