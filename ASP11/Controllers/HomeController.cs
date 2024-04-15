using ASP11.Filters;
using ASP11.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace ASP11.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet, UserLoggerFilter]
        public IActionResult Index()
        {
            return View("Index", "-----------");
        }

        [HttpPost]
        public IActionResult ActionLog()
        {
            string[] info = System.IO.File.ReadAllLines(@"actionlog.txt");
            StringBuilder sb = new StringBuilder();
            foreach (string line in info)
                sb.Append(line + "\n");
            return View("Index", sb.ToString());
        }

        [HttpPost]
        public IActionResult UserLog()
        {
            string[] info = System.IO.File.ReadAllLines(@"userlog.txt");
            StringBuilder sb = new StringBuilder();
            foreach (string line in info)
                sb.Append(line + "\n");
            return View("Index", sb.ToString());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

