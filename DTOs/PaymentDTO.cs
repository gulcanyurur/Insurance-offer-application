
public class PaymentDTO
{
    public string CardHolderName { get; set; }
    public string CardNumber { get; set; }
    public string ExpirationDate { get; set; }
    public string CVV { get; set; }
    public string PaymentMethod { get; set; }
    public decimal AmountTL { get; set; }
    public decimal AmountUSD { get; set; }
}
