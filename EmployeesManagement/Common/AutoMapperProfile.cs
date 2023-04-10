using AutoMapper;
using EmployeesManagement.Domain.Models;
using EmployeesManagement.Dtos;

namespace EmployeesManagement.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, GetEmployeeDto>();
            CreateMap<Position, GetPositionDto>();

            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<CreatePositionDto, Position>();

            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<UpdatePositionDto, Position>();
        }
    }
}
