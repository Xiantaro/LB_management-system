using Microsoft.AspNetCore.Mvc;

namespace library_management_system.Models
{
    public class ReturingBookViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(string bookid)
        {  
            return View("Returing", "我回來啦");
        }
    }   
}
