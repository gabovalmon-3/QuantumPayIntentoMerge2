using BCrypt.Net;
using CoreApp;
using DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaComercioController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]

        public async Task<ActionResult> Create(CuentaComercio cuentacomercio)
        {
            try
            {
                var cm = new CuentaComercioManager();
                await cm.Create(cuentacomercio);
                return Ok(cuentacomercio);
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
                var cm = new CuentaComercioManager();
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
                var cm = new CuentaComercioManager();
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
        public ActionResult RetrieveByEmail(string CorreoElectronico)
        {
            try
            {
                var cm = new CuentaComercioManager();
                var result = cm.RetrieveByEmail(CorreoElectronico);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet]
        [Route("RetrieveByUserName")]
        public ActionResult RetrieveByUserName(string NombreUsuario)
        {
            try
            {
                var cm = new CuentaComercioManager();
                var result = cm.RetrieveByUserName(NombreUsuario);

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
                var cm = new CuentaComercioManager();
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
        public ActionResult Update(CuentaComercio cuentaComercio)
        {
            try
            {
                var cm = new CuentaComercioManager();
                cm.Update(cuentaComercio);
                return Ok(cuentaComercio);
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
                var cm = new CuentaComercioManager();
                var existing = cm.RetrieveById(id);
                cm.Delete(id);
                return Ok(new { Message = $"CuentaComercio con ID {id} eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login([FromBody] DTOs.LoginRequest request)
        {
            try
            {
                var cm = new CuentaComercioManager();
                var user = cm.RetrieveByEmail(request.Email);
                if (user == null)
                    return Unauthorized("Usuario o contraseña incorrectos.");

                if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Contrasena))
                    return Unauthorized("Usuario o contraseña incorrectos.");

                return Ok(new { Message = "Login exitoso", UserId = user.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(new { Message = "Sesión cerrada correctamente." });
        }
    }
}
