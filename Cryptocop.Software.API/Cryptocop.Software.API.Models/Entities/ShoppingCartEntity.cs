using System.Collections.Generic;

namespace Cryptocop.Software.API.Models.Entities
{
    public class ShoppingCartEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public List<ShoppingCartItemEntity> ShoppingCartItems { get; set; }
    }
}