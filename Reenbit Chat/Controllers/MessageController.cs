using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reenbit_Chat.Interfaces;

namespace Reenbit_Chat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IMessageSerivce _messageSerivce;
        private const int USER_ID = 1;
        public MessageController(IMessageSerivce messageSerivce)
        {
            _messageSerivce = messageSerivce;

        }

        [HttpDelete("messages/{messageId:int}")]
        public async Task<IActionResult> DeleteMessage([FromRoute] int messageId, [FromQuery] bool forAll = false)
        {
           await _messageSerivce.DeleteMessage(USER_ID, messageId, forAll);
            return Ok();
        }
    }
}
