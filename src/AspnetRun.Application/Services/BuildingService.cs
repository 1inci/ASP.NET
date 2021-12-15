using AspnetRun.Application.Mapper;
using AspnetRun.Application.Interfaces;
using AspnetRun.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRun.Core.Repositories;
using AspnetRun.Application.Models;
using System.Threading;
using AspnetRun.Core.Entities;

namespace AspnetRun.Application.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IAppLogger<BuildingService> _logger;

        public BuildingService(IBuildingRepository categoryRepository, IAppLogger<BuildingService> logger)
        {
            
            _buildingRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<BuildingModel>> GetBuildingList()
        {
            var building = await _buildingRepository.GetAllAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<BuildingModel>>(building);
            return mapped;
        }

        public async Task<BuildingModel> Create(BuildingModel buildingModel)
        {
                        var mappedEntity = ObjectMapper.Mapper.Map<Building>(buildingModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _buildingRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<BuildingModel>(newEntity);
            return newMappedEntity;
        }

        public async Task Update(BuildingModel buildingModel)
        {
            
            var editBuilding = await _buildingRepository.GetByIdAsync(buildingModel.Id);
            if (editBuilding == null)
                throw new ApplicationException($"Entity could not be loaded.");

            ObjectMapper.Mapper.Map<BuildingModel, Building>(buildingModel, editBuilding);

            await _buildingRepository.UpdateAsync(editBuilding);
            _logger.LogInformation($"Entity successfully updated - AspnetRunAppService");
        }

        public async Task Delete(BuildingModel buildingModel)
        {
            
            var deletedBuilding = await _buildingRepository.GetByIdAsync(buildingModel.Id);
            if (deletedBuilding == null)
                throw new ApplicationException($"Entity could not be loaded.");

            await _buildingRepository.DeleteAsync(deletedBuilding);
            _logger.LogInformation($"Entity successfully deleted - AspnetRunAppService");
        }

        public async Task<BuildingModel> GetBuildingById(int buildingId)
        {
            var building = await _buildingRepository.GetByIdAsync(buildingId);
            var mapped = ObjectMapper.Mapper.Map<BuildingModel>(building);
            return mapped;
        }



    }
}
