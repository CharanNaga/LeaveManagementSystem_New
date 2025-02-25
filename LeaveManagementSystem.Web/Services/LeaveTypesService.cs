using AutoMapper;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveTypes;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Services
{
    public class LeaveTypesService : ILeaveTypesService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public LeaveTypesService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LeaveTypeReadOnlyVM>> GetAll()
        {
            //var data = 'SELECT * FROM LeaveTypes';
            var data = await _context.LeaveTypes.ToListAsync();

            //convert the data model into view model using AutoMapper
            var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);

            return viewData;
        }

        public async Task<T?> Get<T>(int id) where T : class
        {
            //var leaveType = 'SELECT * FROM LeaveTypes where Id = @id';

            var leaveType = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (leaveType == null)
            {
                return null;
            }

            //convert data model into view model using AutoMapper
            var viewData = _mapper.Map<T>(leaveType);
            return viewData;
        }

        public async Task Remove(int id)
        {
            var leaveType = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (leaveType != null)
            {
                _context.Remove(leaveType);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Edit(LeaveTypeEditVM model)
        {
            var leaveType = _mapper.Map<LeaveType>(model);
            _context.Update(leaveType);
            await _context.SaveChangesAsync();
        }

        public async Task Create(LeaveTypeCreateVM model)
        {
            var leaveType = _mapper.Map<LeaveType>(model);
            _context.Add(leaveType);
            await _context.SaveChangesAsync();
        }

        private bool LeaveTypeExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }

        private async Task<bool> CheckIfLeaveTypeNameAlreadyExists(string name)
        {
            var lowerCaseName = name.ToLower();
            return await _context.LeaveTypes.AnyAsync(l => l.Name.ToLower().Equals(lowerCaseName));
        }

        private async Task<bool> CheckIfLeaveTypeNameAlreadyExistsForEdit(LeaveTypeEditVM leaveTypeEdit)
        {
            var lowerCaseName = leaveTypeEdit.Name.ToLower();
            return await _context.LeaveTypes.AnyAsync(
                l => l.Name.ToLower().Equals(lowerCaseName)
                && l.Id != leaveTypeEdit.Id);
        }
    }
}