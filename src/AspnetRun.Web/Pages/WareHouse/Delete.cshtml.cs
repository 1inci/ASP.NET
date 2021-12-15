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

namespace AspnetRun.Web.Pages.WareHouse
{
    public class DeleteModel : PageModel
    {
        private readonly IWareHousePageService _wareHousePageService;

        public DeleteModel(IWareHousePageService wareHousePageService)
        {
            _wareHousePageService = wareHousePageService ?? throw new ArgumentNullException(nameof(wareHousePageService));
        }

        [BindProperty]
        public WareHouseViewModel WareHouse { get; set; }

        public async Task<IActionResult> OnGetAsync(int? WareHouseId)
        {
            if (WareHouseId == null)
            {
                return NotFound();
            }

            WareHouse = await _wareHousePageService.GetWareHouseById(WareHouseId.Value);
            if (WareHouse == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? WareHouseId)
        {
            if (WareHouseId == null)
            {
                return NotFound();
            }

            await _wareHousePageService.DeleteWareHouse(WareHouse);          
            return RedirectToPage("./Index");
        }
    }
}
