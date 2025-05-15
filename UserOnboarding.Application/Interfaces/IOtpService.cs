using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOnboarding.Application.DTOs;

namespace UserOnboarding.Application.Interfaces;

public interface IOtpService
{
    Task<bool> SendMobileOtpAsync(string icNumber);
    Task<bool> VerifyMobileOtpAsync(VerifyMobileOtpDto dto);
    Task<bool> SendEmailOtpAsync(string icNumber);
    Task<bool> VerifyEmailOtpAsync(VerifyEmailOtpDto dto);
}
