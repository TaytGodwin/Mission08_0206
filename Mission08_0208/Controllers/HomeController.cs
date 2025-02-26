using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Mission8_0206.Models;
using ModelTask = Mission8_0206.Models.Task; // This is because Task is a word already using in dotnet

namespace Mission8_0206.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository _repo; // Variable to hold instance of repository
        public HomeController(ITaskRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            ViewBag.Tasks = _repo.Tasks
                .OrderBy(x => x.TaskId)
                .Where(x => x.Completed == false) // Only return incomplete tasks
                .ToList();

            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();


            return View();
        }

        // Adding tasks
        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();

            return View(new ModelTask()); // Send an instance of a task
        }
        [HttpPost]
        public IActionResult AddTask(ModelTask t)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(t); // Add a taks to the database

                return View();
            }
            else
            {
                ViewBag.Categories = _repo.Categories
                    .OrderBy(x => x.CategoryId)
                    .ToList();

                return View(t); // Send an instance of a task
            }

        }

        // Deleteing Tasks
        [HttpGet]
        public IActionResult DeleteTask(int Id)
        {
            ModelTask taskToDelete = _repo.Tasks // Get the task to delete
                .Where(x => x.TaskId == Id)
                .Single();

            return View("DeleteTask", taskToDelete); // Return the task to the view
        }
        [HttpPost]
        public ActionResult DeleteTask(ModelTask taskToDelete)
        {
            _repo.Delete(taskToDelete);

            return RedirectToAction("Index");
        }

        // Updating tasks
        [HttpGet]
        public IActionResult EditTask(int Id)
        {
            ModelTask recordToEdit = _repo.Tasks // Get the task to edit
                .Where(x => x.TaskId == Id)
                .Single();

            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryId)
                .ToList();

            return View("AddTask", recordToEdit);
        }
        [HttpPost]
        public IActionResult EditTask(ModelTask taskToEdit)
        {
            if (ModelState.IsValid) // Check if it fits in model
            {
                _repo.EditTask(taskToEdit);

                return RedirectToAction("Index");
            }
            else // If it doesn't fit, have them enter it again
            {
                ViewBag.Categories = _repo.Categories
                    .OrderBy(x => x.CategoryId)
                    .ToList();

                return View("AddTask", taskToEdit);
            }
        }
    }
}