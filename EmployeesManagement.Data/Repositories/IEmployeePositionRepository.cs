namespace EmployeesManagement.Data.Repositories
{
    public interface IEmployeePositionRepository
    {
        Task<int> GetEmployeesCountForPositionAsync(int positionId);
    }
}
