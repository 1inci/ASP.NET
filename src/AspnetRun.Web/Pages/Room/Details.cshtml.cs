using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;

namespace AspnetRun.Web.Pages.Room
{
    public class DetailsModel : PageModel
    {
        private readonly IRoomPageService _roomPageService;

        public DetailsModel(IRoomPageService roomPageService)
        {
            _roomPageService = roomPageService ?? throw new ArgumentNullException(nameof(roomPageService));
        }       

        public RoomViewModel Room { get; set; }

        public async Task<IActionResult> OnGetAsync(int? roomId)
        {
            if (roomId == null)
            {
                return NotFound();
            }

            Room = await _roomPageService.GetRoomById(roomId.Value);
            if (Room == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
