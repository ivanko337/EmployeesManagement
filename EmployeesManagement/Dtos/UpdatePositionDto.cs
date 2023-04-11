namespace EmployeesManagement.Dtos
{
    public class UpdatePositionDto : BaseDto
    {
        public string Title { get; set; } = default!;
        public int Grade { get; set; }
    }
}
