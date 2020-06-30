using Domain;
using Microsoft.EntityFrameworkCore;
using Reenbit_Chat.Configurations;
using Reenbit_Chat.Interfaces;
using Reenbit_Chat.Models;
using Reenbit_Chat.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Reenbit_Chat.Services
{
    public class ChatService : IChatService
    {
        private ApplicationContext _context;
        private ClaimsPrincipal _user;

        private int UserId => int.Parse(_user.FindFirstValue(AuthOptions.USER_ID_CLAIM));

        public ChatService(ApplicationContext context, ClaimsPrincipal user)
        {
            _context = context;
            _user = user;
        }

        public async Task<List<Chat>> GetUserChats()
        {
            return await _context.Chats
                .AsNoTracking()
                .Include(c => c.ChatUsers)
                .Where(c => c.ChatUsers.Any(u => u.UserId == UserId))
                .ToListAsync();
        }

        public async Task<List<MessageViewModel>> GetChatMessages(int chatId, int page, int count)
        {
            return await _context.Messages
                .Include(m => m.MessageUsers)
                .AsNoTracking()
                .Where(m => m.ChatId == chatId
                            && m.MessageUsers.Any(mu => mu.UserId == UserId))
                .Select(m => new MessageViewModel
                {
                    Id = m.Id,
                    SenderId = m.SenderId,
                    Text = m.Text,
                    SenderName = m.Sender.Name,
                    DateTime = m.DateTime
                })
                .OrderBy(m => m.DateTime)
                .Take(count)
                .Skip(count * (page - 1))
                .ToListAsync();
        }
    }
}
