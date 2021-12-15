using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspnetRun.Web.Pages.Building
{
    public class EditModel : PageModel
    {
        private readonly IBuildingPageService _buildingPageService;

        public EditModel(IBuildingPageService buildingPageService)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _buildingPageService.UpdateBuilding(Building);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(Building.Id))
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
            var room = _buildingPageService.GetBuildingById(id);
            return room != null;
        }

    }
}
