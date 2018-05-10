using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MarketTest.BL.Abstractions;
using MarketTest.BL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MarketTest.BL.Options;

namespace MarketTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMarketService _marketService;
        private readonly IOptions<VATOptions> _vatOptions;

        public IndexModel(IMarketService marketService, IOptions<VATOptions> vatOptions)
        {
            _marketService = marketService;
            _vatOptions = vatOptions;
        }
        
        public IList<ProductViewModel> Products { get;set; }
        public double VAT { get; set; }

        public void OnGet(string category, string name)
        {
            VAT = _vatOptions.Value.VAT;
            Products = _marketService.GetAllProducts(name, category, 0, 10).ToList();
        }
    }
}
