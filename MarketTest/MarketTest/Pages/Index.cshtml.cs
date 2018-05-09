using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MarketTest.BL.Abstractions;
using MarketTest.BL.Models;

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

        public void OnGetAsync()
        {
            Products = _marketService.GetAllProducts(String.Empty, String.Empty, 0, 10).ToList();
        }
    }
}
