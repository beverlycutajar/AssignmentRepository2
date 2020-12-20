using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface IProductsRepository
    {
        IQueryable<Product> GetProducts();
        Guid addProduct(Product p);
        void deleteProduct(Guid id);
        Product GetProduct();

        //IQueryable<Product> GetProducts(int category);  TO SEARCH BY CATEGORY
    }
}
