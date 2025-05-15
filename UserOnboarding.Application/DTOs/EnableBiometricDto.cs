using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserOnboarding.Application.DTOs
{
    public class EnableBiometricDto
    {
        public string ICNumber { get; set; } = string.Empty;
        public bool EnableBiometric { get; set; }
    }
}
