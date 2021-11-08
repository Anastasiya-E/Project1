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

        public IActionResult Privacy()
        {
            return View();
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

            model.Success = _userService.CheckCredentials(model.login, model.password);
            if (model.Success ?? false)
            {
                return RedirectToAction("Index", "Home");
            }
                return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
