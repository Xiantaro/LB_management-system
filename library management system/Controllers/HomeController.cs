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
        // 箇恨瞶_穓碝逼_partial
        public ActionResult AppointmentQuery()
        {
            return PartialView("_AppointmentQueryPartial");
        }
        // 箇恨瞶_琩高_partial
        public ActionResult AppointmentResult(string appointment_reservationNum = "All", string appointment_UserID = "и琌ID", string appointment_bookNum = "尿禦秈", DateTime? appointment_initDate = null, DateTime? appointment_lastDate = null, string? appointment_state = "All", string appointment_perPage = "10", string appointment_orderDate = "desc")
        {
            Debug.WriteLine("代刚更:  箇ID:" + appointment_reservationNum + " ㄏノID:" + appointment_UserID + " セ嘿:" + appointment_bookNum + " 秨﹍ら戳:" + appointment_initDate + " さぱら戳:" + appointment_lastDate + " 篈:" + appointment_state + " 计:" + appointment_perPage + " ら戳逼:" + appointment_orderDate);
            return PartialView("_AppointmentResultPartial");
        }
        // 綷琩高_穓碝逼_partial
        public ActionResult BorrowQuery()
        {
            return PartialView("_BorrowQueryPartial");
        }
        // 綷琩高_琩高_partial
        public ActionResult BorrowResult(string borrow_BorrowID = "All", string borrow_UserID = "All", string borrow_bookNum = "All", string borrow_state = "All", string borrow_perPage = "10", string borrow_date = "borrowDate", string borrow_orderDate = "desc")
        {
            Debug.WriteLine($"代刚綷更 {borrow_BorrowID}+{borrow_UserID} + {borrow_bookNum} + {borrow_state} + {borrow_perPage} + {borrow_date} + {borrow_orderDate}");
            return PartialView("_BorrowResultPartial");
        }
        // 家Α_partial
        public ActionResult BorrowMode()
        {
            return PartialView("_BorrowModePartial");
        }
        // 家Α_
        [HttpPost]
        public ActionResult BorrowSend()
        {
            Debug.WriteLine("Θ");
            return PartialView("_BorrowModeContent");
        }
        // 家Α_戈癟
        public ActionResult BorrowUserMessage()
        {
            Debug.WriteLine("Θ更戈癟");
            return PartialView("_BorrowModeUser");
        }
        // 家Α_戈癟
        public ActionResult BorrowBookMessage()
        {
            Debug.WriteLine("Θ更戈癟");
            return PartialView("_BorrowModeBook");
        }
        // 临家Α_partial
        public ActionResult ReturnBookMode()
        {
            Debug.WriteLine("秈临家Α");
            return PartialView("_ReturnBookPartial");
        }
        // 临家Α_临
        [HttpPost]
        public ActionResult ReturnBookSend()
        {
            Debug.WriteLine("临家ΑΘ");
            return PartialView("_ReturnBookContent");
        }

    }
}
