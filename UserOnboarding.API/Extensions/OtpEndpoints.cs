using Microsoft.AspNetCore.Mvc;
using UserOnboarding.Application.DTOs;
using UserOnboarding.Application.Interfaces;

namespace UserOnboarding.API.Extensions
{
    public static class OtpEndpoints
    {
        public static void MapOtpEndpoints(this WebApplication app)
        {
            app.MapPost("/api/otp/send-mobile", async ([FromBody] SendOtpRequestDto dto, IOtpService otpService) =>
            {
                var success = await otpService.SendMobileOtpAsync(dto.ICNumber);
                return success
                    ? Results.Ok("OTP sent to mobile")
                    : Results.NotFound("User not found");
            });

            app.MapPost("/api/otp/verify-mobile", async ([FromBody] VerifyMobileOtpDto dto, IOtpService otpService) =>
            {
                var success = await otpService.VerifyMobileOtpAsync(dto);
                return success
                    ? Results.Ok("Mobile number verified")
                    : Results.BadRequest("Invalid or expired OTP");
            });

            app.MapPost("/api/otp/send-email", async ([FromBody] SendOtpRequestDto dto, IOtpService otpService) =>
            {
                var success = await otpService.SendEmailOtpAsync(dto.ICNumber);
                return success
                    ? Results.Ok("OTP sent to email")
                    : Results.NotFound("User not found");
            });

            app.MapPost("/api/otp/verify-email", async ([FromBody] VerifyEmailOtpDto dto, IOtpService otpService) =>
            {
                var success = await otpService.VerifyEmailOtpAsync(dto);
                return success
                    ? Results.Ok("Email verified")
                    : Results.BadRequest("Invalid or expired OTP");
            });
        }
    }

}
