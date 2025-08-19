
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services.LeaveAllocations
{
    public class LeaveAllocationsService(ApplicationDbContext _context) : ILeaveAllocationsService
    {
        public async Task AllocateLeave(string employeeId)
        {
            // Get all the Leave Types
            var leaveTypes =  await _context.LeaveTypes.ToListAsync();

           // Get the current period based on the year
           var currentDate = DateTime.Now;
           var period = await _context.Periods.SingleAsync(p=>p.EndDate.Year == currentDate.Year);

           // Calculate leave based on number of months left in the period
           var monthsRemaining = period.EndDate.Month - currentDate.Month;

            // Foreach leave type, create an allocation entry
            foreach (var leaveType in leaveTypes)
            {
                var accuralRate = decimal.Divide(leaveType.NumberOfDays, 12);
                var leaveAllocation = new LeaveAllocation
                {
                    EmployeeId = employeeId,
                    LeaveTypeId = leaveType.Id,
                    PeriodId = period.Id,
                    Days = (int)Math.Ceiling(accuralRate * monthsRemaining)
                };
                _context.Add(leaveAllocation);
            }
            await _context.SaveChangesAsync();
        }
    }
}
