using Domain;
using System.Threading.Tasks;

namespace Reenbit_Chat.Interfaces
{
    public interface IMessageSerivce
    {
        Task<Message> Send(int userId, int chatId, string text);
        Task DeleteMessage(int userId, int messageId, bool forAll);

    }
}
