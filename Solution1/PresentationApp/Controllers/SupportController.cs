using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PresentationApp.Controllers
{
    public class SupportController : Controller
    {
        [ResponseCache(Duration =0, Location =ResponseCacheLocation.None, NoStore =true)] //doesnt cache the page

        //There are other roles such as delete and patch

        [HttpGet] //load the page 
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost] //recieve data from a form submission
        public ActionResult Contact(string email, string query)
        {
            ViewData["feedback"] = "Thank you for your query. We will be with you shortly";

            return View();
        }
    }
}
