using System.ComponentModel.DataAnnotations;

namespace DayCareGuarderia.Models.Entities
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string PhoneNumber { get; set; }
        [MaxLength(10)]
        public string Address { get; set; }
    }
}
