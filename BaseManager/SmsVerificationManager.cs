using System;
using Twilio;
using Twilio.Rest.Verify.V2.Service;

namespace BaseManager
{
    public class SmsVerificationManager
    {
        //variables de entorno para Twilio
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _verifyServiceSid;

        public SmsVerificationManager()
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

        public void SendVerificationCode(string telefono)
        {
            var verification = VerificationResource.Create(
                to: telefono,
                channel: "sms",
                pathServiceSid: _verifyServiceSid
            );

            Console.WriteLine($"Código enviado por SMS a {telefono}. Estado: {verification.Status}");
        }

        public bool VerifyCode(string telefono, string code)
        {
            var verificationCheck = VerificationCheckResource.Create(
                to: telefono,
                code: code,
                pathServiceSid: _verifyServiceSid
            );

            Console.WriteLine($"Resultado de verificación SMS: {verificationCheck.Status}");
            return verificationCheck.Status == "approved";
        }
    }
}
