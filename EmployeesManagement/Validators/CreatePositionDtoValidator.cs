using EmployeesManagement.Dtos;
using FluentValidation;

namespace EmployeesManagement.Validators
{
    public class CreatePositionDtoValidator : AbstractValidator<CreatePositionDto>
    {
        public CreatePositionDtoValidator()
        {
            RuleFor(p => p.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty();

            RuleFor(p => p.Grade)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .InclusiveBetween(1, 15);
        }
    }
}
