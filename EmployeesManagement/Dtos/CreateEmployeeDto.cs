﻿namespace EmployeesManagement.Dtos
{
    public class CreateEmployeeDto : BaseDto
    {
        public string FirstName { get; set; } = default!;
        public string SecondName { get; set; } = default!;
        public string Patronymic { get; set; } = default!;
        public DateTime BirthDate { get; set; }
    }
}
