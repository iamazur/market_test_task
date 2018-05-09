using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MarketTest.BL.Abstractions;
using MarketTest.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMarketService _marketService;

        public IndexModel(IMarketService marketService)
        {
            _marketService = marketService;
        }
        
        public IList<ProductViewModel> Products { get;set; }
        public double VAT { get; set; }

        public void OnGet(string category, string name)
        {
            VAT = 1.125;
            Products = _marketService.GetAllProducts(name, category, 0, 10).ToList();
        }
    }
}
