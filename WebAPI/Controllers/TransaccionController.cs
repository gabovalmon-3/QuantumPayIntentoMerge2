using Microsoft.AspNetCore.Mvc;
using BaseManager;
using DTOs;
using System;
using System.Threading.Tasks;
using CoreApp;
using System.Data.SqlClient;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransaccionController : ControllerBase
    {
        private readonly TransaccionManager _manager = new();

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Crear([FromBody] Transaccion transaccion)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _manager.Create(transaccion);
                return Ok(new { message = "Transacción creada exitosamente." });
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("FOREIGN KEY constraint"))
                {
                    return BadRequest(new { error = "Alguna de las entidades relacionadas (cliente, comercio o banco) no existe o es inválida." });
                }
                return BadRequest(new { error = "Error de base de datos: " + ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        [Route("RetrieveAll")]
        public ActionResult RetrieveAll()
        {
            try
            {
                var cm = new TransaccionManager();
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
        public ActionResult RetrieveById(int id)
        {
            try
            {
                var cm = new TransaccionManager();
                var result = cm.OrdenarPorId(id);
                if (result == null)
                {
                    return Ok(new List<object>());
                }

                return Ok(new List<object> { result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveByBanco")]
        public ActionResult RetrieveByBanco(int idCuentaBancaria)
        {
            try
            {
                var cm = new TransaccionManager();
                var result = cm.OrdenarPorBanco(idCuentaBancaria);
                if (result == null)
                {
                    return Ok(new List<object>());
                }

                return Ok(new List<object> { result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveByComercio")]
        public ActionResult RetrieveByComercio(int idComercio)
        {
            try
            {
                var cm = new TransaccionManager();
                var result = cm.OrdenarPorComercio(idComercio);
                if (result == null)
                {
                    return Ok(new List<object>());
                }

                return Ok(new List<object> { result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveByCliente")]
        public ActionResult RetrieveByCliente(int idCliente)
        {
            try
            {
                var cm = new TransaccionManager();
                var result = cm.OrdenarPorCliente(idCliente);
                if (result == null)
                {
                    return Ok(new List<object>());
                }

                return Ok(new List<object> { result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Transaccion transaccion)
        {
            try
            {
                _manager.Update(transaccion);
                return Ok(new { message = "Transacción actualizada exitosamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var cm = new TransaccionManager();
                var existing = cm.OrdenarPorId(id);
                cm.Delete(id);
                return Ok(new { Message = $"Transaccion con ID {id} eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
