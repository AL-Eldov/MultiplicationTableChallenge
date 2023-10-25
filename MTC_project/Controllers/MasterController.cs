using Microsoft.AspNetCore.Mvc;

namespace MTC_project.Controllers
{
    public class MasterController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
        public IActionResult RulesPage()
        {
            return View();
        }
       /* public IActionResult RanksPage()
        {
            return View();
        }*/
        public IActionResult AboutSitePage()
        {
            return View();
        }
    }
}
