namespace EasyPayment.Payment.Onepay
{
    internal static class OnepayParamKeys
    {
        // Static params provided by Onepay
        internal const string Version = "vpc_Version";
        internal const string Currency = "vpc_Currency";
        internal const string Command = "vpc_Command ";
        internal const string AccessCode = "vpc_AccessCode";
        internal const string Merchant = "vpc_Merchant";
        internal const string Locale = "vpc_Locale";
        internal const string ReturnUrl = "vpc_ReturnURL";

        internal const string TxnResponseCode = "vpc_TxnResponseCode";
        internal const string TransactionNo = "vpc_TransactionNo";
        internal const string Message = "vpc_Message";


        // Dynamic params
        internal const string MerchTxnRef = "vpc_MerchTxnRef";
        internal const string OrderInfo = "vpc_OrderInfo";
        internal const string Amount = "vpc_Amount";
        internal const string TicketNo = "vpc_TicketNo";
        internal const string AgainLink = "AgainLink";
        internal const string Title = "Title";

        // Hash key
        internal const string SecureHash = "vpc_SecureHash";
        internal const string SecureHashType = "vpc_SecureHashType";

        // Optional
        internal const string ShipStreet1 = "vpc_SHIP_Street01";
        internal const string ShipProvice = "vpc_SHIP_Provice";
        internal const string ShipCity = "vpc_SHIP_City";
        internal const string ShipCountry = "vpc_SHIP_Country";
        internal const string CustomerPhone = "vpc_Customer_Phone";
        internal const string CustomerEmail = "vpc_Customer_Email";
        internal const string CustomerId = "vpc_Customer_Id";
    }
}
