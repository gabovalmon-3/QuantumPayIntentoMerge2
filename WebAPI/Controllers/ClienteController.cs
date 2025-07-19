using CoreApp;
using DTOs;
using BaseManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]

        public async Task<ActionResult> Create(Cliente cliente, [FromQuery] string emailCode, [FromQuery] string smsCode)
        {
            try
            {
                //VERIFICADORES

                var emailVerifier = new EmailVerificationManager(); //instancia del verificador de email
                var smsVerifier = new SmsVerificationManager(); // instancia del verificador de SMS



                // Verificar código OTP email 1
                bool emailVerified = emailVerifier.VerifyCode(cliente.correo, emailCode);
                if (!emailVerified)
                    return BadRequest("Código de verificación de email inválido.");

                // Verificar código OTP de SMS
                bool smsVerified = smsVerifier.VerifyCode(cliente.telefono.ToString(), smsCode);
                if (!smsVerified)
                    return BadRequest("Código de verificación SMS inválido.");

                // Leer variables de entorno dentro de sistema (HAY QUE CONFIGURARLAS EN EL SERVIDOR)
                var awsAccessKeyId = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID")
                    ?? throw new Exception("AWS_ACCESS_KEY_ID no configurada.");
                var awsSecretKey = Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY")
                    ?? throw new Exception("AWS_SECRET_ACCESS_KEY no configurada.");
                var awsRegionName = Environment.GetEnvironmentVariable("AWS_REGION") ?? "us-east-1";
                var region = Amazon.RegionEndpoint.GetBySystemName(awsRegionName);

                var faceVerifier = new FaceRecognitionManager(awsAccessKeyId, awsSecretKey, region);

                // Convertir imágenes base64 a byte[]
                byte[] cedulaBytes = Convert.FromBase64String(cliente.fotoCedula);
                byte[] selfieBytes = Convert.FromBase64String(cliente.fotoPerfil);

                // Verificar selfie vs cédula
                bool faceMatch = await faceVerifier.VerifyFaceAsync(selfieBytes, cedulaBytes);
                if (!faceMatch)
                    return BadRequest("La selfie no coincide con la imagen de la cédula.");

                //SI PASA LAS VERIFICACIONES, CREAR EL CLIENTE

                var cm = new ClienteManager();
                await cm.Create(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("RetrieveAll")]
        public ActionResult RetrieveAll()
        {
            try
            {
                var cm = new ClienteManager();
                var lstResults = cm.RetrieveAll();
                return Ok(lstResults);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveById")]
        public ActionResult RetrieveById(int Id)
        {
            try
            {
                var cm = new ClienteManager();
                var result = cm.RetrieveById(Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveByEmail")]
        public ActionResult RetrieveByEmail(string correo)
        {
            try
            {
                var cm = new ClienteManager();
                var result = cm.RetrieveByEmail(correo);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet]
        [Route("RetrieveByCedula")]
        public ActionResult Retrieve(string cedula)
        {
            try
            {
                var cm = new ClienteManager();
                var result = cm.RetrieveByCedula(cedula);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet]
        [Route("RetrieveByTelefono")]
        public ActionResult RetrieveByTelefono(int telefono)
        {
            try
            {
                var cm = new ClienteManager();
                var result = cm.RetrieveByTelefono(telefono);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Update(Cliente cliente)
        {
            try
            {
                var cm = new ClienteManager();
                var updatedCliente = cm.Update(cliente);
                return Ok(updatedCliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var cm = new ClienteManager();
                var existing = cm.RetrieveById(id);
                cm.Delete(id);
                return Ok(new { Message = $"Usuario con ID {id} eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("SendEmailVerification")]
        public ActionResult SendEmailVerification(string email)
        {
            try
            {
                var emailVerifier = new EmailVerificationManager();
                emailVerifier.SendVerificationCode(email);
                return Ok("Código de verificación enviado por email.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("SendSmsVerification")]
        public ActionResult SendSmsVerification(string telefono)
        {
            try
            {
                var smsVerifier = new SmsVerificationManager();
                smsVerifier.SendVerificationCode(telefono);
                return Ok("Código de verificación enviado por SMS.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
