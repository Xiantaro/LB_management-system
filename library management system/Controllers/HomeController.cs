using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using library_management_system.Models;
using Microsoft.AspNetCore.Mvc;

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
        #region 預約管理&查詢
        // 預約管理_搜尋排列_partial
        
        public IActionResult AppointmentQuery()
        {
            return PartialView("_AppointmentQueryPartial");
        }
        //預約管理_查詢列表_partial
       
        public IActionResult AppointmentResult(string appointment_reservationNum = "All", string appointment_UserID = "我是ID", string appointment_bookNum = "持續買進", DateTime? appointment_initDate = null, DateTime? appointment_lastDate = null, string? appointment_state = "All", string appointment_perPage = "10", string appointment_orderDate = "desc", int page = 1)
        {
            Debug.WriteLine("測試載入:  預約ID:" + appointment_reservationNum + " 使用者ID:" + appointment_UserID + " 書本名稱:" + appointment_bookNum + " 開始日期:" + appointment_initDate + " 今天日期:" + appointment_lastDate + " 狀態:" + appointment_state + " 頁數:" + appointment_perPage + " 日期排序:" + appointment_orderDate + "頁數" + page);
            return PartialView("_AppointmentResultPartial");
        }
        public IActionResult AppointmentCancel(string appointmentid)
        {
            Debug.WriteLine($"測試回傳取消預約編號: {appointmentid}");
            return Ok();
        }
        #endregion

        #region 借閱查詢
            // 借閱查詢_搜尋排列_partial
        public IActionResult BorrowQuery()
        {
            return PartialView("_BorrowQueryPartial");
        }
        // 借閱查詢_查詢列表_partial
        public IActionResult BorrowResult(string borrow_BorrowID = "All", string borrow_UserID = "All", string borrow_bookNum = "All", string borrow_state = "All", string borrow_perPage = "10", string borrow_date = "borrowDate", string borrow_orderDate = "desc", int page = 1)
        {
            Debug.WriteLine($"測試借閱載入 {borrow_BorrowID}+{borrow_UserID} + {borrow_bookNum} + {borrow_state} + {borrow_perPage} + {borrow_date} + {borrow_orderDate} + 頁數: {page}");
            return PartialView("_BorrowResultPartial");
        }
        #endregion

        #region 借閱、預約模式
        // 借書模式_partial
        public IActionResult BorrowMode()
        {
            return PartialView("_BorrowModePartial");
        }
        // 借書模式_借書
        public IActionResult BorrowSend(string borrwoMode_UserID, string borrwoMode_BookNumber)
        {
            #region 測試回傳可刪
            //var mystatu = new BorrowModeSendClass();
            //if (borrwoMode_UserID != "1234")
            //{
            //    mystatu.IsSuccess = false;
            //    mystatu.MistakeMessag = "借閱者不存在";
            //    return PartialView("_BorrowModeContent", mystatu);
            //}
            //if (borrwoMode_BookNumber != "1234")
            //{
            //    mystatu.IsSuccess = false;
            //    mystatu.MistakeMessag = "書本不存在";
            //    return PartialView("_BorrowModeContent", mystatu);
            //}
            //Debug.WriteLine($"成功借書 ID:{borrwoMode_UserID} BookID: {borrwoMode_BookNumber}");
            //mystatu.UserId = borrwoMode_UserID;
            //mystatu.BookName = borrwoMode_BookNumber;
            #endregion 
            return PartialView("_BorrowModeContent");
        }
        // 預約模式_預約
        public IActionResult AppointmentSend(string borrwoMode_UserID, string borrwoMode_BookNumber)
        {
            Debug.WriteLine($"使用者: {borrwoMode_UserID} ；書籍ID {borrwoMode_BookNumber}");
            return PartialView("_BorrowModeContent");
        }
        // 借書模式_借書人資訊
        public IActionResult BorrowUserMessage(string userId)
        {
            // 之後要建立 ViewModel 用來裝搜尋到的 借書人資訊
            // 並回傳到 PartialView 上
            Debug.WriteLine(userId);
            return PartialView("_BorrowModeUser");
        }
        // 借書模式_書本資訊
        public IActionResult BorrowBookMessage(string bookId)
        {
            // 之後要建立 ViewModel 用來裝搜尋到的 書本資訊
            // 並回傳到 PartialView 上
            Debug.WriteLine(bookId);
            return PartialView("_BorrowModeBook");
        }
        #endregion 借閱模式END

        #region 還書模式
        public IActionResult ReturnBookMode()
        {
            return PartialView("_ReturnBookPartial");
        }
        public IActionResult ReturnBookSend(string ReturnBookID)
        {
            Debug.WriteLine($"借閱者{ReturnBookID}還書成功");
            return PartialView("_ReturnBookContent");
        }
        #endregion 還書模式 END
        //------------------------------------------------------------------------------------------
    }
}
