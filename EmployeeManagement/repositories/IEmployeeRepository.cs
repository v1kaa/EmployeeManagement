using EmployeeManagement.Models;

namespace EmployeeManagement.repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAssync();
        Task<Employee?> GetByIdAsync(int id);

        Task AddEmployeAsync(Employee employee);

        Task UpdateEmployesync(Employee employee);
        Task DeleteEmployeAsync(int id);
    }
}
