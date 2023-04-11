using AutoMapper;
using EmployeesManagement.Domain.Models;
using EmployeesManagement.Dtos;
using EmployeesManagement.Foundation.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetEmployeeDto>>> GetAllEmployeesAsync()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(_mapper.Map<IEnumerable<GetEmployeeDto>>(employees));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetEmployeeDto>> GetEmployeeByIdAsync(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);
                return Ok(_mapper.Map<GetEmployeeDto>(employee));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetEmployeeDto>> CreateEmployeeAsync(CreateEmployeeDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);

            var resultEmployee = await _employeeService.CreateEmployeeAsync(employee);
            var result = _mapper.Map<GetEmployeeDto>(resultEmployee);

            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GetEmployeeDto>> UpdateEmployeeAsync(
            int id,
            [FromBody] UpdateEmployeeDto dto)
        {
            try
            {
                var employee = _mapper.Map<Employee>(dto);

                var resultEmployee = await _employeeService.UpdateEmployeeAsync(id, employee);
                var result = _mapper.Map<GetEmployeeDto>(resultEmployee);

                return StatusCode(200, result);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteEmployeeAsync(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok();
        }

        [HttpPut("addPosition")]
        public async Task<ActionResult> AddPositionToEmployeeAsync(AddPositionToEmployeeDto dto)
        {
            await _employeeService.AddPositionToEmployeeAsync(dto.EmployeeId, dto.PositionId);

            return Ok();
        }

        [HttpPut("removePosition")]
        public async Task<ActionResult> RemovePositionToEmployeeAsync(RemovePositionToEmployeeDto dto)
        {
            await _employeeService.RemovePositionFromEmployeeAsync(dto.EmployeeId, dto.PositionId);

            return Ok();
        }
    }
}
