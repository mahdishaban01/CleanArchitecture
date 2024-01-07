using System.ComponentModel.DataAnnotations;

namespace HR_Management.MVC.Models
{
    public class CreateLeaveTypeVM : LeaveTypeVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Default Number of Days")]
        public int DefaultDay { get; set; }
    }
}
