using EmployeesManagement.Domain.Models;

namespace EmployeesManagement.Foundation.Services
{
    internal interface IPositionService
    {
        Task<Position> CreatePosition(Position newPosition);
        Task DeletePosition(int id);
        Task<IEnumerable<Position>> GetAllPositionsAsync();
        Task<Position> GetPositionById(int id);
        Task<Position> UpdatePosition(int id, Position updatedPosition);
    }
}