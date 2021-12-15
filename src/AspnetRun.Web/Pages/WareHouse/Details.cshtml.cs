using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;

namespace AspnetRun.Web.Pages.WareHouse
{
    public class DetailsModel : PageModel
    {
        private readonly IWareHousePageService _wareHousePageService;

        public DetailsModel(IWareHousePageService wareHousePageService)
        {
            _wareHousePageService = wareHousePageService ?? throw new ArgumentNullException(nameof(wareHousePageService));
        }       

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
    }
}
