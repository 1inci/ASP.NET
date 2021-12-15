using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Models;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AspnetRun.Web.Services
{
    [ApiController]
    [Route("api/v1/warehouse")]
    public class WareHousePageService : IWareHousePageService
    {
        private readonly IWareHouseService _wareHouseAppService;
        private readonly IBuildingService _categoryAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<WareHousePageService> _logger;

        public WareHousePageService(IWareHouseService wareHouseAppService, IBuildingService categoryAppService, IMapper mapper, ILogger<WareHousePageService> logger)
        {
            
            _wareHouseAppService = wareHouseAppService ?? throw new ArgumentNullException(nameof(wareHouseAppService));
            _categoryAppService = categoryAppService ?? throw new ArgumentNullException(nameof(categoryAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("GetWareHouse")]
        public async Task<IEnumerable<WareHouseViewModel>> GetWareHouse(string wareHouseName)
        {
            if (string.IsNullOrWhiteSpace(wareHouseName))
            {
                var list = await _wareHouseAppService.GetWareHouseList();
                var mapped = _mapper.Map<IEnumerable<WareHouseViewModel>>(list);
                return mapped;
            }

            var listByName = await _wareHouseAppService.GetWareHouseByName(wareHouseName);
            var mappedByName = _mapper.Map<IEnumerable<WareHouseViewModel>>(listByName);
            return mappedByName;
        }

        [HttpGet("GetWareHouseById")]
        public async Task<WareHouseViewModel> GetWareHouseById(int wareHouseId)
        {
            var wareHouse = await _wareHouseAppService.GetWareHouseById(wareHouseId);
            var mapped = _mapper.Map<WareHouseViewModel>(wareHouse);
            return mapped;
        }

        [HttpGet("GetWareHouseByBuilding")]
        public async Task<IEnumerable<WareHouseViewModel>> GetWareHouseByBuilding(int buildingId)
        {
            var list = await _wareHouseAppService.GetWareHouseByBuilding(buildingId);
            var mapped = _mapper.Map<IEnumerable<WareHouseViewModel>>(list);
            return mapped;
        }
        [HttpGet("GetBuildings")]
        public async Task<IEnumerable<BuildingViewModel>> GetBuildings()
        {
            var list = await _categoryAppService.GetBuildingList();
            var mapped = _mapper.Map<IEnumerable<BuildingViewModel>>(list);
            return mapped;
        }

        [HttpGet("CreateWareHouse")]
        public async Task<WareHouseViewModel> CreateWareHouse(WareHouseViewModel wareHouseViewModel)
        {
            var mapped = _mapper.Map<WareHouseModel>(wareHouseViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            var entityDto = await _wareHouseAppService.Create(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");

            var mappedViewModel = _mapper.Map<WareHouseViewModel>(entityDto);
            return mappedViewModel;
        }

        [HttpGet("UpdateWareHouse")]
        public async Task UpdateWareHouse(WareHouseViewModel wareHouseViewModel)
        {
            var mapped = _mapper.Map<WareHouseModel>(wareHouseViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _wareHouseAppService.Update(mapped);
            _logger.LogInformation($"Entity successfully updated - IndexPageService");
        }

        [HttpGet("DeleteWareHouse")]
        public async Task DeleteWareHouse(WareHouseViewModel wareHouseViewModel)
        {
            var mapped = _mapper.Map<WareHouseModel>(wareHouseViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _wareHouseAppService.Delete(mapped);
            _logger.LogInformation($"Entity successfully deleted - IndexPageService");
        }
    }
}
