namespace EmployeesManagement.Domain.Models
{
    public class EmployeePosition
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = default!;

        public int PositionId { get; set; }
        public Position Position { get; set; } = default!;
    }
}
