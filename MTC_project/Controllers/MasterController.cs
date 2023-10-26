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
        public async Task<IActionResult> EnterUser(User user)
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
            user.Rank = Ranks.Rank0;
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

        public async Task<IActionResult> PlayPage(int id)
        {
            User? user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> PlayPage(int id, int correctAnswer, int userAnswer)
        {
            User? user = await db.Users.FirstOrDefaultAsync(p => p.Id == id);
            if (user is not null && userAnswer == correctAnswer)
            {
                user.Rating += 1;
                db.Users.Update(user);
                await db.SaveChangesAsync();
            }
            return View(user);
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////
        /// </summary>

        public async Task<IActionResult> ChampionPage(string name, Ranks rank, int page = 1,
            SortState sortOrder = SortState.NameAsc)
        {
            int pageSize = 5;//Наличие магического числа не очень хорошо, но здесь вроде понятно что оно нужно для пагинации 

            //фильтрация
            IQueryable<User> users = db.Users;

            if (!string.IsNullOrEmpty(name))
            {
                users = users.Where(p => p.Name!.Contains(name));
            }
            if (rank != Ranks.RankAll)
            {
                users = users.Where(p => p.Rank == rank);
            }

            // сортировка
            switch (sortOrder)// большой свич в коде не очень хорош его нужно прятать в отдельный класс, но мне лень
            {
                case SortState.NameDesc:
                    users = users.OrderByDescending(s => s.Name);
                    break;
                case SortState.RankDesc:
                    users = users.OrderByDescending(s => s.Rank);
                    break;
                case SortState.RankAsc:
                    users = users.OrderByDescending(s => s.Rank);
                    break;
                default:
                    users = users.OrderBy(s => s.Name);
                    break;
            }

            // пагинация
            var count = await users.CountAsync();
            var items = await users.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel(
                items,
                new PageViewModel(count, page, pageSize),
                new FilterViewModel(db.Users.ToList(), name, rank),
                new SortViewModel(sortOrder)
            );
            return View(viewModel);
        }
    }
}
