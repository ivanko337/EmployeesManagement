using EmployeesManagement.Domain.Models;
using EmployeesManagement.Data.Repositories;

namespace EmployeesManagement.Foundation.Services
{
    internal class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IEmployeePositionRepository _employeePositionRepository;

        public PositionService(IPositionRepository positionRepository, IEmployeePositionRepository employeePositionRepository)
        {
            _positionRepository = positionRepository;
            _employeePositionRepository = employeePositionRepository;
        }

        public async Task<IEnumerable<Position>> GetAllPositionsAsync()
        {
            return await _positionRepository.GetAllPositionsAsync();
        }

        public async Task<Position> GetPositionById(int id)
        {
            return await _positionRepository.GetPositionByIdAsync(id);
        }

        public async Task<Position> CreatePosition(Position newPosition)
        {
            return await _positionRepository.CreatePositionAsync(newPosition);
        }

        public async Task<Position> UpdatePosition(int id, Position updatedPosition)
        {
            var position = await _positionRepository.GetPositionByIdAsync(id);
            if (position == null)
            {
                throw new ArgumentException("Position not found", nameof(id));
            }

            position.Title = updatedPosition.Title;
            position.Grade = updatedPosition.Grade;

            return await _positionRepository.UpdatePositionAsync(position);
        }

        public async Task DeletePosition(int id)
        {
            var position = await _positionRepository.GetPositionByIdAsync(id);
            if (position == null)
            {
                throw new ArgumentException("Position not found", nameof(id));
            }

            var employeesCount = await _employeePositionRepository.GetEmployeesCountForPositionAsync(id);
            if (employeesCount != 0)
            {
                throw new ArgumentException($"Cannot remove the position #{id}, some employees refer to it");
            }

            await _positionRepository.DeletePositionAsync(position);
        }
    }
}
