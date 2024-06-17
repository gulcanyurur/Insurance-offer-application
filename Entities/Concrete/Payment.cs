using Core.Entities;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public int PaymentID { get; set; }
        public string CardHolderName { get; set; }
        public string MaskedCardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string MaskedCVV { get; set; }
        public string PaymentMethod { get; set; }
        public decimal AmountTL { get; set; }
        public decimal AmountUSD { get; set; }
    }
}

