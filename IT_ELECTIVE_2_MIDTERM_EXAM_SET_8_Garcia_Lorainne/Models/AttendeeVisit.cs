using System.ComponentModel.DataAnnotations;

namespace IT_ELECTIVE_2_MIDTERM_EXAM_SET_8_Garcia_Lorainne.Models
{
    public class AttendeeVisit
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ticket Number")]
        [StringLength(50)]
        public string TicketNumber { get; set; } = string.Empty;

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Company/School")]
        [StringLength(100)]
        public string Organization { get; set; } = string.Empty;

        [Required]
        [Phone]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Event Name")]
        [StringLength(100)]
        public string EventName { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        [Display(Name = "Check-In Time")]
        public DateTime CheckInTime { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Check-Out Time")]
        public DateTime? CheckOutTime { get; set; }

        public string Status { get; set; } = "Present";

        [StringLength(500)]
        public string? Notes { get; set; }
    }
}