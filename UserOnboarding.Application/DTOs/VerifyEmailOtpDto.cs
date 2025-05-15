using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserOnboarding.Application.DTOs
{
    public class VerifyEmailOtpDto
    {
        public string ICNumber { get; set; } = string.Empty;
        public string OtpCode { get; set; } = string.Empty; // 4-digit OTP
    }

}
