using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserOnboarding.Application.DTOs
{
    public class UserRegistrationDto
    {
        public string CustomerName { get; set; } = string.Empty;
        public string ICNumber { get; set; } = string.Empty; // Unique login
        public string MobileNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

}
