using System.Collections.Generic;

namespace Kudvenkat_Course.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetAllEmployee();
        Employee Add(Employee employee);
        void Delete(int id);
    }
}
