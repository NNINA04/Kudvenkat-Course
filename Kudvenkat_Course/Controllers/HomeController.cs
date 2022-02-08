using Kudvenkat_Course.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kudvenkat_Course.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public string Index() // Default page
        {
            return _employeeRepository.GetEmployee(1).Name;
        }

        public ViewResult Details()
        {
            Employee employee = _employeeRepository.GetEmployee(1);

            return View(employee);
        }
    }
}
