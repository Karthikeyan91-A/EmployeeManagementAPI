using Employee_Management_Data.Models;
using Employee_Management_Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_Repository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context; 
        }
        public async Task AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee!=null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _context.Employees
                .Include(x=> x.Department).ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.Include(x=>x.Department).FirstOrDefaultAsync(x=>x.EmployeeId == id);

            return employee;
        }

        public async Task UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _context.Departments
                .ToListAsync();
        }
    }
}
