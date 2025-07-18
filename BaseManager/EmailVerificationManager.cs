using System;
using Twilio;
using Twilio.Rest.Verify.V2.Service;

namespace BaseManager
{
    public class EmailVerificationManager
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _verifyServiceSid;

        public EmailVerificationManager()
        {
            // Leer variables de entorno
            _accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID")
                ?? throw new ArgumentNullException("TWILIO_ACCOUNT_SID no está configurada en variables de entorno.");

            _authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN")
                ?? throw new ArgumentNullException("TWILIO_AUTH_TOKEN no está configurada en variables de entorno.");

            _verifyServiceSid = Environment.GetEnvironmentVariable("TWILIO_VERIFY_SID")
                ?? throw new ArgumentNullException("TWILIO_VERIFY_SID no está configurada en variables de entorno.");

            TwilioClient.Init(_accountSid, _authToken);
        }

        public void SendVerificationCode(string email)
        {
            var verification = VerificationResource.Create(
                to: email,
                channel: "email",
                pathServiceSid: _verifyServiceSid
            );

            Console.WriteLine($"Código enviado al email {email}. Estado: {verification.Status}");
        }

        public bool VerifyCode(string email, string code)
        {
            var verificationCheck = VerificationCheckResource.Create(
                to: email,
                code: code,
                pathServiceSid: _verifyServiceSid
            );

            Console.WriteLine($"Resultado de verificación: {verificationCheck.Status}");
            return verificationCheck.Status == "approved";
        }
    }
}
