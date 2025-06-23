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
        // 預約管理_搜尋排列_partial
        public ActionResult AppointmentQuery()
        {  
            return PartialView("_AppointmentQueryPartial");
        }
        // 預約管理_查詢列表_partial
        public ActionResult AppointmentResult(string appointment_reservationNum = "All", string appointment_UserID = "我是ID", string appointment_bookNum = "持續買進", DateTime? appointment_initDate = null, DateTime? appointment_lastDate = null, string? appointment_state = "All", string appointment_perPage = "10", string appointment_orderDate = "desc")
        {
            Debug.WriteLine("測試載入:  預約ID:" + appointment_reservationNum + " 使用者ID:" + appointment_UserID + " 書本名稱:" + appointment_bookNum + " 開始日期:" + appointment_initDate + " 今天日期:" + appointment_lastDate + " 狀態:" + appointment_state +" 頁數:" + appointment_perPage + " 日期排序:" + appointment_orderDate);
            return PartialView("_AppointmentResultPartial");
        }
        // 借閱查詢_搜尋排列_partial
        public ActionResult BorrowQuery()
        {
            return PartialView("_BorrowQueryPartial");
        }
        // 借閱查詢_查詢列表_partial
        public ActionResult BorrowResult(string borrow_BorrowID = "All",string borrow_UserID = "All", string borrow_bookNum = "All", string borrow_state = "All", string borrow_perPage = "10",string borrow_date = "borrowDate", string borrow_orderDate = "desc")
        {
            Debug.WriteLine($"測試借閱載入 {borrow_BorrowID}+{borrow_UserID} + {borrow_bookNum} + {borrow_state} + {borrow_perPage} + {borrow_date} + {borrow_orderDate}");
            return PartialView("_BorrowResultPartial"); 
        }
    }
}
