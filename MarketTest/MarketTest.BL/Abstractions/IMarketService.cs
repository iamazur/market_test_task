using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarketTest.BL.Models;

namespace MarketTest.BL.Abstractions
{
    public interface IMarketService
    {
        IQueryable<ProductViewModel> GetAllProducts(string name, string category, int skip, int take);
        ProductViewModel GetProduct(string code);
        ProductViewModel UpdateProduct(string code, ProductBaseModel model);
        ProductViewModel CreateProduct(ProductBaseModel model);
        bool DeleteProduct(string code);
    }
}
