using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspnetRun.Web.ViewModels;
using AspnetRun.Web.Interfaces;

namespace AspnetRun.Web.Pages.Room
{
    public class IndexModel : PageModel
    {
        private readonly IRoomPageService _roomPageService;

        public IndexModel(IRoomPageService roomPageService)
        {
            _roomPageService = roomPageService ?? throw new ArgumentNullException(nameof(roomPageService));
        }

        public IEnumerable<RoomViewModel> RoomList { get; set; } = new List<RoomViewModel>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            RoomList = await _roomPageService.GetRoom(SearchTerm);
            return Page();
        }
    }
}
