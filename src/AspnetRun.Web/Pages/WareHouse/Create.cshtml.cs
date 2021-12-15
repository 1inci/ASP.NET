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

namespace AspnetRun.Web.Pages.WareHouse
{
    public class CreateModel : PageModel
    {
        private readonly IWareHousePageService _wareHousePageService;

        public CreateModel(IWareHousePageService wareHousePageService)
        {
            _wareHousePageService = wareHousePageService ?? throw new ArgumentNullException(nameof(wareHousePageService));
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var categories = await _wareHousePageService.GetBuildings();
            ViewData["BuildingId"] = new SelectList(categories, "Id", "BuildingName");
            return Page();
        }

        [BindProperty]
        public WareHouseViewModel WareHouse { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            WareHouse = await _wareHousePageService.CreateWareHouse(WareHouse);
            return RedirectToPage("./Index");
        }
    }
}