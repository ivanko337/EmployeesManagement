namespace EmployeesManagement.Dtos
{
    public class CreatePositionDto
    {
        public string Title { get; set; } = default!;
        public int Grade { get; set; }
    }
}
