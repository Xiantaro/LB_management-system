using System.Diagnostics;
using library_management_system.Models;
using Microsoft.AspNetCore.Mvc;

namespace library_management_system.Controllers
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
        public IActionResult BorrowBook()
        {
            return View();
        }
        public IActionResult ReturnTheBook()
        {
            return View();
        }
        public ActionResult BorrowRecord()
        {
            return PartialView("_BorrowRecordPartial");
        }
        public ActionResult AppointmentManagement()
        {
            return PartialView("_AppointmentManagementPartial");
        }

        //public IActionResult AppointmentManagement()
        //{
        //    return View();
        //}
        //public IActionResult BorrowingRecord()
        //{
        //    return View();
        //}
    }
}
