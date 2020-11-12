using Microsoft.EntityFrameworkCore;
using Cryptocop.Software.API.Models.Entities;

namespace Cryptocop.Software.API.Repositories.Contexts
{
    public class CryptocopDbContext : DbContext
    {
        public CryptocopDbContext(DbContextOptions<CryptocopDbContext> options) : base(options) { }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<UserEntity>()
                .HasOne(o => o.Orders)
                .WithMany(i => i.OrderItems);
                
            modelBuilder.Entity<UserEntity>()
                .HasOne(s => s.ShoppingCart)
                .WithMany(i => i.ShoppingCartItems);
        }*/
        public DbSet<JwtToken> JwtTokens { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderItemEntity> OrderItems { get; set; }
        public DbSet<PaymentCardEntity> PaymentCards { get; set; }
        public DbSet<ShoppingCartEntity> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItemEntity> ShoppingCartItems { get; set; }
    }
}