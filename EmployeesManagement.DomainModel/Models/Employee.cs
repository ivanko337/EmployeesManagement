namespace EmployeesManagement.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string SecondName { get; set; } = default!;
        public string Patronymic { get; set; } = default!;
        public DateTime BirthDate { get; set; }

        public ICollection<Position> Positions { get; set; } = default!;

        public ICollection<EmployeePosition> EmployeePositions { get; set; } = default!;
    }
}
