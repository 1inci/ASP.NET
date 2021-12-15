using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Models;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Web.Services
{
    [ApiController]
    [Route("api/v1/building")]
    public class BuildingPageService : IBuildingPageService
    {
        private readonly IBuildingService _buildingAppService;
        private readonly IRoomService _roomAppService;
        private readonly IWareHouseService _wareHouseAppService;
        private readonly ILogger<BuildingPageService> _logger;
        private readonly IMapper _mapper;

        public BuildingPageService(IBuildingService buildingAppService, IMapper mapper, ILogger<BuildingPageService> logger, IRoomService roomAppService, IWareHouseService wareHouseAppService)
        {
            _buildingAppService = buildingAppService ?? throw new ArgumentNullException(nameof(buildingAppService));
            _roomAppService = roomAppService ?? throw new ArgumentNullException(nameof(roomAppService));
            _wareHouseAppService = wareHouseAppService ?? throw new ArgumentNullException(nameof(wareHouseAppService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("GetBuildings")]
        public async Task<IEnumerable<BuildingViewModel>> GetBuildings()
        {
            var list = await _buildingAppService.GetBuildingList();
            var mapped = _mapper.Map<IEnumerable<BuildingViewModel>>(list);
            return mapped;
        }

        [HttpGet("GetBuildingById")]
        public async Task<BuildingViewModel> GetBuildingById(int buildingId)
        {
            var room = await _buildingAppService.GetBuildingById(buildingId);
            var mapped = _mapper.Map<BuildingViewModel>(room);
            return mapped;
        }

        [HttpPost("CreateBuilding")]
        public async Task<BuildingViewModel> CreateBuilding(BuildingViewModel buildingViewModel)
        {
            var mapped = _mapper.Map<BuildingModel>(buildingViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            var entityDto = await _buildingAppService.Create(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");

            var mappedViewModel = _mapper.Map<BuildingViewModel>(entityDto);
            return mappedViewModel;
        }

        [HttpPost("UpdateBuilding")]
        public async Task UpdateBuilding(BuildingViewModel buildingViewModel)
        {
            var mapped = _mapper.Map<BuildingModel>(buildingViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _buildingAppService.Update(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }

        [HttpDelete("DeleteBuilding")]
        public async Task DeleteBuilding(BuildingViewModel buildingViewModel)
        {
            var mapped = _mapper.Map<BuildingModel>(buildingViewModel);
                        
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _buildingAppService.Delete(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }

       
    }
}
