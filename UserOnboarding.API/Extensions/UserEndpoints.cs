using Microsoft.AspNetCore.Mvc;
using UserOnboarding.Application.DTOs;
using UserOnboarding.Application.Interfaces;

namespace UserOnboarding.API.Extensions
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this WebApplication app)
        {
            app.MapPost("/api/user/register", async ([FromBody] UserRegistrationDto dto, IUserService userService) =>
            {
                var isExist = await userService.CheckIfUserExists(dto);
                if (isExist)
                {
                    return Results.Conflict(new { Message = "User Already Exists" });
                }
                var userId = await userService.RegisterUserAsync(dto);
                return Results.Ok(new { Message = "User registered", UserId = userId });
            });

            app.MapPost("/api/user/accept-privacy", async ([FromBody] AcceptPrivacyPolicyDto dto, IUserService userService) =>
            {
                var success = await userService.AcceptPrivacyPolicyAsync(dto.ICNumber);
                return success ? Results.Ok("Privacy policy accepted") : Results.NotFound("User not found");
            });


            app.MapPost("/api/user/set-pin", async ([FromBody] SetPinDto dto, IUserService userService) =>
            {
                if (dto.Pin != dto.ConfirmPin)
                    return Results.UnprocessableEntity(new { Message = "PIN and Confirm PIN do not match" });
                var success = await userService.SetPinAsync(dto);
                return success
                    ? Results.Ok(new { Message = "PIN set successfully" })
                    : Results.BadRequest( new { Message = "Failed to set PIN" }); 
            });


            app.MapPost("/api/user/enable-biometric", async ([FromBody] EnableBiometricDto dto, IUserService userService) =>
            {
                var success = await userService.EnableBiometricAsync(dto);
                return success ? Results.Ok("Biometric setting updated") : Results.NotFound("User not found");
            });
        }
    }
}
