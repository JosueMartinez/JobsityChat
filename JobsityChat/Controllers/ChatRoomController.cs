using Microsoft.AspNetCore.Mvc;

namespace JobsityChat.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class ChatRoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}