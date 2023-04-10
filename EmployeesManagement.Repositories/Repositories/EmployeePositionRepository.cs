using Microsoft.EntityFrameworkCore;

namespace EmployeesManagement.Data.Repositories
{
    internal class EmployeePositionRepository : IEmployeePositionRepository
    {
        private readonly EmployeesDbContext _context;

        public EmployeePositionRepository(EmployeesDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetEmployeesCountForPositionAsync(int positionId)
        {
            return await _context.EmployeePositions
                .Where(ep => ep.PositionId == positionId)
                .CountAsync();
        }
    }
}
