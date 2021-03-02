using System;
using System.Collections.Generic;
using System.Text;

namespace MeterAfricaClassLib.Utilities
{
    public class PaystackApiEndPoints
    {
        public static string CreateTransferRecipient = "https://api.paystack.co/transferrecipient";

        public static string InititateTransfer = "https://api.paystack.co/transfer";
        public static string SendTransferOtp = "https://api.paystack.co/transfer/resend_otp";
        public static string ResendTransferOtp = "https://api.paystack.co/transfer/resend_otp";
        public static string Finalizetransfer = "https://api.paystack.co/transfer/finalize_transfer";

        public static string ListBanks = "https://api.paystack.co/bank";

        public static string ResolveAccount = "https://api.paystack.co/bank/resolve";
        public static string VerifyTransaction = "https://api.paystack.co/transaction/verify";
    }
}
