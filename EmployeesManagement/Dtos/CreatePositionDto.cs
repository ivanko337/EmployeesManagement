namespace EmployeesManagement.Dtos
{
    public class CreatePositionDto : BaseDto
    {
        public string Title { get; set; } = default!;
        public int Grade { get; set; }
    }
}
