using System.Net.Mail;
using System.Threading.Tasks;

namespace LOGIN
{
    public static class EmailHelper
    {
        public static async Task SendOTPEmail(string toEmail, string otp)
        {
            var fromEmail = "leson2185@gmail.com";
            var password = "Nak2k6ntmk";

            var message = new MailMessage(fromEmail, toEmail);
            message.Subject = "Mã xác nhận quên mật khẩu";
            message.Body = $"Mã xác nhận của bạn là: {otp}";

            using var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(fromEmail, password);
            smtp.EnableSsl = true;

            try
            {
                await smtp.SendMailAsync(message);
                MessageBox.Show("Mã xác nhận đã được gửi. Vui lòng kiểm tra email!");
            }
            catch (SmtpException ex)
            {
                MessageBox.Show("Lỗi kết nối SMTP: " + ex.Message);
            }
        }
    }
}