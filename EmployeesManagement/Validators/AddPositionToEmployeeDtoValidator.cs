using EmployeesManagement.Data.Repositories;
using EmployeesManagement.Dtos;
using FluentValidation;

namespace EmployeesManagement.Validators
{
    public class AddPositionToEmployeeDtoValidator : AbstractValidator<AddPositionToEmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPositionRepository _positionRepository;

        public AddPositionToEmployeeDtoValidator(
            IEmployeeRepository employeeRepository,
            IPositionRepository positionRepository)
        {
            _employeeRepository = employeeRepository;
            _positionRepository = positionRepository;

            RuleFor(x => x.EmployeeId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MustAsync(EmployeeExists)
                .DependentRules(() =>
                {
                    RuleFor(x => x.PositionId)
                        .MustAsync(EmployeeAlreadyHavePosition)
                        .WithMessage("Employee already have this position");
                })
                .WithMessage("Employee does not exists");

            RuleFor(x => x.PositionId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MustAsync(PositionExists)
                .WithMessage("Position does not exists");
        }

        private async Task<bool> EmployeeExists(int id, CancellationToken token)
        {
            return await _employeeRepository.ExistsAsync(id);
        }

        private async Task<bool> PositionExists(int id, CancellationToken token)
        {
            return await _positionRepository.ExistsAsync(id);
        }

        private async Task<bool> EmployeeAlreadyHavePosition(AddPositionToEmployeeDto dto, int positionId, CancellationToken token)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(dto.EmployeeId);
            return employee.Positions.FirstOrDefault(p => p.Id == positionId) == null;
        }
    }
}
