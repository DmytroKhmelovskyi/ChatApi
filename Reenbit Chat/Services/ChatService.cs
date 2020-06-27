using Domain;
using Microsoft.EntityFrameworkCore;
using Reenbit_Chat.Interfaces;
using Reenbit_Chat.Models;
using Reenbit_Chat.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reenbit_Chat.Services
{
    public class ChatService : IChatService
    {
        private ApplicationContext _context;
        private const int USER_ID = 1;

        public ChatService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Chat>> GetUserChats(int userId)
        {
            return await _context.Chats
                .AsNoTracking()
                .Include(c => c.ChatUsers)
                .Where(c => c.ChatUsers.Any(u => u.UserId == userId))
                .ToListAsync();
        }

        public async Task<List<MessageViewModel>> GetChatMessages(int chatId)
        {
            return await _context.Messages
                .Include(m => m.MessageUsers)
                .AsNoTracking()
                .Where(m => m.ChatId == chatId
                            && m.MessageUsers.Any(mu => mu.UserId == USER_ID))
                .Select(m => new MessageViewModel
                {
                    Id = m.Id,
                    SenderId = m.SenderId,
                    Text = m.Text,
                    SenderName = m.Sender.Name,
                    DateTime = m.DateTime
                })
                .OrderBy(m => m.DateTime)
                .ToListAsync();
        }
    }
}
