using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRun.Web.Pages.Building
{
    public class IndexModel : PageModel
    {
        private readonly IBuildingPageService _buildingPageService;

        public IndexModel(IBuildingPageService buildingPageService)
        {
            _buildingPageService = buildingPageService ?? throw new ArgumentNullException(nameof(buildingPageService));
        }

        public IEnumerable<BuildingViewModel> BuildingList { get; set; } = new List<BuildingViewModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            BuildingList = await _buildingPageService.GetBuildings();
            return Page();
        }
    }
}