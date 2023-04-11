namespace EmployeesManagement.Dtos
{
    public class GetPositionDto : BaseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public int Grade { get; set; }
    }
}
