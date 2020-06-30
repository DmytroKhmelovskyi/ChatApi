using Domain;
using Microsoft.EntityFrameworkCore;
using Reenbit_Chat.Configurations;
using Reenbit_Chat.Interfaces;
using Reenbit_Chat.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Reenbit_Chat.Services
{
    public class MessageService : IMessageSerivce
    {
        private ApplicationContext _context;
        private ClaimsPrincipal _user;

        private int UserId => int.Parse(_user.FindFirstValue(AuthOptions.USER_ID_CLAIM));
        public MessageService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Message> Send(int chatId, string text)
        {
            var messageUsers = await _context.ChatUsers.Where(cu => cu.ChatId == chatId)
                .Select(cu => new MessageUser { UserId = cu.UserId }).ToListAsync();
            var message = new Message
            {
                ChatId = chatId,
                SenderId = UserId,
                Text = text,
                DateTime = DateTime.Now,
                MessageUsers = messageUsers
            };

            _context.Add(message);
            await _context.SaveChangesAsync();

            return message;
        }
        public async Task DeleteMessage(int messageId, bool forAll)
        {
            var message = await _context.Messages
                .Where(m => m.SenderId == UserId && m.Id == messageId)
                .FirstOrDefaultAsync();
            if(message != null)
            {
                if(forAll)
                {
                    _context.Messages.Remove(message);
                }
                else
                {
                    _context.MessageUsers.Remove(new MessageUser { MessageId = messageId, UserId = UserId });
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}
