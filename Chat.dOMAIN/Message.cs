using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class Message
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ChatId { get; set; }
        public string Text  { get; set; }
        public User Sender { get; set; }
        public DateTime DateTime { get; set; }
        public virtual ICollection<MessageUser> MessageUsers { get; set; } = new List<MessageUser>();
    }
}
