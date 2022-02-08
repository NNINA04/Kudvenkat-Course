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
                new Employee { Id=1, Name="Mary", Department="HR", Email="mary@gmail.com" },
                new Employee { Id=1, Name="John", Department="IT", Email="john@gmail.com" },
                new Employee { Id=1, Name="Sam",  Department="IT", Email="sam@gmail.com" },
            };
        }

        public Employee GetEmployee(int Id) => _employeeList.FirstOrDefault(x => x.Id == Id);
    }
}
