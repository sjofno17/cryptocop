namespace Cryptocop.Software.API.Models.Entities
{
    public class PaymentCardEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}