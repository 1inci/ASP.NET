using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using AspnetRun.Core.Repositories;
using AspnetRun.Application.Models;
using AspnetRun.Application.Mapper;
using AspnetRun.Application.Interfaces;

namespace AspnetRun.Application.Services
{
    // TODO : add validation , authorization, logging, exception handling etc. -- cross cutting activities in here.
    public class WareHouseService : IWareHouseService
    {
        private readonly IWareHouseRepository _wareHouseRepository;
        private readonly IAppLogger<WareHouseService> _logger;

        public WareHouseService(IWareHouseRepository wareHouseRepository, IAppLogger<WareHouseService> logger)
        {
            _wareHouseRepository = wareHouseRepository ?? throw new ArgumentNullException(nameof(wareHouseRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<WareHouseModel>> GetWareHouseList()
        {
            var wareHousetList = await _wareHouseRepository.GetWareHouseListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<WareHouseModel>>(wareHousetList);
            return mapped;
        }

        public async Task<WareHouseModel> GetWareHouseById(int wareHouseId)
        {
            var wareHouse = await _wareHouseRepository.GetByIdAsync(wareHouseId);
            var mapped = ObjectMapper.Mapper.Map<WareHouseModel>(wareHouse);
            return mapped;
        }

        public async Task<IEnumerable<WareHouseModel>> GetWareHouseByName(string wareHouseName)
        {
            var wareHouseList = await _wareHouseRepository.GetWareHouseByNameAsync(wareHouseName);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<WareHouseModel>>(wareHouseList);
            return mapped;
        }

        
        public async Task<IEnumerable<BuildingModel>> GetWareHouseByBuilding(int buildingId)
        {
            var wareHouseList = await _wareHouseRepository.GetWareHouseByBuildingAsync(buildingId);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<BuildingModel>>(wareHouseList);
            return mapped;
        }

        public async Task<WareHouseModel> Create(WareHouseModel wareHouseModel)
        {
            await ValidateWareHouseIfExist(wareHouseModel);

            var mappedEntity = ObjectMapper.Mapper.Map<WareHouse>(wareHouseModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _wareHouseRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<WareHouseModel>(newEntity);
            return newMappedEntity;
        }

        public async Task Update(WareHouseModel wareHouseModel)
        {
            ValidateWareHouseIfNotExist(wareHouseModel);

            var editWareHouse = await _wareHouseRepository.GetByIdAsync(wareHouseModel.Id);
            if (editWareHouse == null)
                throw new ApplicationException($"Entity could not be loaded.");

            ObjectMapper.Mapper.Map<WareHouseModel, WareHouse>(wareHouseModel, editWareHouse);

            await _wareHouseRepository.UpdateAsync(editWareHouse);
            _logger.LogInformation($"Entity successfully updated - AspnetRunAppService");
        }

        public async Task Delete(WareHouseModel wareHouseModel)
        {
            ValidateWareHouseIfNotExist(wareHouseModel);
            var deletedWareHouse = await _wareHouseRepository.GetByIdAsync(wareHouseModel.Id);
            if (deletedWareHouse == null)
                throw new ApplicationException($"Entity could not be loaded.");

            await _wareHouseRepository.DeleteAsync(deletedWareHouse);
            _logger.LogInformation($"Entity successfully deleted - AspnetRunAppService");
        }

        private async Task ValidateWareHouseIfExist(WareHouseModel wareHouseModel)
        {
            var existingEntity = await _wareHouseRepository.GetByIdAsync(wareHouseModel.Id);
            if (existingEntity != null)
                throw new ApplicationException($"{wareHouseModel.ToString()} with this id already exists");
        }

        private void ValidateWareHouseIfNotExist(WareHouseModel wareHouseModel)
        {
            var existingEntity = _wareHouseRepository.GetByIdAsync(wareHouseModel.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{wareHouseModel.ToString()} with this id is not exists");
        }

    }
}
