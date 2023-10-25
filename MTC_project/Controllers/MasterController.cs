using Microsoft.AspNetCore.Mvc;

namespace MTC_project.Controllers
{
    public class MasterController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
