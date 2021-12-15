using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspnetRun.Core.Entities;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;

namespace AspnetRun.Web.Pages.Room
{
    public class DeleteModel : PageModel
    {
        private readonly IRoomPageService _roomPageService;

        public DeleteModel(IRoomPageService roomPageService)
        {
            _roomPageService = roomPageService ?? throw new ArgumentNullException(nameof(roomPageService));
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? roomId)
        {
            if (roomId == null)
            {
                return NotFound();
            }

            await _roomPageService.DeleteRoom(Room);          
            return RedirectToPage("./Index");
        }
    }
}
