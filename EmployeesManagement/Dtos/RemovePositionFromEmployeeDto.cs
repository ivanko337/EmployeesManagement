namespace EmployeesManagement.Dtos
{
    public class RemovePositionFromEmployeeDto : BaseDto
    {
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
    }
}
