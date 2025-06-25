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
        #region 箇恨瞶&琩高
        // 箇恨瞶_穓碝逼_partial
        
        public IActionResult AppointmentQuery()
        {
            return PartialView("~/Views/AppoimtmentQuery/_AppointmentQueryPartial.cshtml");
        }
        //箇恨瞶_琩高_partial
        public IActionResult AppointmentResult(string appointment_reservationNum = "All", string appointment_UserID = "и琌ID", string appointment_bookNum = "尿禦秈", DateTime? appointment_initDate = null, DateTime? appointment_lastDate = null, string? appointment_state = "All", string appointment_perPage = "10", string appointment_orderDate = "desc", int page = 1)
        {
            Debug.WriteLine("代刚更:  箇ID:" + appointment_reservationNum + " ㄏノID:" + appointment_UserID + " セ嘿:" + appointment_bookNum + " 秨﹍ら戳:" + appointment_initDate + " さぱら戳:" + appointment_lastDate + " 篈:" + appointment_state + " 计:" + appointment_perPage + " ら戳逼:" + appointment_orderDate + "计" + page);
            return PartialView("~/Views/AppoimtmentQuery/_AppointmentResultPartial.cshtml");
        }
        public IActionResult AppointmentCancel(string appointmentid)
        {
            Debug.WriteLine($"代刚肚箇絪腹: {appointmentid}");
            return Ok();
        }
        #endregion

        #region 綷琩高
            // 綷琩高_穓碝逼_partial
        public IActionResult BorrowQuery()
        {
            return PartialView("~/Views/BorrowQuery/_BorrowQueryPartial.cshtml");
        }
        // 綷琩高_琩高_partial
        public IActionResult BorrowResult(string borrow_BorrowID = "All", string borrow_UserID = "All", string borrow_bookNum = "All", string borrow_state = "All", string borrow_perPage = "10", string borrow_date = "borrowDate", string borrow_orderDate = "desc", int page = 1)
        {
            Debug.WriteLine($"代刚綷更 {borrow_BorrowID}+{borrow_UserID} + {borrow_bookNum} + {borrow_state} + {borrow_perPage} + {borrow_date} + {borrow_orderDate} + 计: {page}");
            return PartialView("~/Views/BorrowQuery/_BorrowResultPartial.cshtml");
        }
        #endregion

        #region 綷箇家Α
        // 家Α_partial
        public IActionResult BorrowMode()
        {
            return PartialView("~/Views/Borrow/_BorrowModePartial.cshtml");
        }
        // 家Α_
        public IActionResult BorrowSend(string borrwoMode_UserID, string borrwoMode_BookNumber)
        {
            #region 代刚肚
            //var mystatu = new BorrowModeSendClass();
            //if (borrwoMode_UserID != "1234")
            //{
            //    mystatu.IsSuccess = false;
            //    mystatu.MistakeMessag = "綷ぃ";
            //    return PartialView("_BorrowModeContent", mystatu);
            //}
            //if (borrwoMode_BookNumber != "1234")
            //{
            //    mystatu.IsSuccess = false;
            //    mystatu.MistakeMessag = "セぃ";
            //    return PartialView("_BorrowModeContent", mystatu);
            //}
            //Debug.WriteLine($"Θ ID:{borrwoMode_UserID} BookID: {borrwoMode_BookNumber}");
            //mystatu.UserId = borrwoMode_UserID;
            //mystatu.BookName = borrwoMode_BookNumber;
            #endregion 
            return PartialView("~/Views/Borrow/_BorrowModeContent.cshtml");
        }
        // 箇家Α_箇
        public IActionResult AppointmentSend(string borrwoMode_UserID, string borrwoMode_BookNumber)
        {
            Debug.WriteLine($"ㄏノ: {borrwoMode_UserID} 膟ID {borrwoMode_BookNumber}");
            return PartialView("~/Views/Borrow/_BorrowModeContent.cshtml");
        }
        // 家Α_戈癟
        public IActionResult BorrowUserMessage(string userId)
        {
            // ぇ璶ミ ViewModel ノㄓ杆穓碝 戈癟
            // 肚 PartialView 
            Debug.WriteLine(userId);
            return PartialView("~/Views/Borrow/_BorrowModeUser.cshtml");
        }
        // 家Α_セ戈癟
        public IActionResult BorrowBookMessage(string bookId)
        {
            // ぇ璶ミ ViewModel ノㄓ杆穓碝 セ戈癟
            // 肚 PartialView 
            Debug.WriteLine(bookId);
            return PartialView("~/Views/Borrow/_BorrowModeBook.cshtml");
        }
        #endregion 綷家ΑEND

        #region 临家Α
        public IActionResult ReturnBookMode()
        {
            return PartialView("~/Views/ReturnBook/_ReturnBookPartial.cshtml");
        }
        public IActionResult ReturnBookSend(string ReturnBookID)
        {
            Debug.WriteLine($"綷{ReturnBookID}临Θ");
            return PartialView("~/Views/ReturnBook/_ReturnBookContent.cshtml");
        }
        #endregion 临家Α END

        #region 箇家Α
        public IActionResult AppointmentMode1()
        {
            Debug.WriteLine("箇家Α更Θ...............");
            return Ok();
        }
        public IActionResult Appoimt2()
        {
            Debug.WriteLine("箇家Α更Θ...............");
            return Ok();
        }
        #endregion
        //------------------------------------------------------------------------------------------
    }
}
