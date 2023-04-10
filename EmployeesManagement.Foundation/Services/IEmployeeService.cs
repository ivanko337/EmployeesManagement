using EmployeesManagement.Domain.Models;

namespace EmployeesManagement.Foundation.Services
{
    public interface IEmployeeService
    {
        Task AddRoleToEmployeeAsync(int employeeId, int positionId);
        Task<Employee> CreateEmployee(Employee newEmployee);
        Task DeleteEmployee(int id);
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task RemoveRoleFromEmployeeAsync(int employeeId, int positionId);
        Task<Employee> UpdateEmployee(int id, Employee updatedEmployee);
    }
}