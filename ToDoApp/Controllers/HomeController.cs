using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Diagnostics;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UygulamaDbContext _db;

        public HomeController(ILogger<HomeController> logger, UygulamaDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            List<toDo> toDoList = _db.ToDos.OrderBy(x => x.Done).ToList();
            return View(toDoList);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Index(string id)
        {
            _db.ToDos.Add(new toDo() { Title = id, Done = false });
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Update(int[] dones)
        {
            var items=_db.ToDos.ToList();

            foreach(var item in items)
            {
                item.Done = dones.Contains(item.Id);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            toDo toDo = _db.ToDos.Find(id);
            if(toDo==null)
                return NotFound();
            _db.ToDos.Remove(toDo);
            _db.SaveChanges();
            return RedirectToAction("Index");
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
    }
}
