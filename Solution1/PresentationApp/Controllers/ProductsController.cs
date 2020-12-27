using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PresentationApp.Models;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Application.ViewModels;

namespace PresentationApp.Controllers //wrong
{
    public class ProductsController : Controller
    {
        private IProductsServiceApp _prodService;
        private ICategoriesService _categoriesService;

        public ProductsController(IProductsServiceApp prodService, ICategoriesService categoriesService)
        {
            _prodService = prodService;
            _categoriesService = categoriesService;

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
        public IActionResult Create() // called before loading the create page
        {
            var list = _categoriesService.GetCategories();

            CreateModel model = new CreateModel();
            model.Categories = list.ToList();
            return View(model); // this method is used to load the initial page where the user inputs the data
        }

        [HttpPost]
        public IActionResult Create(CreateModel data) // this is used when the user press 'Submit'
        {
            try
            {
                _prodService.AddProduct(data.Product);

                ViewData["feedback"] = "Product added successfully";
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                ViewData["error"] = "Product not added. Please check you inputs and try again";
            }

            var list = _categoriesService.GetCategories();
            data.Categories = list.ToList();
            return View(data);
        }

        public IActionResult Delete(Guid id)
        {
            _prodService.DeleteProduct(id);

            TempData["feedback"] = "product was deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
