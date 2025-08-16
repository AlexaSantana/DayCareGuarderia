namespace DayCareGuarderia.Models.Entities
{
    public class AttendanceDetail
    {
        public int AttendanceDetailId { get; set; }
        public int AttendanceId { get; set; }
        public int BabysitterId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDescription { get; set; }
        public string ActivityDate { get; set; }
        public string ActivityTime { get; set; }
        public string ActivityLocation { get; set; }
        public Attendance Attendance { get; set; }
        public Babysitter Babysitter { get; set; } 
    }
}
