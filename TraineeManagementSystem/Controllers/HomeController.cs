using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TraineeManagementSystem.Database;
using TraineeManagementSystem.Models;

namespace TraineeManagementSystem.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly InmemoryDatabase _db;

        public HomeController(InmemoryDatabase db)
        {
            _db = db;
        }
        [Route("")]
        public IActionResult Index()
        {
            var trainees = _db.Get();
            return View(trainees);
        }
    }
}
