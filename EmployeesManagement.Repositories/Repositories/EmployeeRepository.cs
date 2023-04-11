using EmployeesManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeesManagement.Data.Repositories
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeesDbContext _context;

        public EmployeeRepository(EmployeesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await GetQuery().ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await GetQuery().SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee newEmployee)
        {
            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();

            return newEmployee;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee updatedEmployee)
        {
            _context.Update(updatedEmployee);
            await _context.SaveChangesAsync();

            return updatedEmployee;
        }

        public async Task DeleteEmployeeAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetFirstOrDefaultAsync<TKey>(
            Expression<Func<Employee, TKey>> orderBy,
            Expression<Func<Employee, bool>> predicate = null)
        {
            IQueryable<Employee> query = GetQuery();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = query.OrderBy(orderBy);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Employees.AnyAsync(e => e.Id == id);
        }

        private IQueryable<Employee> GetQuery()
        {
            return _context.Employees.Include(e => e.Positions);
        }
    }
}
