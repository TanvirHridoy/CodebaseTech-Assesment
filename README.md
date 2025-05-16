# 📱 User Onboarding API (.NET 8)

A clean and modular API-only backend built using **.NET 8** to support a **mobile app-based user onboarding system**. This project handles new user registration, mobile/email OTP verification, privacy policy acceptance, secure PIN setup, and optional biometric login.

---

## ✅ Features

- User registration with IC number (used for login)
- 4-digit OTP verification for mobile and email
- Privacy policy agreement tracking
- Secure 6-digit PIN setup (hashed)
- Biometric enablement toggle
- Minimal API + Clean Architecture
- Entity Framework Core for data access

---

## 🛠 Tech Stack

- [.NET 8 Minimal APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis)
- Entity Framework Core
- Clean Architecture (API, Application, Domain, Infrastructure)
- BCrypt for secure PIN hashing

---

## 📁 Project Structure

UserOnboarding/
 1. API/ // Minimal API entry point and endpoints
 2. Application/ // DTOs, Interfaces, Services
 3. Domain/ // Core entities
 4. Infrastructure/ // EF DbContext, data logic
 README.md


---

## 📦 Running the Project
1. Restore dependencies
dotnet restore

3. Run EF Core migrations
Using Package Manager Console:

Default project: UserOnboarding.Infrastructure

Startup project: UserOnboarding.API

Update-Database -StartupProject UserOnboarding.API -Project UserOnboarding.Infrastructure

3. Run the application

dotnet run --project UserOnboarding.API

Swagger UI available at:
https://localhost:<port>/swagger


🚀 API Endpoints
🧾 1. Register User
POST /api/user/register

Registers a new user by IC number, name, mobile, and email.
{
  "customerName": "John Doe",
  "icNumber": "ABC123456",
  "mobileNumber": "+1234567890",
  "email": "john@example.com"
}
✅ 200 OK | ❌ 409 Conflict

📱 2. Send Mobile OTP
POST /api/otp/send-mobile

{
  "icNumber": "ABC123456"
}
✅ 200 OK | ❌ 404 Not Found

✅ 3. Verify Mobile OTP
POST /api/otp/verify-mobile

{
  "icNumber": "ABC123456",
  "otp": "1234"
}
✅ 200 OK | ❌ 400 Bad Request

📧 4. Send Email OTP
POST /api/otp/send-email

{
  "icNumber": "ABC123456"
}
✅ 200 OK | ❌ 404 Not Found


✅ 5. Verify Email OTP
POST /api/otp/verify-email

{
  "icNumber": "ABC123456",
  "otp": "5678"
}
✅ 200 OK | ❌ 400 Bad Request

📃 6. Accept Privacy Policy
POST /api/user/accept-privacy

{
  "icNumber": "ABC123456"
}
✅ 200 OK | ❌ 404 Not Found

🔐 7. Set PIN
POST /api/user/set-pin
{
  "icNumber": "ABC123456"
  "pin": "123456",
  "confirmPin": "123456"
}
✅ 200 OK | ❌ 422 Unprocessable Entity | ❌ 400 Bad Request

🧬 8. Enable Biometric
POST /api/user/enable-biometric

{
  "icNumber": "ABC123456"
}
✅ 200 OK | ❌ 404 Not Found



📘 Notes
All OTPs are 4-digit codes (simulated in memory or logs).

IC Number is used for identity checks before PIN, OTP, or privacy actions.

PINs are hashed using BCrypt for security.

No actual SMS/Email delivery is implemented — stub logic only.

This is a demo implementation; proper security and auth should be added for production use.

🧪 Testing
Use Postman or Swagger to test endpoints locally:
https://localhost:<PORT>/swagger


📄 License
This project was created for demonstration and interview purposes. Feel free to use, fork, or extend as needed.

