using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserService _userService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _userService = new UserService();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            ViewData["Title"] = TempData["CurrentData"];
            return View();
        }

        [HttpPost]
        public IActionResult Privacy(LoginModel model)
        {
            return View(model);
        }
        
        public IActionResult Index()
        {
            return View(); 
        }

        [HttpGet]
        public IActionResult Account()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Account(LoginModel model)
        {
            model.Success = _userService?.CheckCredentials(model.login, model.password);
            if (model.Success.HasValue && model.Success.Value)
            {
                UserService userService = new UserService();
                var CurrentUser1 = userService.Users.Where(x => x.login == model.login && x.password == model.password);
                TempData["CurrentData"] = CurrentUser1.First().fullname + "\nДата рождения: " + CurrentUser1.First().birthday;
                return RedirectToAction("Privacy", "Home");
            }
            return RedirectToAction("Error", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
