using Microsoft.EntityFrameworkCore;
using Cryptocop.Software.API.Models.Entities;

namespace Cryptocop.Software.API.Repositories.Contexts
{
    public class CryptocopDbContext : DbContext
    {
        public CryptocopDbContext(DbContextOptions<CryptocopDbContext> options) : base(options) { }

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