using System.ComponentModel.DataAnnotations;

namespace dynamic_timetable.Models
{
    public class SubjectModel
    {
        public string SubjectName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Hours must be greater than 0.")]
        public int Hours { get; set; }
    }
}
