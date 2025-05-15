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
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckIfUserExists(UserRegistrationDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.ICNumber == dto.ICNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public async Task<Guid> RegisterUserAsync(UserRegistrationDto dto)
        {
            var user = new User
            {
                CustomerName = dto.CustomerName,
                ICNumber = dto.ICNumber,
                MobileNumber = dto.MobileNumber,
                Email = dto.Email
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public async Task<bool> AcceptPrivacyPolicyAsync(string icNumber)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.ICNumber == icNumber);
            if (user == null) return false;

            user.PrivacyPolicyAccepted = true;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SetPinAsync(SetPinDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.ICNumber == dto.ICNumber);
            if (user == null) return false;

            if (dto.Pin != dto.ConfirmPin) return false;

            user.PinHash = BCrypt.Net.BCrypt.HashPassword(dto.Pin); // Use BCrypt
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EnableBiometricAsync(EnableBiometricDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.ICNumber == dto.ICNumber);
            if (user == null) return false;

            user.BiometricEnabled = dto.EnableBiometric;
            await _context.SaveChangesAsync();

            return true;
        }
    }

}


