using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketTest.BL.Abstractions;
using MarketTest.BL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MarketTest.DAL.Contexts;
using MarketTest.DAL.Entites;

namespace MarketTest.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IMarketService _marketService;

        public CreateModel(IMarketService marketService)
        {
            _marketService = marketService;
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProductBaseModel Product { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Product = _marketService.CreateProduct(Product);

            return RedirectToPage("./Index");
        }
    }
}