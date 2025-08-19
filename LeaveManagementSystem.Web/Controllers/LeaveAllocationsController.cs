using LeaveManagementSystem.Web.Services.LeaveAllocations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LeaveManagementSystem.Web.Controllers
{
    [Authorize]
    public class LeaveAllocationsController(ILeaveAllocationsService _leaveAllocationService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var leaveAllocations = await _leaveAllocationService.GetAllocations();
            return View();
        }
    }
}
