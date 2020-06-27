namespace Domain
{
    public class MessageUser
    {
        public int UserId { get; set; }
        public int MessageId { get; set; }
        public User User  { get; set; }
    }
}
