using dockerplayground.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace dockerplayground.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var filePath = "c:/storage/playground.txt";
            if (!System.IO.File.Exists(filePath))
            {
                System.IO.Directory.CreateDirectory("c:/storage/");
                var fs = System.IO.File.Create(filePath);
                fs.Close();
                System.IO.File.WriteAllText(filePath, "I just created the file");
            }
            else
            {
                System.IO.File.WriteAllText(filePath, "The file is already created");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
