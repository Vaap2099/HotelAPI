using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    public class Reservaciones : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
