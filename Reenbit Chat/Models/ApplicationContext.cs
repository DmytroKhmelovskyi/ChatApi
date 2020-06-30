using Domain;
using Microsoft.EntityFrameworkCore;

namespace Reenbit_Chat.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)

        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageUser> MessageUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>()
                .HasMany(c => c.ChatUsers)
                .WithOne()
                .HasForeignKey(c => c.ChatId);

            modelBuilder.Entity<ChatUser>()
                .HasKey(x => new { x.ChatId, x.UserId })
                .IsClustered();

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId);

            modelBuilder.Entity<MessageUser>()
                .HasKey(mu => new { mu.MessageId, mu.UserId })
                .IsClustered();

            modelBuilder.Entity<Message>()
                .HasMany(m => m.MessageUsers)
                .WithOne()
                .HasForeignKey(mu => mu.MessageId);

            modelBuilder.Entity<MessageUser>()
                .HasOne(mu => mu.User)
                .WithMany()
                .HasForeignKey(mu => mu.UserId)
                .OnDelete(DeleteBehavior.NoAction);



            //Seed data
            modelBuilder.Entity<User>()
                .HasData(new User { Id = 1, Name = "User_1", Password = "1111", Role = "User" },
                         new User { Id = 2, Name = "User_2", Password = "2222", Role = "User" },
                         new User { Id = 3, Name = "User_3", Password = "3333", Role = "User" },
                         new User { Id = 4, Name = "User_4", Password = "4444", Role = "User" },
                         new User { Id = 5, Name = "User_5", Password = "5555", Role = "User" },
                         new User { Id = 6, Name = "User_6", Password = "6666", Role = "User" },
                         new User { Id = 7, Name = "User_7", Password = "7777", Role = "User" },
                         new User { Id = 8, Name = "User_8", Password = "8888", Role = "User" },
                         new User { Id = 9, Name = "User_9", Password = "9999", Role = "User" },
                         new User { Id = 10, Name = "User_10", Password = "0000", Role = "User" });

            modelBuilder.Entity<Chat>()
                .HasData(new Chat
                {
                    Id = 1,
                    ChatName = "Chat_1"
                },
                new Chat
                {
                    Id = 2,
                    ChatName = "Chat_2"
                },
                new Chat
                {
                    Id = 3,
                    ChatName = "Chat_3"
                },
                new Chat
                {
                    Id = 4,
                    ChatName = "Chat_4"
                }
                );

            modelBuilder.Entity<ChatUser>().HasData(
                        new ChatUser { ChatId = 1, UserId = 1 },
                        new ChatUser { ChatId = 1, UserId = 2 },
                        new ChatUser { ChatId = 2, UserId = 1 },
                        new ChatUser { ChatId = 2, UserId = 2 },
                        new ChatUser { ChatId = 2, UserId = 3 },
                        new ChatUser { ChatId = 2, UserId = 4 },
                        new ChatUser { ChatId = 3, UserId = 5 },
                        new ChatUser { ChatId = 3, UserId = 6 },
                        new ChatUser { ChatId = 3, UserId = 7 },
                        new ChatUser { ChatId = 3, UserId = 8 },
                        new ChatUser { ChatId = 4, UserId = 1 },
                        new ChatUser { ChatId = 4, UserId = 2 },
                        new ChatUser { ChatId = 4, UserId = 3 },
                        new ChatUser { ChatId = 4, UserId = 4 },
                        new ChatUser { ChatId = 4, UserId = 5 },
                        new ChatUser { ChatId = 4, UserId = 6 },
                        new ChatUser { ChatId = 4, UserId = 7 },
                        new ChatUser { ChatId = 4, UserId = 8 },
                        new ChatUser { ChatId = 4, UserId = 9 },
                        new ChatUser { ChatId = 4, UserId = 10 });

            modelBuilder.Entity<Message>().HasData(
               new Message { Id = 1, ChatId = 1, SenderId = 1, Text = "User_1 message_1" },
               new Message { Id = 2, ChatId = 1, SenderId = 2, Text = "User_2 message_2" },
               new Message { Id = 3, ChatId = 2, SenderId = 3, Text = "User_3 message_3" },
               new Message { Id = 4, ChatId = 2, SenderId = 4, Text = "User_4 message_4" },
               new Message { Id = 5, ChatId = 3, SenderId = 5, Text = "User_5 message_5" },
               new Message { Id = 6, ChatId = 3, SenderId = 6, Text = "User_6 message_6" },
               new Message { Id = 7, ChatId = 3, SenderId = 7, Text = "User_7 message_7" },
               new Message { Id = 8, ChatId = 4, SenderId = 1, Text = "User_1 message_8" },
               new Message { Id = 9, ChatId = 4, SenderId = 8, Text = "User_8 message_9" },
               new Message { Id = 10, ChatId = 4, SenderId = 9, Text = "User_9 message_10" },
               new Message { Id = 11, ChatId = 4, SenderId = 10, Text = "User_10 message_11" });

            modelBuilder.Entity<MessageUser>().HasData(
               new MessageUser { UserId = 1, MessageId = 1 },
               new MessageUser { UserId = 2, MessageId = 1 },
               new MessageUser { UserId = 1, MessageId = 2 },
               new MessageUser { UserId = 2, MessageId = 2 },

               new MessageUser { UserId = 3, MessageId = 3 },
               new MessageUser { UserId = 4, MessageId = 3 },
               new MessageUser { UserId = 3, MessageId = 4 },
               new MessageUser { UserId = 4, MessageId = 4 },

               new MessageUser { UserId = 5, MessageId = 5 },
               new MessageUser { UserId = 6, MessageId = 5 },
               new MessageUser { UserId = 7, MessageId = 5 },
               new MessageUser { UserId = 5, MessageId = 6 },
               new MessageUser { UserId = 6, MessageId = 6 },
               new MessageUser { UserId = 7, MessageId = 6 },
               new MessageUser { UserId = 5, MessageId = 7 },
               new MessageUser { UserId = 6, MessageId = 7 },
               new MessageUser { UserId = 7, MessageId = 7 },

               new MessageUser { UserId = 1, MessageId = 8 },
               new MessageUser { UserId = 8, MessageId = 8 },
               new MessageUser { UserId = 9, MessageId = 8 },
               new MessageUser { UserId = 10, MessageId = 8 },
               new MessageUser { UserId = 1, MessageId = 9 },
               new MessageUser { UserId = 8, MessageId = 9 },
               new MessageUser { UserId = 9, MessageId = 9 },
               new MessageUser { UserId = 10, MessageId = 9 },
               new MessageUser { UserId = 1, MessageId = 10 },
               new MessageUser { UserId = 8, MessageId = 10 },
               new MessageUser { UserId = 9, MessageId = 10 },
               new MessageUser { UserId = 10, MessageId = 10 },
               new MessageUser { UserId = 1, MessageId = 11 },
               new MessageUser { UserId = 8, MessageId = 11 },
               new MessageUser { UserId = 9, MessageId = 11 },
               new MessageUser { UserId = 10, MessageId = 11 });
        }
    }
}
