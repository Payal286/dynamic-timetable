﻿using System.ComponentModel.DataAnnotations;

namespace dynamic_timetable.Models
{
    public class TimeTableInputModel
    {
        [Range(1, 7, ErrorMessage = "Working days must be between 1 and 7.")]
        public int WorkingDays { get; set; }

        [Range(1, 8, ErrorMessage = "Subjects per day must be less than 9.")]
        public int SubjectsPerDay { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Total subjects must be greater than 0.")]
        public int TotalSubjects { get; set; }

        public int TotalHours => WorkingDays * SubjectsPerDay;
    }
}
