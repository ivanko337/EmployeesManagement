using EmployeesManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmployeesManagement.Data.Repositories
{
    internal class PositionRepository : IPositionRepository
    {
        private readonly EmployeesDbContext _context;

        public PositionRepository(EmployeesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Position>> GetAllPositionsAsync()
        {
            return await _context.Positions.ToListAsync();
        }

        public async Task<Position> GetPositionByIdAsync(int id)
        {
            return await _context.Positions.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Position> GetFirstOrDefaultAsync<TKey>(
            Expression<Func<Position, TKey>> orderBy,
            Expression<Func<Position, bool>> predicate = null)
        {
            IQueryable<Position> query = _context.Positions;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = query.OrderBy(orderBy);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Position> CreatePositionAsync(Position newPosition)
        {
            _context.Positions.Add(newPosition);
            await _context.SaveChangesAsync();

            return newPosition;
        }

        public async Task<Position> UpdatePositionAsync(Position updatedPosition)
        {
            _context.Entry(updatedPosition).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return updatedPosition;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Positions.AnyAsync(e => e.Id == id);
        }

        public async Task DeletePositionAsync(Position position)
        {
            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();
        }
    }
}
