using Microsoft.AspNetCore.Mvc;
using TraineeManagementSystem.Database;
using TraineeManagementSystem.Models;

namespace TraineeManagementSystem.Controllers
{
    [Route("trainee")]
    public class TraineeManagementController : Controller
    {
        private readonly InmemoryDatabase _db;
        public TraineeManagementController(InmemoryDatabase db)
        {
            _db = db;
        }

        [HttpGet("add")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("add")]
        public IActionResult Create(Trainee trainee)
        {
            if (!ModelState.IsValid)
            {
                return View(trainee);
            }
            _db.Add(trainee);
            TempData["ToastrMessage"] = "Trainee added successfully";
            TempData["ToastrType"] = "success";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var trainee = _db.Get(id);
            return View(trainee);
        }

        [HttpPost("edit/{id}")]
        public IActionResult Edit(int id, Trainee trainee)
        {
            var traineeToUpdate = _db.Get(id);
            if (traineeToUpdate == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(trainee);
            }
            _db.Update(trainee);
            TempData["ToastrMessage"] = "Trainee updated successfully";
            TempData["ToastrType"] = "success";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var trainee = _db.Get(id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        [HttpPost("delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var trainee = _db.Get(id);
            if (trainee == null)
            {
                return NotFound();
            }

            _db.Remove(trainee);
            TempData["ToastrMessage"] = "Trainee deleted successfully";
            TempData["ToastrType"] = "success";
            return RedirectToAction("Index", "Home");
        }
    }
}
