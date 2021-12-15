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

namespace AspnetRun.Web.Pages.Building
{
    public class DeleteModel : PageModel
    {
        private readonly IBuildingPageService _buildingPageService;

        public DeleteModel(IBuildingPageService buildingPageService)
        {
            _buildingPageService = buildingPageService ?? throw new ArgumentNullException(nameof(buildingPageService));
        }

        [BindProperty]
        public BuildingViewModel Building { get; set; }

        public async Task<IActionResult> OnGetAsync(int? buildingId)
        {
            if (buildingId == null)
            {
                return NotFound();
            }

            Building = await _buildingPageService.GetBuildingById(buildingId.Value);
            if (Building == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? buildingId)
        {
            if (buildingId == null)
            {
                return NotFound();
            }

            await _buildingPageService.DeleteBuilding(Building);          
            return RedirectToPage("./Index");
        }
    }
}
