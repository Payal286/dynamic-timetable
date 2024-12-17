using dynamic_timetable.Models;
using Microsoft.AspNetCore.Mvc;

namespace dynamic_timetable.Controllers
{
    public class DynamicTimeTableController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new TimeTableInputModel());
        }

        [HttpPost]
        public IActionResult SubjectHours(TimeTableInputModel input)
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
        public IActionResult Generate(List<SubjectModel> subjects)
        {
            int totalHours = (int)TempData["TotalHours"];
            int sumHours = subjects.Sum(s => s.Hours);

            if (sumHours != totalHours)
            {
                ModelState.AddModelError("", $"Total hours must equal {totalHours}");
                return View("SubjectHours", subjects);
            }

            // Generate subject pool
            var subjectPool = new List<string>();
            foreach (var subject in subjects)
            {
                subjectPool.AddRange(Enumerable.Repeat(subject.SubjectName, subject.Hours));
            }

            // Shuffle subjects
            var rnd = new Random();
            subjectPool = subjectPool.OrderBy(x => rnd.Next()).ToList();

            var timetable = new TimeTableModel
            {
                Subjects = subjectPool,
                WorkingDays = (int)TempData["WorkingDays"],
                SubjectsPerDay = (int)TempData["SubjectsPerDay"]
            };

            return View(timetable);
        }
    }
}
