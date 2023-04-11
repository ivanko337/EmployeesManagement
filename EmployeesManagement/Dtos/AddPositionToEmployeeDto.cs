namespace EmployeesManagement.Dtos
{
    public class AddPositionToEmployeeDto : BaseDto
    {
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
    }
}
