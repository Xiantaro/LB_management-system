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
        // �w���޲z_�j�M�ƦC_partial
        public ActionResult AppointmentQuery()
        {
            return PartialView("_AppointmentQueryPartial");
        }
        // �w���޲z_�d�ߦC��_partial
        public ActionResult AppointmentResult(string appointment_reservationNum = "All", string appointment_UserID = "�ڬOID", string appointment_bookNum = "����R�i", DateTime? appointment_initDate = null, DateTime? appointment_lastDate = null, string? appointment_state = "All", string appointment_perPage = "10", string appointment_orderDate = "desc")
        {
            Debug.WriteLine("���ո��J:  �w��ID:" + appointment_reservationNum + " �ϥΪ�ID:" + appointment_UserID + " �ѥ��W��:" + appointment_bookNum + " �}�l���:" + appointment_initDate + " ���Ѥ��:" + appointment_lastDate + " ���A:" + appointment_state + " ����:" + appointment_perPage + " ����Ƨ�:" + appointment_orderDate);
            return PartialView("_AppointmentResultPartial");
        }
        // �ɾ\�d��_�j�M�ƦC_partial
        public ActionResult BorrowQuery()
        {
            return PartialView("_BorrowQueryPartial");
        }
        // �ɾ\�d��_�d�ߦC��_partial
        public ActionResult BorrowResult(string borrow_BorrowID = "All", string borrow_UserID = "All", string borrow_bookNum = "All", string borrow_state = "All", string borrow_perPage = "10", string borrow_date = "borrowDate", string borrow_orderDate = "desc")
        {
            Debug.WriteLine($"���խɾ\���J {borrow_BorrowID}+{borrow_UserID} + {borrow_bookNum} + {borrow_state} + {borrow_perPage} + {borrow_date} + {borrow_orderDate}");
            return PartialView("_BorrowResultPartial");
        }
        // �ɮѼҦ�_partial
        public ActionResult BorrowMode()
        {
            return PartialView("_BorrowModePartial");
        }
        // �ɮѼҦ�_�ɮ�
        [HttpPost]
        public ActionResult BorrowSend()
        {
            Debug.WriteLine("���\�ɮ�");
            return PartialView("_BorrowModeContent");
        }
        // �ɮѼҦ�_�ɮѤH��T
        public ActionResult BorrowUserMessage()
        {
            Debug.WriteLine("���\���J�ɮѤH��T");
            return PartialView("_BorrowModeUser");
        }
        // �ɮѼҦ�_�ɮѤH��T
        public ActionResult BorrowBookMessage()
        {
            Debug.WriteLine("���\���J�ɮѤH��T");
            return PartialView("_BorrowModeBook");
        }
        // �ٮѼҦ�_partial
        public ActionResult ReturnBookMode()
        {
            Debug.WriteLine("�i�J�ٮѼҦ�");
            return PartialView("_ReturnBookPartial");
        }
        // �ٮѼҦ�_�ٮ�
        [HttpPost]
        public ActionResult ReturnBookSend()
        {
            Debug.WriteLine("�ٮѼҦ����\");
            return PartialView("_ReturnBookContent");
        }

    }
}
