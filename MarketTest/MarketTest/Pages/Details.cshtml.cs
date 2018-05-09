using MarketTest.BL.Abstractions;
using MarketTest.BL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketTest.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IMarketService _marketService;

        public DetailsModel(IMarketService marketService)
        {
            _marketService = marketService;
        }


        public ProductViewModel Product { get; set; }

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = _marketService.GetProduct(id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
