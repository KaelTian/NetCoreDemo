using NetCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemo.Services
{
    public class DepartmentService : IDepartmentService
    {

        private readonly List<Department> _departments = new List<Department>();

        public DepartmentService()
        {
            _departments.AddRange(new List<Department>() {
                new Department
            {
                     Id=1,
                     Name="HR",
                     EmployeeCount=16,
                     Location="BeiJing"
            },
                new Department
            {
                     Id=2,
                     Name="R&D",
                     EmployeeCount=37,
                     Location="DaLian"
            },
                new Department
            {
                     Id=3,
                     Name="Sales",
                     EmployeeCount=200,
                     Location="India"
            },
            });
        }


        public Task Add(Department department)
        {
            department.Id = _departments.Max(a => a.Id) + 1;
            _departments.Add(department);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Department>> GetAll()
        {
            return Task.Run(() => _departments.AsEnumerable());
        }

        public Task<Department> GetById(int id)
        {
            return Task.Run(() => _departments.FirstOrDefault(a => a.Id == id));
        }

        public Task<CompanySummary> GetCompanySummary()
        {
            return Task.Run(() => new CompanySummary
            {
                EmployeeCount = _departments.Sum(a => a.EmployeeCount),
                AverageDepartmentEmployeeCount = (int)_departments.Average(a => a.EmployeeCount)
            });
        }
    }
}
