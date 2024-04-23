﻿using RealEstateApi.Dto.Request;
using RealEstateApi.Model;
using RealEstateApi.Repository.Interfaces;
using RealEstateApi.Service.Interfaces;

namespace RealEstateApi.Service
{
    public class RealEstateService : IRealEstateService
    {
        private readonly IRealEstateRepository _realEstateRepository;

        public RealEstateService(IRealEstateRepository realEstateRepository)
        {
            _realEstateRepository = realEstateRepository;
        }

        public async Task<List<RealEstateModel>> GetAllRealEstateAsync()
        {
            return await _realEstateRepository.GetAllRealEstateAsync();
        }
        public async Task<RealEstateModel> AddRealEstateAsync(AddRealEstateRequestDto realEstateDto)
        {
            RealEstateModel response = new();

            if (realEstateDto != null)
            {
                response = await _realEstateRepository.AddRealEstateAsync(realEstateDto);
            }
            return response;
        }
    }
}