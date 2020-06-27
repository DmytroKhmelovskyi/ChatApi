using System.Collections.Generic;

namespace Domain
{
    public class Chat
    {
        public int Id { get; set; }
        public string ChatName { get; set; }
        public virtual ICollection<ChatUser> ChatUsers { get; set; } = new List<ChatUser>();
    }
}
