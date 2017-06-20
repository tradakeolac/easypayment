namespace EasyPayment.Payment
{
    public class PaymentRequest
    {
        public long Amount { get; set; }
        public string OrderInfo { get; set; }
        public string Currency { get; set; }
        public string CustomerId { get; set; }
        public string ClientIp { get; set; }
    }
}
