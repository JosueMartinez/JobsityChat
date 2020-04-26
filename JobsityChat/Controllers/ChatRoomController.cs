using JobsityChat.Data;
using JobsityChat.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobsityChat.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class ChatRoomController : Controller
    {
        private IMesssageRepository _messageRepository;

        public ChatRoomController(IMesssageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public IActionResult Index()
        {
            var messages = _messageRepository.GetAll();
            return View(messages);
        }
    }
}