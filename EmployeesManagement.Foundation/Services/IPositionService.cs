using EmployeesManagement.Domain.Models;

namespace EmployeesManagement.Foundation.Services
{
    internal interface IPositionService
    {
        Task<IEnumerable<Position>> GetAllPositionsAsync();
        Task<Position> GetPositionByIdAsync(int id);
        Task<Position> CreatePositionAsync(Position newPosition);
        Task<Position> UpdatePositionAsync(int id, Position updatedPosition);
        Task DeletePositionAsync(int id);
    }
}