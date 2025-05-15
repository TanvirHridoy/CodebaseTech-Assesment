
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserOnboarding.Domain.Entities
{
    public enum OTPType
    {
        Mobile,
        Email
    }

    public class OTP
    {
        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public OTPType Type { get; set; }
        public string Destination { get; set; } = string.Empty; // email or mobile number

        public DateTime ExpiryTime { get; set; }
        public bool IsUsed { get; set; } = false;

        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
    }


}
