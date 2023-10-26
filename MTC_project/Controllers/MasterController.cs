using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTC_project.Models;

namespace MTC_project.Controllers
{
    public class MasterController : Controller
    {
        UsersContext db;
        public MasterController(UsersContext context)
        {
            db = context;
        }
        public IActionResult HomePage()
        {
            return View();
        }
        public IActionResult EnterUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  EnterUser(User user)
        {
            User? realUser = await db.Users.FirstOrDefaultAsync(p => p.Name == user.Name && p.Password == user.Password);
            if (user != null) return View("HomePagePlay", realUser);
            return NotFound();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return View("HomePagePlay", await db.Users.FirstOrDefaultAsync(p => p.Name == user.Name && p.Password == user.Password));
        }
        public IActionResult RulesPage()
        {
            return View();
        }
        public IActionResult RanksPage()
        {
            return View();
        }
        public IActionResult AboutSitePage()
        {
            return View();
        }

        public IActionResult PlayPage(User user)
        {
            return View();
        }
        /*[HttpPost]
        public async Task<IActionResult> PlayPage(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("PlayPage");
        }*/
    }
}
