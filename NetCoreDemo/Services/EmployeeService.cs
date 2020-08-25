using NetCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemo.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>();
        public EmployeeService()
        {
            _employees.AddRange(new List<Employee> {
                     new Employee{
                     Id=1,
                     DepartmentId=1,
                     Fired=false,
                     FirstName="Sai",
                     LastName="Tian",
                     Gender=Gender.Male
                    },
                     new Employee{
                     Id=2,
                     DepartmentId=1,
                     Fired=false,
                     FirstName="Daiyin",
                     LastName="Zhang",
                     Gender=Gender.Female
                    },
                     new Employee{
                     Id=3,
                     DepartmentId=2,
                     Fired=false,
                     FirstName="Wei",
                     LastName="Cong",
                     Gender=Gender.Male
                    },
                     new Employee{
                     Id=4,
                     DepartmentId=2,
                     Fired=false,
                     FirstName="Zoe",
                     LastName="Wang",
                     Gender=Gender.Female
                    },
                     new Employee{
                     Id=5,
                     DepartmentId=3,
                     Fired=false,
                     FirstName="Michael",
                     LastName="Jordan",
                     Gender=Gender.Male
                    },
                     new Employee{
                     Id=6,
                     DepartmentId=3,
                     Fired=false,
                     FirstName="Lebron",
                     LastName="James",
                     Gender=Gender.Male
                    },
                     new Employee{
                     Id=7,
                     DepartmentId=3,
                     Fired=false,
                     FirstName="Della",
                     LastName="Sun",
                     Gender=Gender.Female
                    },
            });
        }

        public Task Add(Employee employee)
        {
            employee.Id = _employees.Max(a => a.Id) + 1;
            _employees.Add(employee);
            return Task.CompletedTask;
        }

        public Task<Employee> Fire(int id)
        {
            return Task.Run(() =>
            {
                var employee = _employees.FirstOrDefault(a => a.Id == id);
                if (employee != null)
                {
                    employee.Fired = true;
                }
                return employee;
            });
        }

        public Task<IEnumerable<Employee>> GetByDepartmentId(int departmentId)
        {
            return Task.Run(() =>
            _employees.Where(a => a.DepartmentId == departmentId));
        }
    }
}
