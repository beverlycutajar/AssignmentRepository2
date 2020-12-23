using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Repositories;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.IOC
{
    public class DependencyContainer

        /*
            Whenever there is another call that demands an instance of class which has been declared in the following method,
        the registerServices method creates an instance of that demand "class" and we are aso informing the RegisterServices
        about the associations that exist between the interface. 

    */

    {
        public static void RegisterServices(IServiceCollection services, string ConnectionString)
        {
            services.AddDbContext<ShoppingCartDbContext>(options =>
            options.UseSqlServer(
                ConnectionString));

            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsServiceApp, ProductsService>();
        }
    }
}
