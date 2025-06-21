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
        // 預約管理_搜尋排列_partial
        public ActionResult AppointmentManagement()
        {  
            return PartialView("_AppointmentManagementPartial");
        }
        // 預約管理_查詢列表_partial
        public ActionResult BookListTable(string reservationNum = "All", string borrowID = "我是ID", string bookNum = "持續買進", DateTime? initDate = null, DateTime? lastDate = null)
        {
            Debug.WriteLine("測試載入" + reservationNum + " " + borrowID + " " + bookNum + " " + initDate + " " + lastDate);
            return PartialView("_BookTablePartial");
        }
    }
}
