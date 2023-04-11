namespace EmployeesManagement.Dtos
{
    public class GetEmployeeDto : BaseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string SecondName { get; set; } = default!;
        public string Patronymic { get; set; } = default!;
        public DateTime BirthDate { get; set; }

        public IEnumerable<GetPositionDto> Positions { get; set; } = default!;
    }
}
