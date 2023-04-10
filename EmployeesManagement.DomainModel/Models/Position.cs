namespace EmployeesManagement.Domain.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public int Grade { get; set; }

        public ICollection<Employee> Employees { get; set; } = default!;

        public ICollection<EmployeePosition> EmployeePositions { get; set; } = default!;
    }
}
