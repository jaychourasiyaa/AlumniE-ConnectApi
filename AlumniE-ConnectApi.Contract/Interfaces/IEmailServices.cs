using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumniE_ConnectApi.Contract.Interfaces
{
    public interface IEmailServices
    {
        public Task<bool> SendEmail(string recipientEmail, string name, bool forgetPassword);
        public Task<bool> VerifyOtp(string recipientEmail, string otp);
    }
}
