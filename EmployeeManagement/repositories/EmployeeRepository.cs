using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
               _context = context;
        }

        public async Task AddEmployeAsync(Employee employee)
        {
            
            await _context.Employees.AddAsync(employee);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeAsync(int id)
        {
            var EmployeeInDb = await _context.Employees.FindAsync(id);

            if (EmployeeInDb != null) {
                throw new KeyNotFoundException("employee with id "+ id+ "was not found");
            }

            _context.Employees.Remove(EmployeeInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAssync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        { 
            return await _context.Employees.FindAsync(id);
        }

        public async Task UpdateEmployesync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
