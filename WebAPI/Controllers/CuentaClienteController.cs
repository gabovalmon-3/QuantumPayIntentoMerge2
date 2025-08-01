using CoreApp;
using DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentaClienteController : ControllerBase
    {
        [HttpGet("RetrieveAll")]
        public ActionResult RetrieveAll([FromQuery] int clienteId)
        {
            try
            {
                var m = new CuentaClienteManager();
                var list = m.RetrieveByCliente(clienteId);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] ClienteCuenta dto)
        {
            try
            {
                var m = new CuentaClienteManager();
                m.Create(dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] ClienteCuenta dto)
        {
            try
            {
                var m = new CuentaClienteManager();
                m.Update(dto);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var m = new CuentaClienteManager();
                m.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
