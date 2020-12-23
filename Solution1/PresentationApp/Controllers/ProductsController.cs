using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Application.ViewModels;

namespace PresentationApp.Controllers //wrong
{
    public class ProductsController : Controller
    {
        private IProductsServiceApp _prodService;

        public ProductsController(IProductsServiceApp prodService)
        {
            _prodService = prodService;
        }
        public IActionResult Index()
        {
            var list = _prodService.GetProducts();
            return View(list);
        }

        public IActionResult Details(Guid id)
        {
            var p = _prodService.GetProduct(id);
            return View(p);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(); // this method is used to load the initial page where the user inputs the data
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel data) // this is used when the user press 'Submit'
        {
            try
            {
                _prodService.AddProduct(data);

                ViewData["feedback"] = "Product added successfully";
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                ViewData["error"] = "Product not added. Please check you inputs and try again";
            }

            return View();
        }
    }
}
