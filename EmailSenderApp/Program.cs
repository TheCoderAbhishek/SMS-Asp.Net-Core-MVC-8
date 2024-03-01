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
            string senderEmail = "SENDER_EMAIL_ID";
            string senderPassword = "SENDER_PASSWORD";

            // Recipient details
            string recipientName = "RECIPIENT_NAME";
            string recipientEmail = "RECIPIENT_EMAIL_ID";

            // Email message details
            string subject = "Test Email from MailKit";
            string body = "This is a test email sent using MailKit.";

            try
            {
                // Create a new MimeMessage
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(senderName, senderEmail));
                message.To.Add(new MailboxAddress(recipientName, recipientEmail));
                message.Subject = subject;
                message.Body = new TextPart("plain")
                {
                    Text = body
                };

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
