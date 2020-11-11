using System.Collections.Generic;

namespace Cryptocop.Software.API.Models.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public List<AddressEntity> Addresses { get; set; }
        public List<OrderEntity> Orders { get; set; }
        public List<PaymentCardEntity> Cards { get; set; }
        public ShoppingCartEntity ShoppingCart { get; set; }
    }
}