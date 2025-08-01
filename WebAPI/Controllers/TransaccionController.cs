using BaseManager;
using CoreApp;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaccionController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public TransaccionController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Transaccion>> Create([FromBody] Transaccion transaccion, [FromQuery] string email)
        {
            try
            {
                var tm = new TransaccionManager();
                await tm.Create(transaccion);
                if (!string.IsNullOrWhiteSpace(email))
                {
                    try
                    {
                        await _emailSender.SendEmailAsync(email, "Confirmación de compra", $"Su compra por {transaccion.Monto:C} ha sido procesada.");
                    }
                    catch
                    {
                        // ignore email send errors
                    }
                }
                return Ok(transaccion);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // Aquí eliminamos la ambigüedad: solo un atributo HTTP con ruta clara
        [HttpPut("Update/{id}")]
        public ActionResult<Transaccion> Update(int id, [FromBody] Transaccion transaccion)
        {
            try
            {
                transaccion.Id = id;
                var tm = new TransaccionManager();
                tm.Update(transaccion);
                return Ok(transaccion);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("RetrieveAll")]
        public ActionResult<IEnumerable<Transaccion>> RetrieveAll()
        {
            try
            {
                var tm = new TransaccionManager();
                var lstResults = tm.RetrieveAll();
                return Ok(lstResults);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("RetrieveByBanco")]

        public ActionResult<IEnumerable<Transaccion>> RetrieveByBanco([FromQuery] int cuentaId)


        public ActionResult<IEnumerable<Transaccion>> RetrieveByBanco([FromQuery] int cuentaId)

        public ActionResult<Transaccion> RetrieveByBanco([FromQuery] int cuentaId)


        {
            try
            {
                var tm = new TransaccionManager();
                var result = tm.OrdenarPorBanco(cuentaId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("RetrieveByComercio")]

        public ActionResult<IEnumerable<Transaccion>> RetrieveByComercio([FromQuery] int idComercio)


        public ActionResult<IEnumerable<Transaccion>> RetrieveByComercio([FromQuery] int idComercio)

        public ActionResult<Transaccion> RetrieveByComercio([FromQuery] int idComercio)


        {
            try
            {
                var tm = new TransaccionManager();
                var result = tm.OrdenarPorComercio(idComercio);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("RetrieveByCliente")]

        public ActionResult<IEnumerable<Transaccion>> RetrieveByCliente([FromQuery] int clienteId)


        public ActionResult<IEnumerable<Transaccion>> RetrieveByCliente([FromQuery] int clienteId)

        public ActionResult<Transaccion> RetrieveByCliente([FromQuery] int clienteId)


        {
            try
            {
                var tm = new TransaccionManager();
                var result = tm.OrdenarPorCliente(clienteId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
