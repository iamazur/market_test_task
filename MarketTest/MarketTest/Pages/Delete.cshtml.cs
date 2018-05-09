using MarketTest.BL.Abstractions;
using MarketTest.BL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MarketTest.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IMarketService _marketService;

        public DeleteModel(IMarketService marketService)
        {
            _marketService = marketService;
        }

        [BindProperty]
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

        public IActionResult OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = _marketService.GetProduct(id);

            if (Product != null)
            {
                _marketService.DeleteProduct(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
