using Domain;
using Reenbit_Chat.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reenbit_Chat.Interfaces
{
    public interface IChatService
    {
        Task<List<Chat>> GetUserChats();

        Task<List<MessageViewModel>> GetChatMessages(int chatId, int page, int count);
        
    }
}
