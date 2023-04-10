using EmployeesManagement.Data.Repositories;
using EmployeesManagement.Domain.Models;
using EmployeesManagement.Data.Repositories;

namespace EmployeesManagement.Foundation.Services
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPositionRepository _positionRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IPositionRepository positionRepository)
        {
            _employeeRepository = employeeRepository;
            _positionRepository = positionRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            return await _employeeRepository.CreateEmployeeAsync(newEmployee);
        }

        public async Task<Employee> UpdateEmployee(int id, Employee updatedEmployee)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                throw new ArgumentException("Employee not found", nameof(id));
            }

            employee.FirstName = updatedEmployee.FirstName;
            employee.SecondName = updatedEmployee.SecondName;
            employee.Patronymic = updatedEmployee.Patronymic;
            employee.BirthDate = updatedEmployee.BirthDate;

            return await _employeeRepository.UpdateEmployeeAsync(employee);
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                throw new ArgumentException("Employee not found", nameof(id));
            }

            await _employeeRepository.DeleteEmployeeAsync(employee);
        }

        public async Task AddRoleToEmployeeAsync(int employeeId, int positionId)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            var position = await _positionRepository.GetPositionByIdAsync(positionId);

            employee.Positions.Add(position);
        }

        public async Task RemoveRoleFromEmployeeAsync(int employeeId, int positionId)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            var position = await _positionRepository.GetPositionByIdAsync(positionId);

            employee.Positions.Remove(position);
        }
    }
}
