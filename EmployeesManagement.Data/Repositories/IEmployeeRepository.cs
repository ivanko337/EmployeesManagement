using EmployeesManagement.Domain.Models;
using System.Linq.Expressions;

namespace EmployeesManagement.Data.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> GetFirstOrDefaultAsync<TKey>(Expression<Func<Employee, TKey>> orderBy, Expression<Func<Employee, bool>> predicate = null);
        Task<Employee> CreateEmployeeAsync(Employee newEmployee);
        Task<bool> ExistsAsync(int id);
        Task<Employee> UpdateEmployeeAsync(Employee updatedEmployee);
        Task DeleteEmployeeAsync(Employee employee);
    }
}