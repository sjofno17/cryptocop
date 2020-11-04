using Microsoft.EntityFrameworkCore;
using Cryptocop.Software.API.Models.Entities;

namespace Cryptocop.Software.API.Repositories.Contexts
{
    public class cryptocopDbContext : DbContext
    {
        public CryptocopDbContext(DbContextOptions<CryptocopDbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
/*             modelBuilder.Entity<Message>()
                .HasOne(m => m.UserFrom)
                .WithMany(u => u.MessagesSent);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.UserTo)
                .WithMany(u => u.MessagesReceived); */
        }

        //public DbSet<User> Users { get; set; }
        //public DbSet<Message> Messages { get; set; }
        public DbSet<JwtToken> JwtTokens { get; set; }
    }
}