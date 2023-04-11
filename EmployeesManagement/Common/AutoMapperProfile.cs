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

            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(dest => dest.BirthDate, opt => opt
                    .MapFrom(src => src.BirthDate.Date));
            CreateMap<CreatePositionDto, Position>();

            CreateMap<UpdateEmployeeDto, Employee>()
                .ForMember(dest => dest.BirthDate, opt => opt
                    .MapFrom(src => src.BirthDate.Date));
            CreateMap<UpdatePositionDto, Position>();
        }
    }
}
