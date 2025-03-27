using Microsoft.AspNetCore.Mvc;
using TraineeManagementSystem.Database;
using TraineeManagementSystem.Models;

namespace TraineeManagementSystem.Controllers
{
    public class TraineeManagementController : Controller
    {
        private readonly InmemoryDatabase _db;
        public TraineeManagementController(InmemoryDatabase db)
        {
            _db = db;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Trainee trainee)
        {
            if(!ModelState.IsValid)
            {

                return View(trainee);
            }
            _db.Add(trainee);
            TempData["ToastrMessage"] = "Trainee added successfully";
            TempData["ToastrType"] = "success";
            return RedirectToAction("Index", "Home");
        } 

        public IActionResult Edit(int Id)
        {
            var trainee = _db.Get(Id);
            return View(trainee);
        }

        [HttpPost]
        public IActionResult Edit(Trainee trainee)
        {
            if(!ModelState.IsValid)
            {
                return View(trainee);
            }
            _db.Update(trainee);
            TempData["ToastrMessage"] = "Trainee updated successfully";
            TempData["ToastrType"] = "success";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            var trainee = _db.Get(id);
            if (trainee == null)
            {
                return NotFound(); 
            }

            return View(trainee);  
        }

        [HttpPost]
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
