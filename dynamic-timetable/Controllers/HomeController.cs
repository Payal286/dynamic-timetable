using System.Diagnostics;
using dynamic_timetable.Models;
using Microsoft.AspNetCore.Mvc;

namespace dynamic_timetable.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new TimeTableInputModel());
        }

        [HttpPost]
        public IActionResult Subject(TimeTableInputModel input)
        {
            if (!ModelState.IsValid)
                return View("Index", input);

            TempData["WorkingDays"] = input.WorkingDays;
            TempData["SubjectsPerDay"] = input.SubjectsPerDay;
            TempData["TotalHours"] = input.TotalHours;
            TempData["TotalSubjects"] = input.TotalSubjects;

            var subjects = new List<SubjectModel>();
            for (int i = 0; i < input.TotalSubjects; i++)
            {
                subjects.Add(new SubjectModel { SubjectName = $"Subject {i + 1}" });
            }

            return View(subjects);
        }

        [HttpPost]

        public IActionResult GenerateTimeTable(List<SubjectModel> subjects)
        {
            if (TempData["TotalHours"] == null || TempData["WorkingDays"] == null || TempData["SubjectsPerDay"] == null)
            {
                ViewData["ErrorMessage"] = "Required data is missing. Please start over.";
                return RedirectToAction("Index"); 
            }

            int totalHours = (int)TempData["TotalHours"];
            int workingDays = (int)TempData["WorkingDays"];
            int subjectsPerDay = (int)TempData["SubjectsPerDay"];

            if (subjects == null || subjects.Count == 0)
            {
                ViewData["ErrorMessage"] = "Subjects data is missing. Please enter the details again.";
                return RedirectToAction("Subject"); 
            }

            int sumHours = subjects.Sum(s => s.Hours);

            if (sumHours != totalHours)
            {
                ViewData["ErrorMessage"] = $"Total hours must equal {totalHours}";
                ModelState.AddModelError("", $"Total hours must equal {totalHours}");
                return View("Subject", subjects);
            }

            var subjectPool = new List<string>();
            foreach (var subject in subjects)
            {
                subjectPool.AddRange(Enumerable.Repeat(subject.SubjectName, subject.Hours));
            }

            var rnd = new Random();
            subjectPool = subjectPool.OrderBy(x => rnd.Next()).ToList();

            var timetable = new TimeTableModel
            {
                Subjects = subjectPool,
                WorkingDays = workingDays,
                SubjectsPerDay = subjectsPerDay
            };

            return View("TimeTable", timetable);
        }
    }
}
