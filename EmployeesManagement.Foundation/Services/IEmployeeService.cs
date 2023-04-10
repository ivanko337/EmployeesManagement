using EmployeesManagement.Domain.Models;

namespace EmployeesManagement.Foundation.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> CreateEmployeeAsync(Employee newEmployee);
        Task<Employee> UpdateEmployeeAsync(int id, Employee updatedEmployee);
        Task DeleteEmployeeAsync(int id);
        Task AddRoleToEmployeeAsync(int employeeId, int positionId);
        Task RemoveRoleFromEmployeeAsync(int employeeId, int positionId);
    }
}