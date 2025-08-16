using System.ComponentModel.DataAnnotations;

namespace DayCareGuarderia.Models.Entities
{
    public class Child
    {
        [Key]
        public int ChildId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string ParentId { get; set; }
        public string BirthDate { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
