using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspnetRun.Core.Entities;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Web.ViewModels;
using AspnetRun.Web.Interfaces;

namespace AspnetRun.Web.Pages.Room
{
    public class EditModel : PageModel
    {
        private readonly IRoomPageService _roomPageService;

        public EditModel(IRoomPageService roomPageService)
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
            
            ViewData["BuildingId"] = new SelectList(await _roomPageService.GetBuildings(), "Id", "BuildingName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            try
            {
                await _roomPageService.UpdateRoom(Room);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(Room.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }

        private bool RoomExists(int id)
        {
            var room = _roomPageService.GetRoomById(id);
            return room != null;            
        }
    }
}
