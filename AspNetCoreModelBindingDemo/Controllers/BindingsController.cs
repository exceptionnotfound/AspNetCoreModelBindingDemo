using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreModelBindingDemo.ViewModels.Bindings;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCoreModelBindingDemo.Controllers
{
    public class BindingsController : Controller
    {
        [HttpGet]
        public IActionResult Index([FromQuery]string message) //We get this value from the Query String.  If it does not exist, then the default value for the type is used (null for string, 0 for int, etc).
        {
            ViewData["message"] = message;
            return View();
        }

        [HttpGet]
        public IActionResult New([FromRoute] string controller) //We receive the value for controller from the Routing system.
        {
            BoundUser user = new BoundUser();
            user.Controller = controller;
            return View(user);
        }

        [HttpPost]
        public IActionResult New([FromForm] BoundUser user) //We receive most of the User values from the Form data, except for Controller, which we receive from Routing.
        {
            var message = user.FirstName + " " + user.LastName + ", Date of Birth: " + user.DateOfBirth.ToString("yyyy-MM-dd") + ", ID: " + user.ID + ", Controller: " + user.Controller;
            return RedirectToAction("index", new { message = message });
        }
    }
}