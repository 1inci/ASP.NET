using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspnetRun.Web.ViewModels;
using AspnetRun.Web.Interfaces;

namespace AspnetRun.Web.Pages.WareHouse
{
    public class IndexModel : PageModel
    {
        private readonly IWareHousePageService _wareHousePageService;

        public IndexModel(IWareHousePageService wareHousePageService)
        {
            _wareHousePageService = wareHousePageService ?? throw new ArgumentNullException(nameof(wareHousePageService));
        }

        public IEnumerable<WareHouseViewModel> WareHouseList { get; set; } = new List<WareHouseViewModel>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            WareHouseList = await _wareHousePageService.GetWareHouse(SearchTerm);
            return Page();
        }
    }
}
