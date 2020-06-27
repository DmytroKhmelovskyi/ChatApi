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
                .HasData(new User { Id = 1, Name = "Dima" },
                         new User { Id = 2, Name = "Vasia" },
                         new User { Id = 3, Name = "Kolia" });

            modelBuilder.Entity<Chat>()
                .HasData(new Chat
                {
                    Id = 1,
                    ChatName = "Chat with Vasia"
                },
                new Chat
                {
                    Id = 2,
                    ChatName = "Boys"
                });

            modelBuilder.Entity<ChatUser>().HasData(
                        new ChatUser { ChatId = 1, UserId = 1 },
                        new ChatUser { ChatId = 1, UserId = 2 },
                        new ChatUser { ChatId = 2, UserId = 1 },
                        new ChatUser { ChatId = 2, UserId = 2 },
                        new ChatUser { ChatId = 2, UserId = 3 });
        }
    }
}
