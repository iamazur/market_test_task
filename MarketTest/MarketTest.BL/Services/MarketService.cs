using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarketTest.BL.Abstractions;
using MarketTest.BL.Models;
using MarketTest.DAL.Entites;
using MarketTest.DAL.Infrastrusture;

namespace MarketTest.BL.Services
{
    public class MarketService : IMarketService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MarketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ProductViewModel CreateProduct(ProductBaseModel model)
        {
            var newProduct = new ProductEntity()
            {
                Code = Guid.NewGuid().ToString("N"),
                Name = model.Name,
                Description =  model.Description,
                Category = model.Category,
                Price =  model.Price
            };

            _unitOfWork.Repository<ProductEntity>().Insert(newProduct);
            _unitOfWork.SaveChanges();

            return new ProductViewModel()
            {
                Code = newProduct.Code,
                Name = newProduct.Name,
                Description = newProduct.Description,
                Category = newProduct.Category,
                Price = newProduct.Price
            };
        }

        public bool DeleteProduct(string code)
        {
            var product = _unitOfWork.Repository<ProductEntity>()
                                     .Set
                                     .FirstOrDefault(x => x.Code == code);

            if (product == null)
            {
                return false;
            }

            _unitOfWork.Repository<ProductEntity>().Delete(product);
            return true;
        }

        public IQueryable<ProductViewModel> GetAllProducts(string name, string category, int skip, int take)
        {
            var products = _unitOfWork.Repository<ProductEntity>()
                                      .Set
                                      .Where(x => (String.IsNullOrEmpty(name) || x.Name.ToLower().Replace(' ', '-') == name.ToLower())
                                               && (String.IsNullOrEmpty(category) || x.Category.ToLower() == category.ToLower()))
                                      .OrderBy(x => x.Code)
                                      .Skip(skip == default(int) ? 0 : skip)
                                      .Take(take == default(int) ? 0 : take)
                                      .Select(x => new ProductViewModel()
                                       {
                                           Code = x.Code,
                                           Name = x.Name,
                                           Description = x.Description,
                                           Category = x.Category,
                                           Price = x.Price
                                       });
            return products;
        }

        public ProductViewModel GetProduct(string code)
        {
            var product = _unitOfWork.Repository<ProductEntity>()
                .Set
                .FirstOrDefault(x => x.Code == code);

            if (product == null)
            {
                return null;
            }

            return new ProductViewModel()
            {
                Code = product.Code,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price
            };
        }

        public ProductViewModel UpdateProduct(string code, ProductBaseModel model)
        {
            var product = _unitOfWork.Repository<ProductEntity>()
                .Set
                .FirstOrDefault(x => x.Code == code);

            if (product == null)
            {
                throw null;
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.Category = model.Category;
            product.Price = model.Price;
            _unitOfWork.SaveChanges();

            return new ProductViewModel()
            {
                Code = product.Code,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price
            };
        }
    }
}
