using Microsoft.AspNetCore.Mvc;
using ppedv.Shopchestra.UI.ASP_MVC.Models;
using System.Diagnostics;

namespace ppedv.Shopchestra.UI.ASP_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        /// <summary>
        /// Gome mit Löffel
        /// </summary>
        ///<remarks>
        ///bla bla bla
        /// </remarks>
        /// <param name="logger">ein löffel</param>
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
    }
}