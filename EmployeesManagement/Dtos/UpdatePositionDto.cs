namespace EmployeesManagement.Dtos
{
    public class UpdatePositionDto
    {
        public string Title { get; set; } = default!;
        public int Grade { get; set; }
    }
}
