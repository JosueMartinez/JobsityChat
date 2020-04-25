using Microsoft.AspNetCore.Mvc;
using StockBot;

namespace JobsityChat.Controllers
{
    public class ChatRoomController : Controller
    {
        public IActionResult Index()
        {
            var quoteMessage = BotTasks.GetStockMessage("aapl.us");
            return View();
        }
    }
}