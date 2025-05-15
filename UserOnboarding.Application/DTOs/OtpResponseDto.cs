using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserOnboarding.Application.DTOs
{
    public class OtpResponseDto
    {
        public string Destination { get; set; } = string.Empty; // Mobile or Email
        public string OtpCode { get; set; } = string.Empty;
        public DateTime ExpiryTime { get; set; }
    }

}
