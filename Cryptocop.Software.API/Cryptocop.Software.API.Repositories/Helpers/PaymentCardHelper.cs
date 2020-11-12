namespace Cryptocop.Software.API.Repositories.Helpers
{
    public class PaymentCardHelper
    {
        public static string MaskPaymentCard(string paymentCardNumber)
        {
            // TODO: Implement
            // length of cardnumber
            var len = paymentCardNumber.Length;

            // first numbers that should be masked
            var first = paymentCardNumber.Substring(0, 12);

            // the last numbers that are shown
            var last = paymentCardNumber.Substring(len - 4, 4);

            // numbers in first are masked
            var masking = new string('*', len - last.Length);

            return masking + last;
        }
    }
}