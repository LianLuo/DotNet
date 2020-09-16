using System.Collections.Generic;
using System.Threading.Tasks;
using AngularForDotnetCore.Models;
using AngularForDotnetCore.Repo;
using Microsoft.EntityFrameworkCore;

namespace AngularForDotnetCore.Components
{
    public class EmployeeComponent
    {
        private readonly ApiDbContext _ctx;
        public EmployeeComponent(ApiDbContext ctx)
        {
            this._ctx = ctx;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await this._ctx.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await this._ctx.Employees.FindAsync(id);
        }

        public async Task AddEmployee(Employee emp)
        {
            await this._ctx.Employees.AddAsync(emp);
            await this._ctx.SaveChangesAsync();
        }

        public async Task UpdateEmployee(Employee emp)
        {
            await this._ctx.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var emp = await this._ctx.Employees.FindAsync(employeeId);
            if(emp != null)
            {
                this._ctx.Employees.Remove(emp);
            }
            await this._ctx.SaveChangesAsync();
        }
    }
}