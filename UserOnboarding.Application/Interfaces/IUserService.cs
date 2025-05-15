using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOnboarding.Application.DTOs;

namespace UserOnboarding.Application.Interfaces;

public interface IUserService
{
    Task<bool> CheckIfUserExists(UserRegistrationDto dto);
    Task<Guid> RegisterUserAsync(UserRegistrationDto dto);
    Task<bool> AcceptPrivacyPolicyAsync(string icNumber);
    Task<bool> SetPinAsync(SetPinDto dto);
    Task<bool> EnableBiometricAsync(EnableBiometricDto dto);
}
