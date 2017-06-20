namespace EasyPayment.Payment
{
    public class PaymentResponse
    {
        public virtual string OrderInfo { get; set; }
        public virtual string Amount { get;set; }
        public virtual string Message { get; set; }
        public string TransactionNo { get; set; }
        public virtual string OrderTransaction { get; set; }
    }
}
