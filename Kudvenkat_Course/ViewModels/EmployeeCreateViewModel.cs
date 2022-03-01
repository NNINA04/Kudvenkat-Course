using Kudvenkat_Course.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Kudvenkat_Course.ViewModels
{
    public class EmployeeCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Name cannot exceed 15 characters")]
        public string Name { get; set; }

        [Required] // Обязательное поле
        [Display(Name = "Email")] // Заменяет отображаемое имя в Html на "Email"
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zAZ0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }

        [Required]
        public Dept? Department { get; set; }

        public IFormFile Photo { get; set; }
    }
}
