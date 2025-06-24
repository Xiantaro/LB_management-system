using Microsoft.AspNetCore.Mvc;

namespace library_management_system.Models
{
    public class AppointmentQueryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Default", "預約查詢元件載入成功！");
        }
    }
}
