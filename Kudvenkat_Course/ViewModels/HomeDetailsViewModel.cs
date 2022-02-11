namespace Kudvenkat_Course.Models.ViewModels
{
    /*
     Данный класс находится в папке ViewModels потому что это помещаемый объект в метод View в контроллере и
     название папки содержит Models потому что это будет принимаемым параметром View который назвается Model
     и Model используется как ключевое слово в Razor
     */

    public class HomeDetailsViewModel
    {
        public Employee Employee { get; set; }
        public string PageTitle { get; set; }
    }
}
