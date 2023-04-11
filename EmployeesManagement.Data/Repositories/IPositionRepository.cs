using EmployeesManagement.Domain.Models;
using System.Linq.Expressions;

namespace EmployeesManagement.Data.Repositories
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetAllPositionsAsync();
        Task<Position> GetPositionByIdAsync(int id);
        Task<Position> GetFirstOrDefaultAsync<TKey>(Expression<Func<Position, TKey>> orderBy, Expression<Func<Position, bool>> predicate = null);
        Task<Position> CreatePositionAsync(Position newPosition);
        Task<bool> ExistsAsync(int id);
        Task<Position> UpdatePositionAsync(Position updatedPosition);
        Task DeletePositionAsync(Position position);
    }
}
