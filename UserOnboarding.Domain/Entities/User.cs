using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserOnboarding.Domain.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string ICNumber { get; set; } = string.Empty;
    public string MobileNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public bool? IsMobileVerified { get; set; }
    public bool? IsEmailVerified { get; set; }
    public bool? PrivacyPolicyAccepted { get; set; }

    public string? PinHash { get; set; }
    public bool? BiometricEnabled { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}


