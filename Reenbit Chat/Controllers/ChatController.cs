using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reenbit_Chat.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reenbit_Chat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatController : ControllerBase
    {
        private IChatService _chatService;
        private IMessageSerivce _messageSerivce;
        private const int USER_ID = 1;

        public ChatController(IChatService chatService, IMessageSerivce messageSerivce)
        {
            _chatService = chatService;
            _messageSerivce = messageSerivce;
        }

        [HttpGet]
        public async Task<ICollection<Chat>> GetUserChats()
        {
            return await _chatService.GetUserChats();
        }

        [HttpGet("{chatId:int}/messages")]
        public async Task<IActionResult> GetChatMessages([FromRoute] int chatId, [FromQuery]int page, [FromQuery]int count = 20)
        {
            if (chatId <= 0)
            {
                return BadRequest("Incorrect chat id.");
            }
            var messages = await _chatService.GetChatMessages(chatId, page, count);

            return Ok(messages);
        }

        [HttpPost("{chatId:int}/messages")]
        public async Task<IActionResult> SendMessage([FromRoute] int chatId, [FromBody] string text)
        {
            if (chatId <= 0)
            {
                return BadRequest("Incorrect chat id.");
            }

            if (string.IsNullOrEmpty(text))
            {
                return BadRequest("Message cannot be empty");
            }

            var message = await _messageSerivce.Send(chatId, text);
            return Ok(message);
        }


    }
}
