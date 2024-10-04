using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlumniE_ConnectApi.Contract.Models;
using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Provider.Database;
using AlumniE_ConnectApi.Contract.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AlumniE_ConnectApi.Provider.Services
{

    public class EmailServices : IEmailServices
    {
        private readonly dbContext _dbContext;
        private readonly EmailConfiguration emailConfiguration;
        public EmailServices(dbContext _dbContext, EmailConfiguration emailConfiguration)
        {
            this._dbContext = _dbContext;
            this.emailConfiguration = emailConfiguration;
        }

        
        public async Task<bool> SendEmail(string recipientEmail, string name, bool forgetPassword)
        {
            try
            {
                var otp_Code = new Random().Next(100000, 999999).ToString();
                var newotp = new Otp
                {
                    Email = recipientEmail,
                    Code = otp_Code,
                    ExpirationTime = DateTime.UtcNow.AddMinutes(5).AddHours(5).AddMinutes(30)
                };
                await _dbContext.Otps.AddAsync(newotp);
                await _dbContext.SaveChangesAsync();
                var subject = "OTP For Your Alumni E-Connect Account SignUp";
                var body = $@"
    <p>Dear {name},</p>
    <br>
    <p>
        You can use the following one-time password (OTP) to sign up to your Alumni E-Connect account:
    </p>
    <br>
    <p><strong>OTP:</strong> {otp_Code}</p>
    <br>
    <p><strong>Note:</strong> OTP is valid for next 5 minutes</p>
    <br>
    <p>
        Please visit our website at <a href='http://www.google.com'>websitelink</a>
    </p>
    <br>
    <p>
        Thank you for choosing Alumni E-Connect. We are thrilled to welcome you as a valued member of our community and are committed to offering you a seamless experience.
    </p>
    <br>
    <p>
        Please feel free to contact our support team.
    </p>
    <br>
    <p>
    <p>
        Warm regards,<br>
        Alumni E-Connect Team
    </p>";      
                if (forgetPassword)
                {
                    body = $@"
    <p>Dear {name},</p>
    <br>
    <p>
        You can use the following one-time password (OTP) to forget your Alumni E-Connect account Password:
    </p>
    <br>
    <p><strong>OTP:</strong> {otp_Code}</p>
    <br>
    <p><strong>Note:</strong> OTP is valid for next 5 minutes</p>
    <br>
    <p>
        Please visit our website at <a href='http://www.google.com'>websitelink</a>
    </p>
    <br>
    <p>
        Thank you for choosing Alumni E-Connect. We are thrilled to welcome you as a valued member of our community and are committed to offering you a seamless experience.
    </p>
    <br>
    <p>
        Please feel free to contact our support team.
    </p>
    <br>
    <p>
    <p>
        Warm regards,<br>
        Alumni E-Connect Team
    </p>";
                }
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("Alumni E-Connect", emailConfiguration.Username));
                email.To.Add(new MailboxAddress("", recipientEmail));
                email.Subject = subject;

                // Create the body of the email
                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = body, // Set the HTML body
                    TextBody = body // Set the plain text body
                };
                email.Body = bodyBuilder.ToMessageBody();

                // Send the email
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(emailConfiguration.SmtpServer, emailConfiguration.SmtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(emailConfiguration.Username, emailConfiguration.Password);
                    await client.SendAsync(email);
                    await client.DisconnectAsync(true);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> VerifyOtp(string recipientEmail, string otp_code)
        {
            try
            {
                var otp = await _dbContext.Otps.Where(o => o.Email == recipientEmail && o.Code == otp_code).FirstOrDefaultAsync();
                if (otp == null || otp.ExpirationTime <= DateTime.Now)
                {
                    return false;
                }
                _dbContext.Otps.Remove(otp);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
