using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class ProductsService : IProductsServiceApp
    { 

        private IProductsRepository _productsRepository;
        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public void AddProduct(ProductViewModel model)
        {
            Product p = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Image = model.ImageUrl,
                Price = model.Price,
                Stock=model.Stock,
                CategoryId=model.Category.Id
            };
            _productsRepository.addProduct(p);
        }

        public void DeleteProduct(Guid id)
        {
            _productsRepository.deleteProduct(id);
        }

        public ProductViewModel GetProduct(Guid id)
        {
            /* var p = _productsRepository.GetProduct(id);
             if (p == null) return null;
             else
            return new ProductViewModel()
                        {
                            Id = p.Id,
                            Description = p.Description,
                            ImageUrl = p.Image,
                            Name = p.Name,
                            Price = p.Price,
                            Category = new CategoryViewModel() { Id = p.Category.Id, Name = p.Category.Name }
                        };
              */
            var p = GetProducts().SingleOrDefault(x => x.Id == id);
            return p;

        }

        public IQueryable<ProductViewModel> GetProducts()
        {
            var list = from p in _productsRepository.GetProducts()
                       select new ProductViewModel()
                       {
                           Id = p.Id,
                           Description = p.Description,
                           ImageUrl = p.Image,
                           Name = p.Name,
                           Price = p.Price,
                           Category = new CategoryViewModel() { Id = p.Category.Id, Name = p.Category.Name }
                       };
            return list;
        }
    }
}
