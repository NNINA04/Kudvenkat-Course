using System.Collections.Generic;
using System.Linq;

namespace Kudvenkat_Course.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee { Id=1, Name="Mary", Department=Dept.HR, Email="mary@gmail.com" },
                new Employee { Id=2, Name="John", Department=Dept.HR, Email="john@gmail.com" },
                new Employee { Id=3, Name="Sam",  Department=Dept.HR, Email="sam@gmail.com" },
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;

            _employeeList.Add(employee);
            
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee() => _employeeList;

        public Employee GetEmployee(int Id) => _employeeList.FirstOrDefault(x => x.Id == Id);

        public void Delete(int id)
        {
            _employeeList.RemoveAt(id);
        }
    }
}
