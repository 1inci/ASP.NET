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

namespace AspnetRun.Web.Pages.WareHouse
{
    public class EditModel : PageModel
    {
        private readonly IWareHousePageService _wareHousePageService;

        public EditModel(IWareHousePageService wareHousePageService)
        {
            _wareHousePageService = wareHousePageService ?? throw new ArgumentNullException(nameof(wareHousePageService));
        }

        [BindProperty]
        public WareHouseViewModel WareHouse { get; set; }

        public async Task<IActionResult> OnGetAsync(int? wareHouseId)
        {
            if (wareHouseId == null)
            {
                return NotFound();
            }

            WareHouse = await _wareHousePageService.GetWareHouseById(wareHouseId.Value);
            if (WareHouse == null)
            {
                return NotFound();
            }
            
            ViewData["BuildingId"] = new SelectList(await _wareHousePageService.GetBuildings(), "Id", "BuildingName");
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
                await _wareHousePageService.UpdateWareHouse(WareHouse);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WareHouseExists(WareHouse.Id))
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

        private bool WareHouseExists(int id)
        {
            var product = _wareHousePageService.GetWareHouseById(id);
            return product != null;            
        }
    }
}
