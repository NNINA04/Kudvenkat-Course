using Kudvenkat_Course.Models;
using Kudvenkat_Course.Models.ViewModels;
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

        public ViewResult Index()
        {
            var allEmployee = _employeeRepository.GetAllEmployee();

            return View(allEmployee);
        }

        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new()
            {
                Employee = _employeeRepository.GetEmployee(id ?? 1),
                PageTitle = "Emplyee Details"
            };

            // View takes directory(path) or tryies to find in directory {class name without Controller}/{method name}.cshtml
            // also parameter that not means path will be in variable Model in Razor
            // type of Model in Razor must be type of passed parameter
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            // IActionResult это базовый класс возвращаемых значений для методов контроллеров

            if (ModelState.IsValid) 
            {
                Employee newEmployee = _employeeRepository.Add(employee);

                //return RedirectToAction("details", new { id = newEmployee.Id });
            }

            return View();
        }

        [HttpDelete]
        public RedirectToActionResult Delete(int id) 
        {
            _employeeRepository.Delete(id);

            return RedirectToAction("index");
        }
    }
}
