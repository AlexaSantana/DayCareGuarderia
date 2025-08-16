using System.ComponentModel.DataAnnotations;

namespace DayCareGuarderia.Models.Entities
{
    public class Parent
    {
        [Key]
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string? Occupation { get; set; }
        public string? WorkPhoneNumber { get; set; }
        public string? Email { get; set; }
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
