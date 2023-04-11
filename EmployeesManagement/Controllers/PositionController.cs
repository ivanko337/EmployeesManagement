using AutoMapper;
using EmployeesManagement.Domain.Models;
using EmployeesManagement.Dtos;
using EmployeesManagement.Foundation.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesManagement.Controllers
{
    public class PositionController : BaseApiController
    {
        private readonly IPositionService _positionService;
        private readonly IMapper _mapper;

        public PositionController(IPositionService positionService, IMapper mapper)
        {
            _positionService = positionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetPositionDto>>> GetAllPositionsDtoAsync()
        {
            var positions = await _positionService.GetAllPositionsAsync();

            return Ok(_mapper.Map<IEnumerable<GetPositionDto>>(positions));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetPositionDto>> GetPositionByIdAsync(int id)
        {
            try
            {
                var position = await _positionService.GetPositionByIdAsync(id);
                return Ok(_mapper.Map<GetPositionDto>(position));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<GetPositionDto>> CreatePositionAsync(CreatePositionDto dto)
        {
            var validationResult = await ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequestOnFailedValidation(validationResult);
            }

            var position = _mapper.Map<Position>(dto);

            var resultPosition = await _positionService.CreatePositionAsync(position);
            var result = _mapper.Map<GetPositionDto>(resultPosition);

            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<GetPositionDto>> UpdatePositionAsync(
            int id,
            [FromBody] UpdatePositionDto dto)
        {
            var validationResult = await ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequestOnFailedValidation(validationResult);
            }

            try
            {
                var position = _mapper.Map<Position>(dto);

                var resultPosition = await _positionService.UpdatePositionAsync(id, position);
                var result = _mapper.Map<GetPositionDto>(resultPosition);

                return StatusCode(200, result);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePositionAsync(int id)
        {
            await _positionService.DeletePositionAsync(id);
            return Ok();
        }
    }
}
