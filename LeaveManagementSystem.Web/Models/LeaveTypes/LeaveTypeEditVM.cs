using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models.LeaveTypes
{
    public class LeaveTypeEditVM
    {
        public int Id { get; set; }
        [Required]
        [Length(4, 25, ErrorMessage = "You have violated the characters limit")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(1, 90, ErrorMessage = "You have violated the days limit")]
        public int Days { get; set; }
    }
}
