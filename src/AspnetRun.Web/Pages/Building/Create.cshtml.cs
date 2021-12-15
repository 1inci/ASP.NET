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
    public class CreateModel : PageModel
    {
        private readonly IBuildingPageService _buildingPageService;

        public CreateModel(IBuildingPageService buildingPageService)
        {
            _buildingPageService = buildingPageService ?? throw new ArgumentNullException(nameof(buildingPageService));
        }

        public async Task<IActionResult> OnGetAsync()
        {
           return Page();
        }

        [BindProperty]
        public BuildingViewModel Building { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Building = await _buildingPageService.CreateBuilding(Building);
            return RedirectToPage("./Index");
        }
    }
}
