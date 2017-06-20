namespace EasyPayment.Payment.Onepay
{
    public class OnepayPaymentResponse : PaymentResponse
    {
        public string Command { get; set; }
        public string Locale { get; set; }
        public string MerchRef { get; set; }
        public override string OrderTransaction
        {
            get
            {
                return MerchRef;
            }

            set
            {
                base.OrderTransaction = value;
            }
        }
    }
}
