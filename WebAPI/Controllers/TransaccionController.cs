﻿// WebAPI/Controllers/TransaccionController.cs
using BaseManager;
using CoreApp;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaccionController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public TransaccionController(IEmailSender emailSender)
            => _emailSender = emailSender;

        [HttpPost("Create")]
        public async Task<ActionResult<Transaccion>> Create(
            [FromBody] Transaccion t,
            [FromQuery] string email)
        {
            try
            {
                // 1) Crear la transacción
                var mgr = new TransaccionManager();
                mgr.Create(t);

                // 2) Enviar correo si recibimos email
                if (!string.IsNullOrWhiteSpace(email))
                {
                    await _emailSender.SendEmailAsync(
                        toEmail: email,
                        subject: "Confirmación de compra",
                        message: $"Compra por {t.Monto:C} procesada."
                    );
                }

                return Ok(t);
            }
            catch (System.Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ex.Message
                );
            }
        }

        [HttpPut("Update/{id}")]
        public ActionResult<Transaccion> Update(
            int id,
            [FromBody] Transaccion t)
        {
            try
            {
                t.Id = id;
                var mgr = new TransaccionManager();
                var updated = mgr.Update(t);
                return Ok(updated);
            }
            catch (System.Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ex.Message
                );
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                new TransaccionManager().Delete(id);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    ex.Message
                );
            }
        }

        [HttpGet("RetrieveAll")]
        public ActionResult<IEnumerable<Transaccion>> RetrieveAll()
            => Ok(new TransaccionManager().RetrieveAll());

        [HttpGet("RetrieveByBanco")]
        public ActionResult<IEnumerable<Transaccion>> RetrieveByBanco(
            [FromQuery] int cuentaId)
            => Ok(new TransaccionManager().RetrieveByCuenta(cuentaId));

        [HttpGet("RetrieveByComercio")]
        public ActionResult<IEnumerable<Transaccion>> RetrieveByComercio(
            [FromQuery] int idComercio)
            => Ok(new TransaccionManager().RetrieveByComercio(idComercio));

        [HttpGet("RetrieveByCliente")]
        public ActionResult<IEnumerable<Transaccion>> RetrieveByCliente(
            [FromQuery] int clienteId)
            => Ok(new TransaccionManager().RetrieveByCliente(clienteId));
    }
}
