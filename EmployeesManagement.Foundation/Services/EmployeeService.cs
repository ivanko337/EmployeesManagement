using EmployeesManagement.Data.Repositories;
using EmployeesManagement.Domain.Models;

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

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task<Employee> CreateEmployeeAsync(Employee newEmployee)
        {
            return await _employeeRepository.CreateEmployeeAsync(newEmployee);
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, Employee updatedEmployee)
        {
            var exists = await _employeeRepository.ExistsAsync(id);
            if (!exists)
            {
                throw new ArgumentException("Employee not found", nameof(id));
            }

            return await _employeeRepository.UpdateEmployeeAsync(updatedEmployee);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                throw new ArgumentException("Employee not found", nameof(id));
            }

            await _employeeRepository.DeleteEmployeeAsync(employee);
        }

        public async Task AddPositionToEmployeeAsync(int employeeId, int positionId)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            var position = await _positionRepository.GetPositionByIdAsync(positionId);

            employee.Positions.Add(position);

            await _employeeRepository.UpdateEmployeeAsync(employee);
        }

        public async Task RemovePositionFromEmployeeAsync(int employeeId, int positionId)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
            var position = await _positionRepository.GetPositionByIdAsync(positionId);

            employee.Positions.Remove(position);

            await _employeeRepository.UpdateEmployeeAsync(employee);
        }
    }
}
