namespace EasyPayment.Payment.Onepay
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Collections.Specialized;
    using EasyPayment.Configuration.Payment;
    using EasyPayment.Configuration;

    public class OnepayProcessor : IPaymentProcessor
    {
        private readonly SortedList<string, string> _sortedValues = new SortedList<string, string>(new OnepayStringComparable());
        private OnepayProviderElement PaymentConfiguration
        {
            get
            {
                var provider = EasyPaymentSection.Settings["paymentProvider"];
                return PaymentSection.Payments[provider.Value] as OnepayProviderElement;
            }
        }
        private readonly IOnepayEncryptorStrategy _encryptStrategy;
        private readonly IPaymentProviderSection PaymentSection;
        private readonly IEasyPaymentSection EasyPaymentSection;

        public OnepayProcessor(IOnepayEncryptorStrategy encryptStrategy, IPaymentProviderSection paymentSection,
            IEasyPaymentSection EasyPaymentSection)
        {
            this._encryptStrategy = encryptStrategy;
            this.PaymentSection = paymentSection;
            this.EasyPaymentSection = EasyPaymentSection;
        }
        
        public PaymentRequestResult Process(PaymentRequest model)
        {
            this.AddQueryParams(model as OnepayPaymentRequest);

            return this.CreateRedirectRequest();
        }

        public PaymentResponseResult Verify(NameValueCollection query)
        {
            var _responseFields = new SortedList<string, string>(new OnepayStringComparable());
            foreach (string item in query)
            {
                if (!item.Equals("vpc_SecureHash") && !item.Equals("vpc_SecureHashType"))
                {
                    _responseFields.Add(item, query[item]);
                }
            }

            if (!query["vpc_TxnResponseCode"].Equals("0") && !String.IsNullOrEmpty(query["vpc_Message"]))
            {
                if (!String.IsNullOrEmpty(query["vpc_SecureHash"]))
                {
                    if (!_encryptStrategy.MakeToken(_responseFields, PaymentConfiguration.Salt).Equals(query["vpc_SecureHash"]))
                    {
                        PaymentResponseResult.CreateInvalidResult();
                    }
                    return PaymentResponseResult.CreateSuccessResult(ExtractResponse(query));
                }
                return PaymentResponseResult.CreateSuccessResult(ExtractResponse(query));
            }

            if (String.IsNullOrEmpty(query["vpc_SecureHash"]))
            {
                return PaymentResponseResult.CreateInvalidResult();//no sercurehash response
            }
            if (!_encryptStrategy.MakeToken(_responseFields, PaymentConfiguration.Salt).Equals(query["vpc_SecureHash"]))
            {
                return PaymentResponseResult.CreateInvalidResult();
            }
            return PaymentResponseResult.CreateSuccessResult(ExtractResponse(query));

        }

        #region Private & sub methods

        private void AddQueryParams(OnepayPaymentRequest model)
        {
            _sortedValues.Add(OnepayParamKeys.Title, "onepay paygate");
            _sortedValues.Add(OnepayParamKeys.Locale, "vn");//Chon ngon ngu hien thi tren cong thanh toan (vn/en)
            _sortedValues.AddOnePayParam(OnepayParamKeys.Version, PaymentConfiguration.Version);
            _sortedValues.AddOnePayParam(OnepayParamKeys.Command, PaymentConfiguration.Command);
            _sortedValues.AddOnePayParam(OnepayParamKeys.Merchant, PaymentConfiguration.Merchant);
            _sortedValues.AddOnePayParam(OnepayParamKeys.AccessCode, PaymentConfiguration.AccessCode);
            _sortedValues.AddOnePayParam(OnepayParamKeys.MerchTxnRef, model.MerchRef.ToString());
            _sortedValues.AddOnePayParam(OnepayParamKeys.OrderInfo, model.OrderInfo);
            _sortedValues.AddOnePayParam(OnepayParamKeys.Amount, (model.Amount * 100).ToString());
            _sortedValues.AddOnePayParam(OnepayParamKeys.Currency, model.Currency);
            _sortedValues.AddOnePayParam(OnepayParamKeys.ReturnUrl, PaymentConfiguration.ReturnUrl);
            _sortedValues.Add(OnepayParamKeys.ShipStreet1, "194 Tran Quang Khai");
            _sortedValues.Add(OnepayParamKeys.ShipProvice, "Hanoi");
            _sortedValues.Add(OnepayParamKeys.ShipCity, "Hanoi");
            _sortedValues.Add(OnepayParamKeys.ShipCountry, "Vietnam");
            _sortedValues.Add(OnepayParamKeys.CustomerPhone, "043966668");
            _sortedValues.Add(OnepayParamKeys.CustomerEmail, "support@onepay.vn");
            _sortedValues.Add(OnepayParamKeys.CustomerId, "onepay_paygate");
            _sortedValues.AddOnePayParam(OnepayParamKeys.TicketNo, null);
        }

        private PaymentRequestResult CreateRedirectRequest()
        {
            var data = String.Join("&", _sortedValues.Keys.Select(key => String.Format("{0}={1}", key, HttpUtility.UrlEncode(_sortedValues[key]))));
            //Payment Server URL
            var url = PaymentConfiguration.ProviderUrl + "?" + data;
            //Hash the request fields
            url += "&" + OnepayParamKeys.SecureHash + "=";
            var token = this._encryptStrategy.MakeToken(_sortedValues, PaymentConfiguration.Salt);
            url += token;
            return new PaymentRequestResult
            {
                Url = url,
                Token = token
            };
        }

        private OnepayPaymentResponse ExtractResponse(NameValueCollection query)
        {
            return new OnepayPaymentResponse
            {
                Amount = query[OnepayParamKeys.Amount],
                Command = query[OnepayParamKeys.Command],
                Locale = query[OnepayParamKeys.Locale],
                MerchRef = query[OnepayParamKeys.MerchTxnRef],
                Message = query[OnepayParamKeys.Message],
                OrderInfo = query[OnepayParamKeys.OrderInfo],
                TransactionNo = query[OnepayParamKeys.TransactionNo]
            };
        }

        #endregion
    }
}
