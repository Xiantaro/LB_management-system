using Elfie.Serialization;
using library_management_system.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;

namespace library_management_system.Controllers
{

    public class HomeController : Controller
    {
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
        //------------------------------------------------------------------------------------------
        #region �w���޲z&�d��
        // �w���޲z_�j�M�ƦC_partial
        
        public IActionResult AppointmentQuery()
        {
            return PartialView("~/Views/AppoimtmentQuery/_AppointmentQueryPartial.cshtml");
        }
        //�w���޲z_�d�ߦC��_partial
        public IActionResult AppointmentResult(string appointment_reservationNum = "All", string appointment_UserID = "�ڬOID", string appointment_bookNum = "����R�i", DateTime? appointment_initDate = null, DateTime? appointment_lastDate = null, string? appointment_state = "All", string appointment_perPage = "10", string appointment_orderDate = "desc", int page = 1)
        {
            Debug.WriteLine("���ո��J:  �w��ID:" + appointment_reservationNum + " �ϥΪ�ID:" + appointment_UserID + " �ѥ��W��:" + appointment_bookNum + " �}�l���:" + appointment_initDate + " ���Ѥ��:" + appointment_lastDate + " ���A:" + appointment_state + " ����:" + appointment_perPage + " ����Ƨ�:" + appointment_orderDate + "����" + page);
            return PartialView("~/Views/AppoimtmentQuery/_AppointmentResultPartial.cshtml");
        }
        public IActionResult AppointmentCancel(string appointmentid)
        {
            Debug.WriteLine($"���զ^�Ǩ����w���s��: {appointmentid}");
            return Ok();
        }
        #endregion

        #region �ɾ\�d��
            // �ɾ\�d��_�j�M�ƦC_partial
        public IActionResult BorrowQuery()
        {
            return PartialView("~/Views/BorrowQuery/_BorrowQueryPartial.cshtml");
        }
        // �ɾ\�d��_�d�ߦC��_partial
        public IActionResult BorrowResult(string borrow_BorrowID = "All", string borrow_UserID = "All", string borrow_bookNum = "All", string borrow_state = "All", string borrow_perPage = "10", string borrow_date = "borrowDate", string borrow_orderDate = "desc", int page = 1)
        {
            Debug.WriteLine($"���խɾ\���J {borrow_BorrowID}+{borrow_UserID} + {borrow_bookNum} + {borrow_state} + {borrow_perPage} + {borrow_date} + {borrow_orderDate} + ����: {page}");
            return PartialView("~/Views/BorrowQuery/_BorrowResultPartial.cshtml");
        }
        #endregion

        #region �ɾ\�B�w���Ҧ�
        // �ɮѼҦ�_partial
        public IActionResult BorrowMode()
        {
            return PartialView("~/Views/Borrow/_BorrowModePartial.cshtml");
        }
        // �ɮѼҦ�_�ɮ�
        public IActionResult BorrowSend(string borrwoMode_UserID, string borrwoMode_BookNumber)
        {
            #region ���զ^�ǥi�R
            //var mystatu = new BorrowModeSendClass();
            //if (borrwoMode_UserID != "1234")
            //{
            //    mystatu.IsSuccess = false;
            //    mystatu.MistakeMessag = "�ɾ\�̤��s�b";
            //    return PartialView("_BorrowModeContent", mystatu);
            //}
            //if (borrwoMode_BookNumber != "1234")
            //{
            //    mystatu.IsSuccess = false;
            //    mystatu.MistakeMessag = "�ѥ����s�b";
            //    return PartialView("_BorrowModeContent", mystatu);
            //}
            //Debug.WriteLine($"���\�ɮ� ID:{borrwoMode_UserID} BookID: {borrwoMode_BookNumber}");
            //mystatu.UserId = borrwoMode_UserID;
            //mystatu.BookName = borrwoMode_BookNumber;
            #endregion 
            return PartialView("~/Views/Borrow/_BorrowModeContent.cshtml");
        }
        // �w���Ҧ�_�w��
        public IActionResult AppointmentSend(string borrwoMode_UserID, string borrwoMode_BookNumber)
        {
            Debug.WriteLine($"�ϥΪ�: {borrwoMode_UserID} �F���yID {borrwoMode_BookNumber}");
            return PartialView("~/Views/Borrow/_BorrowModeContent.cshtml");
        }
        // �ɮѼҦ�_�ɮѤH��T
        public IActionResult BorrowUserMessage(string userId)
        {
            // ����n�إ� ViewModel �ΨӸ˷j�M�쪺 �ɮѤH��T
            // �æ^�Ǩ� PartialView �W
            Debug.WriteLine(userId);
            return PartialView("~/Views/Borrow/_BorrowModeUser.cshtml");
        }
        // �ɮѼҦ�_�ѥ���T
        public IActionResult BorrowBookMessage(string bookId)
        {
            // ����n�إ� ViewModel �ΨӸ˷j�M�쪺 �ѥ���T
            // �æ^�Ǩ� PartialView �W
            Debug.WriteLine(bookId);
            return PartialView("~/Views/Borrow/_BorrowModeBook.cshtml");
        }
        #endregion �ɾ\�Ҧ�END

        #region �ٮѼҦ�
        public IActionResult ReturnBookMode()
        {
            return PartialView("~/Views/ReturnBook/_ReturnBookPartial.cshtml");
        }
        public IActionResult ReturnBookSend(string ReturnBookID)
        {
            Debug.WriteLine($"�ɾ\��{ReturnBookID}�ٮѦ��\");
            return PartialView("~/Views/ReturnBook/_ReturnBookContent.cshtml");
        }
        #endregion �ٮѼҦ� END

        #region �w���Ҧ�
        public IActionResult AppointmentMode1()
        {
            Debug.WriteLine("�w���Ҧ����J���\...............");
            return Ok();
        }
        public IActionResult Appoimt2()
        {
            Debug.WriteLine("�w���Ҧ����J���\...............");
            return Ok();
        }
        #endregion
        //------------------------------------------------------------------------------------------
    }
}
