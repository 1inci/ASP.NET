using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspnetRun.Core.Entities;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;

namespace AspnetRun.Web.Pages.Room
{
    public class CreateModel : PageModel
    {
        private readonly IRoomPageService _roomPageService;

        public CreateModel(IRoomPageService roomPageService)
        {
            _roomPageService = roomPageService ?? throw new ArgumentNullException(nameof(roomPageService));
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var building = await _roomPageService.GetBuildings();
            ViewData["BuildingId"] = new SelectList(building, "Id", "BuildingName");
            return Page();
        }

        [BindProperty]
        public RoomViewModel Room { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Room = await _roomPageService.CreateRoom(Room);
            return RedirectToPage("./Index");
        }
    }
}