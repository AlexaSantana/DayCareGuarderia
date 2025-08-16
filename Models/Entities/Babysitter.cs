using System.ComponentModel.DataAnnotations;

namespace DayCareGuarderia.Models.Entities
{
    public class Babysitter
    {
        [Key]
        public int BabysitterId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string? Email { get; set; }
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
