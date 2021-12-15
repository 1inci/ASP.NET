using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRun.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IIndexPageService _indexPageService;

        public IndexModel(IIndexPageService indexPageService)
        {
            _indexPageService = indexPageService ?? throw new ArgumentNullException(nameof(indexPageService));
        }

        public IEnumerable<BuildingViewModel> BuildingList { get; set; } = new List<BuildingViewModel>();
        public BuildingViewModel BuilginModel { get; set; } = new BuildingViewModel();

        public async Task<IActionResult> OnGet()
        {
            BuildingList = await _indexPageService.GetBuildings();

            //CategoryModel = await _indexPageService.GetCategoryWithRooms(1);
            //RoomModel = await _indexPageService.GetRooms();
            return Page();
        }
    }
}
