using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        public Guid addProduct(Product p)
        {
            throw new NotImplementedException();
        }

        public void deleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
