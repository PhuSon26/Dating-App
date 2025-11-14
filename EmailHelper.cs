using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOGIN
{
    public static class EmailHelper
    {
        // ⚠️ THAY BẰNG APP PASSWORD TỪ GMAIL: https://myaccount.google.com/apppasswords
        private const string FromEmail = "lequangquy1522006@gmail.com";
        private const string AppPassword = "yqwy ckhr yxqz dknx"; // ← Thay bằng App Password 16 ký tự

        // SỬA: Thêm <bool> vào Task và return true/false
        public static async Task<bool> SendOTPEmail(string toEmail, string otp)
        {
            if (string.IsNullOrWhiteSpace(toEmail) || string.IsNullOrWhiteSpace(otp))
            {
                MessageBox.Show("Email hoặc mã OTP không hợp lệ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                using (var message = new MailMessage(FromEmail, toEmail))
                {
                    message.Subject = "Mã xác nhận quên mật khẩu";
                    message.IsBodyHtml = true;
                    message.Body = GetEmailTemplate(otp);

                    using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(FromEmail, AppPassword);
                        smtp.EnableSsl = true;
                        smtp.Timeout = 10000;

                        await smtp.SendMailAsync(message);
                    }
                }

                MessageBox.Show("Mã xác nhận đã được gửi!\nVui lòng kiểm tra email của bạn.",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true; // ← Trả về true khi thành công
            }
            catch (SmtpException ex)
            {
                string errorMessage = ex.StatusCode switch
                {
                    SmtpStatusCode.MailboxUnavailable => "Email không tồn tại!",
                    SmtpStatusCode.ServiceNotAvailable => "Dịch vụ email tạm thời không khả dụng.",
                    _ => $"Lỗi SMTP: {ex.Message}"
                };

                MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // ← Trả về false khi lỗi
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // ← Trả về false khi lỗi
            }
        }

        // Template HTML cho email đẹp hơn
        private static string GetEmailTemplate(string otp)
        {
            return $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 0; }}
        .container {{ max-width: 600px; margin: 50px auto; background: white; padding: 30px; 
                      border-radius: 10px; box-shadow: 0 2px 10px rgba(0,0,0,0.1); }}
        .header {{ text-align: center; color: #333; }}
        .otp-box {{ background: #f0f8ff; border: 2px dashed #4CAF50; padding: 20px; 
                    margin: 20px 0; text-align: center; border-radius: 5px; }}
        .otp-code {{ font-size: 32px; font-weight: bold; color: #4CAF50; letter-spacing: 5px; }}
        .warning {{ color: #ff6b6b; font-size: 14px; margin-top: 20px; }}
        .footer {{ text-align: center; color: #888; font-size: 12px; margin-top: 30px; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h2>🔐 Đặt lại mật khẩu</h2>
        </div>
        <p>Xin chào,</p>
        <p>Bạn đã yêu cầu đặt lại mật khẩu. Vui lòng sử dụng mã xác nhận bên dưới:</p>
        
        <div class='otp-box'>
            <div class='otp-code'>{otp}</div>
        </div>
        
        <p><strong>Lưu ý:</strong></p>
        <ul>
            <li>Mã này có hiệu lực trong <strong>5 phút</strong></li>
            <li>Không chia sẻ mã này với bất kỳ ai</li>
            <li>Nếu bạn không yêu cầu đặt lại mật khẩu, vui lòng bỏ qua email này</li>
        </ul>
        
        <div class='warning'>
            ⚠️ Nếu bạn không thực hiện thao tác này, hãy liên hệ với chúng tôi ngay!
        </div>
        
        <div class='footer'>
            <p>Email này được gửi tự động, vui lòng không trả lời.</p>
            <p>&copy; 2025 Dating App. All rights reserved.</p>
        </div>
    </div>
</body>
</html>";
        }
    }
}