using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOnboarding.Application.DTOs;
using UserOnboarding.Application.Interfaces;
using UserOnboarding.Domain.Entities;
using UserOnboarding.Infrastructure;

namespace UserOnboarding.Application.Services
{
    public class OtpService : IOtpService
    {
        private readonly AppDbContext _context;

        public OtpService(AppDbContext context)
        {
            _context = context;
        }

        private string GenerateOtp() => new Random().Next(1000, 9999).ToString();

        public async Task<bool> SendMobileOtpAsync(string icNumber)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.ICNumber == icNumber);
            if (user == null) return false;

            var otp = new OTP
            {
                Code = GenerateOtp(),
                Type = OTPType.Mobile,
                Destination = user.MobileNumber,
                ExpiryTime = DateTime.UtcNow.AddMinutes(5),
                UserId = user.Id
            };

            _context.OTPs.Add(otp);
            await _context.SaveChangesAsync();

            // Simulate sending SMS
            Console.WriteLine($"[SMS] OTP for mobile: {otp.Code}");

            return true;
        }

        public async Task<bool> VerifyMobileOtpAsync(VerifyMobileOtpDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.ICNumber == dto.ICNumber);
            if (user == null) return false;

            var otp = await _context.OTPs
                .Where(o => o.UserId == user.Id && o.Type == OTPType.Mobile && !o.IsUsed)
                .OrderByDescending(o => o.ExpiryTime)
                .FirstOrDefaultAsync();

            if (otp == null || otp.Code != dto.OtpCode || otp.ExpiryTime < DateTime.UtcNow)
                return false;

            otp.IsUsed = true;
            user.IsMobileVerified = true;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SendEmailOtpAsync(string icNumber)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.ICNumber == icNumber);
            if (user == null) return false;

            var otp = new OTP
            {
                Code = GenerateOtp(),
                Type = OTPType.Email,
                Destination = user.Email,
                ExpiryTime = DateTime.UtcNow.AddMinutes(5),
                UserId = user.Id
            };

            _context.OTPs.Add(otp);
            await _context.SaveChangesAsync();

            // Simulate sending Email
            Console.WriteLine($"[Email] OTP for email: {otp.Code}");

            return true;
        }

        public async Task<bool> VerifyEmailOtpAsync(VerifyEmailOtpDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.ICNumber == dto.ICNumber);
            if (user == null) return false;

            var otp = await _context.OTPs
                .Where(o => o.UserId == user.Id && o.Type == OTPType.Email && !o.IsUsed)
                .OrderByDescending(o => o.ExpiryTime)
                .FirstOrDefaultAsync();

            if (otp == null || otp.Code != dto.OtpCode || otp.ExpiryTime < DateTime.UtcNow)
                return false;

            otp.IsUsed = true;
            user.IsEmailVerified = true;

            await _context.SaveChangesAsync();
            return true;
        }
    }

}
