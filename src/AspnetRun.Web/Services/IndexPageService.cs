using AspnetRun.Application.Interfaces;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Web.Services
{
    public class IndexPageService : IIndexPageService
    {
        private readonly IRoomService _roomAppService;        
        private readonly IWareHouseService _wareHouseAppService;        
        private readonly IBuildingService _buildingAppService;        
        private readonly IMapper _mapper;

        public IndexPageService(IRoomService roomAppService, IWareHouseService wareHouseAppService, IBuildingService buildingAppService, IMapper mapper)
        {
            _roomAppService = roomAppService ?? throw new ArgumentNullException(nameof(roomAppService));
            _wareHouseAppService = wareHouseAppService ?? throw new ArgumentNullException(nameof(wareHouseAppService));
            _buildingAppService = buildingAppService ?? throw new ArgumentNullException(nameof(buildingAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<BuildingViewModel>> GetBuildings()
        {
            var list = await _buildingAppService.GetBuildingList();
            var mapped = _mapper.Map<IEnumerable<BuildingViewModel>>(list);
            return mapped;
        }

        public async Task<IEnumerable<RoomViewModel>> GetRooms()
        {
            var list = await _roomAppService.GetRoomList();
            var mapped = _mapper.Map<IEnumerable<RoomViewModel>>(list);
            return mapped;
        }

        public async Task<IEnumerable<WareHouseViewModel>> GetWareHouses()
        {
            var list = await _wareHouseAppService.GetWareHouseList();
            var mapped = _mapper.Map<IEnumerable<WareHouseViewModel>>(list);
            return mapped;
        }
    }
}
