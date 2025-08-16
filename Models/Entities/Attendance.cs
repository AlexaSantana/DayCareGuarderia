using System.ComponentModel.DataAnnotations;

namespace DayCareGuarderia.Models.Entities
{
    public class Attendance
    {
        [Key]
        public string AttendanceId { get; set; }
        public int ChildId { get; set; }  
        public DateTime Date { get; set; }
        public bool Present { get; set; }

        public List<AttendanceDetail> AttendanceDetails { get; set; } 
        public int? BabysitterId { get; set; }
        public Babysitter Babysitter { get; set; }
        public Child Child { get; set; } 
        public int? ParentId { get; set; }
        public Parent Parent { get; set; }

        public Attendance() { }

        public Attendance(int childId, DateTime date, bool present)
        {
            ChildId = childId;
            Date = date;
            Present = present;
        }
    }
}