using System.Net.Mail;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace LOGIN
{
    public static class EmailHelper
    {
        private static string sendGridApiKey = "YOUR_SENDGRID_API_KEY";
        private static string fromEmail = "leson2185@gmail.com";
        private static string fromName = "Hệ thống OTP";

        public static async Task<bool> SendOTPEmail(string toEmail, string otp)
        {
            var client = new SendGridClient(sendGridApiKey);
            var from = new EmailAddress(fromEmail, fromName);
            var subject = "Mã xác nhận quên mật khẩu";
            var to = new EmailAddress(toEmail);
            var plainTextContent = $"Mã OTP của bạn là: {otp}";
            var htmlContent = $"<strong>Mã OTP của bạn là: {otp}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            try
            {
                var response = await client.SendEmailAsync(msg);
                return response.StatusCode == System.Net.HttpStatusCode.Accepted;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi OTP: " + ex.Message);
                return false;
            }
        }
    }
}
