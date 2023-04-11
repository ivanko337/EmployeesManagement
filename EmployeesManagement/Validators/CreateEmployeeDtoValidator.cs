using EmployeesManagement.Dtos;
using FluentValidation;

namespace EmployeesManagement.Validators
{
    public class CreateEmployeeDtoValidator : AbstractValidator<CreateEmployeeDto>
    {
        public CreateEmployeeDtoValidator()
        {
            RuleFor(e => e.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();

            RuleFor(e => e.SecondName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();

            RuleFor(e => e.Patronymic)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();

            RuleFor(e => e.BirthDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must(db => db.Date <= DateTime.Now.Date.AddYears(-18))
                .WithMessage("Employee must be of legal age");
        }
    }
}
