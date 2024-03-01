using System;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailSenderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sender details
            string senderName = "Abhishek Patil";
            string senderEmail = "abhishek.ayerhscsm@gmail.com";
            string senderPassword = "YOUR_PASSWORD";

            // Recipient details
            string recipientName = "Abhishek M Patil";
            string recipientEmail = "ap574781@gmail.com";

            // Email message details
            string subject = "Test Email from MailKit";

            // HTML body with CSS styles
            string htmlBody = @"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Registration OTP</title>
    <style>
        body, h1, p {
  margin: 0;
  padding: 0;
  font-family: 'Segoe UI', Tahoma, sans-serif; 
}

.container {
  max-width: 600px;
  margin: 20px auto; 
  padding: 20px;
  background: linear-gradient(135deg, #ff9966, #ff5e62); 
  border-radius: 10px;
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
  color: #ffffff;
  text-align: center;
}

.otp {
  background-color: #ffffff;
  color: #333333; 
  padding: 15px 30px;
  border-radius: 5px;
  font-size: 32px;
  margin: 20px 0;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
  font-family: monospace; 
}

.social-link {
  margin-top: 20px;
  display: block;
}

.social-link a { 
  color: #ffeb3b; 
  text-decoration: none;
  display: inline-block;
  transition: all 0.3s ease-in-out;
}

.social-link img {
  width: 24px;
  height: 24px;
  vertical-align: middle;
}

.social-link a:hover {
  opacity: 0.8; 
}
    </style>
</head>
<body>
  <div class=""container"">
    <h1>Welcome to Our Website!</h1>
    <p>Thank you for registering. Your One-Time Password (OTP) is:</p>
    <div class=""otp"">123456</div>
    <p>Please use this OTP to complete your registration.</p>
    
    <p class=""social-link"">
      Connect with us on LinkedIn: 
      <a href=""https://www.linkedin.com/in/yuvraj96k/"" target=""_blank"">
        <img src=""https://upload.wikimedia.org/wikipedia/commons/thumb/c/ca/LinkedIn_logo_initials.png/600px-LinkedIn_logo_initials.png"" alt=""LinkedIn Icon"">
      </a>
    </p>
  </div>
</body>
</html>";


            try
            {
                // Create a new MimeMessage
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(senderName, senderEmail));
                message.To.Add(new MailboxAddress(recipientName, recipientEmail));
                message.Subject = subject;

                // Construct the HTML body using BodyBuilder
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = htmlBody;

                // Set the message body
                message.Body = bodyBuilder.ToMessageBody();

                // Connect to the SMTP server
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false); // Use the correct SMTP server and port
                    client.Authenticate(senderEmail, senderPassword);

                    // Send the message
                    client.Send(message);

                    // Disconnect from the SMTP server
                    client.Disconnect(true);
                }

                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }

            Console.ReadLine(); // Keep console window open
        }
    }
}
