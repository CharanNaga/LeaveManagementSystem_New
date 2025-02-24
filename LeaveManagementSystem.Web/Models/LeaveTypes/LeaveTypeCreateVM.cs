using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeCreateVM
    {
        [Required]
        [Length(4,25,ErrorMessage ="You have violated the characters limit")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(1,90,ErrorMessage ="You have violated the days limit")]
        [Display(Name = "Maximum Allocation of Days")]
        public int Days { get; set; }
    }
}
