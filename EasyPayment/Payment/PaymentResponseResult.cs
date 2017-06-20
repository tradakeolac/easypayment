namespace EasyPayment.Payment
{
    public class PaymentResponseResult
    {
        public PaymentResult StateResult { get; set; }
        public PaymentResponse Response { get; set; }

        protected PaymentResponseResult()
        {

        }

        public static PaymentResponseResult CreateSuccessResult(PaymentResponse response)
        {
            return new PaymentResponseResult
            {
                StateResult = PaymentResult.Success,
                Response = response
            };
        }

        public static PaymentResponseResult CreateInvalidResult()
        {
            return new PaymentResponseResult
            {
                StateResult = PaymentResult.Invalid
            };
        }
    }

}
