using Microsoft.AspNetCore.Mvc;

namespace JobsityChat.Controllers
{
    public class ChatRoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}