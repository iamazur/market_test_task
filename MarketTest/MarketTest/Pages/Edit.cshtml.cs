using MarketTest.BL.Abstractions;
using MarketTest.BL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MarketTest.DAL.Entites;
using Microsoft.EntityFrameworkCore;

namespace MarketTest.Pages
{
    public class EditModel : PageModel
    {
        private readonly IMarketService _marketService;

        public EditModel(IMarketService marketService)
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                Product = _marketService.UpdateProduct(Product.Code, Product);
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToPage("./Error"); ;
            }

            return RedirectToPage("./Index");
        }
    }
}
