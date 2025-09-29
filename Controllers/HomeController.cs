using System.Diagnostics;
using GArch_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GArch_Web.Controllers
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

        public IActionResult Users()
        {
            return View();
        }
        public IActionResult FormOne()
        {
            var data = new UserVM();
            return View(data);
        }

        [HttpPost]
        public JsonResult SubmitForm()
        {
            return Json(new { success = true });
        }


        [HttpGet]
        public IActionResult GetData()
        {
            var listData = new List<UserVM>()
            {
                new UserVM()
                {
                    Id = 1,
                    Username = "Admin1",
                    Password = "PasswordX"
                },
                new UserVM()
                {
                    Id = 1,
                    Username = "Admin2",
                    Password = "PasswordY"
                },

                new UserVM()
                {
                    Id = 6,
                    Username = "Admin3",
                    Password = "PasswordXYZ"
                },
            };

            return Json(listData);
        }


    }
}
