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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IAppLogger<RoomService> _logger;

        public RoomService(IRoomRepository roomRepository, IAppLogger<RoomService> logger)
        {
            _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<RoomModel>> GetRoomList()
        {
            var roomtList = await _roomRepository.GetRoomListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<RoomModel>>(roomtList);
            return mapped;
        }

        public async Task<RoomModel> GetRoomById(int roomId)
        {
            var room = await _roomRepository.GetByIdAsync(roomId);
            var mapped = ObjectMapper.Mapper.Map<RoomModel>(room);
            return mapped;
        }

        public async Task<IEnumerable<RoomModel>> GetRoomByName(string roomName)
        {
            var roomList = await _roomRepository.GetRoomByNameAsync(roomName);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<RoomModel>>(roomList);
            return mapped;
        }

        
        public async Task<IEnumerable<BuildingModel>> GetRoomByBuilding(int buildingId)
        {
            var roomList = await _roomRepository.GetRoomByBuildingAsync(buildingId);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<BuildingModel>>(roomList);
            return mapped;
        }

        public async Task<RoomModel> Create(RoomModel roomModel)
        {
            await ValidateRoomIfExist(roomModel);

            var mappedEntity = ObjectMapper.Mapper.Map<Room>(roomModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _roomRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<RoomModel>(newEntity);
            return newMappedEntity;
        }

        public async Task Update(RoomModel roomModel)
        {
            ValidateRoomIfNotExist(roomModel);

            var editRoom = await _roomRepository.GetByIdAsync(roomModel.Id);
            if (editRoom == null)
                throw new ApplicationException($"Entity could not be loaded.");

            ObjectMapper.Mapper.Map<RoomModel, Room>(roomModel, editRoom);

            await _roomRepository.UpdateAsync(editRoom);
            _logger.LogInformation($"Entity successfully updated - AspnetRunAppService");
        }

        public async Task Delete(RoomModel roomModel)
        {
            ValidateRoomIfNotExist(roomModel);
            var deletedRoom = await _roomRepository.GetByIdAsync(roomModel.Id);
            if (deletedRoom == null)
                throw new ApplicationException($"Entity could not be loaded.");

            await _roomRepository.DeleteAsync(deletedRoom);
            _logger.LogInformation($"Entity successfully deleted - AspnetRunAppService");
        }

        private async Task ValidateRoomIfExist(RoomModel roomModel)
        {
            var existingEntity = await _roomRepository.GetByIdAsync(roomModel.Id);
            if (existingEntity != null)
                throw new ApplicationException($"{roomModel.ToString()} with this id already exists");
        }

        private void ValidateRoomIfNotExist(RoomModel roomModel)
        {
            var existingEntity = _roomRepository.GetByIdAsync(roomModel.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{roomModel.ToString()} with this id is not exists");
        }

    }
}
