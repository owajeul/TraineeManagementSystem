using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TraineeManagementSystem.Database;
using TraineeManagementSystem.Models;

namespace TraineeManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly InmemoryDatabase _db;

        public HomeController(InmemoryDatabase db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var trainees = _db.Get();
            return View(trainees);
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
