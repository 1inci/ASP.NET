using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Models;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Web.Services
{
    [ApiController]
    [Route("api/v1/room")]
    public class RoomPageService : IRoomPageService

    {
        private readonly IRoomService _roomAppService;
        private readonly IBuildingService _buildingAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<RoomPageService> _logger;

        public RoomPageService(IRoomService roomAppService, IBuildingService buildingAppService, IMapper mapper, ILogger<RoomPageService> logger)
        {
            _roomAppService = roomAppService ?? throw new ArgumentNullException(nameof(roomAppService));
            _buildingAppService = buildingAppService ?? throw new ArgumentNullException(nameof(buildingAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("GetRoom")]
        public async Task<IEnumerable<RoomViewModel>> GetRoom(string roomName)
        {
            if (string.IsNullOrWhiteSpace(roomName))
            {
                var list = await _roomAppService.GetRoomList();
                var mapped = _mapper.Map<IEnumerable<RoomViewModel>>(list);
                return mapped;
            }

            var listByName = await _roomAppService.GetRoomByName(roomName);
            var mappedByName = _mapper.Map<IEnumerable<RoomViewModel>>(listByName);
            return mappedByName;
        }

        [HttpGet("GetRoomById")]
        public async Task<RoomViewModel> GetRoomById(int roomId)
        {
            var room = await _roomAppService.GetRoomById(roomId);
            var mapped = _mapper.Map<RoomViewModel>(room);
            return mapped;
        }

        [HttpGet("GetRoomByBuilding")]
        public async Task<IEnumerable<RoomViewModel>> GetRoomByBuilding(int buildingId)
        {
            var list = await _roomAppService.GetRoomByBuilding(buildingId);
            var mapped = _mapper.Map<IEnumerable<RoomViewModel>>(list);
            return mapped;
        }

        [HttpGet("GetBuildings")]
        public async Task<IEnumerable<BuildingViewModel>> GetBuildings()
        {
            var list = await _buildingAppService.GetBuildingList();
            var mapped = _mapper.Map<IEnumerable<BuildingViewModel>>(list);
            return mapped;
        }

        [HttpPost("CreateRoom")]
        public async Task<RoomViewModel> CreateRoom(RoomViewModel roomViewModel)
        {
            var mapped = _mapper.Map<RoomModel>(roomViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            var entityDto = await _roomAppService.Create(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");

            var mappedViewModel = _mapper.Map<RoomViewModel>(entityDto);
            return mappedViewModel;
        }

        [HttpPost("UpdateRoom")]
        public async Task UpdateRoom(RoomViewModel roomViewModel)
        {
            var mapped = _mapper.Map<RoomModel>(roomViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _roomAppService.Update(mapped);
            _logger.LogInformation($"Entity successfully updated - IndexPageService");
        }

        [HttpPost("DeleteRoom")]
        public async Task DeleteRoom(RoomViewModel roomViewModel)
        {
            var mapped = _mapper.Map<RoomModel>(roomViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _roomAppService.Delete(mapped);
            _logger.LogInformation($"Entity successfully deleted - IndexPageService");
        }

       

    }
}
