using BaseManager;
using CoreApp;
using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComisionController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]

        public async Task<ActionResult> Create(Comision comision)
        {
            try
            {
                var cm = new ComisionManager();
                await cm.Create(comision);
                return Ok(comision);
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
                var cm = new ComisionManager();
                var lstResults = cm.Listar();
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
                var cm = new ComisionManager();
                var result = cm.Obtener(Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPut]
        [Route("Update")]
        public ActionResult Update(Comision comision)
        {
            try
            {
                var cm = new ComisionManager();
                cm.Actualizar(comision);
                return Ok();
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
                var cm = new ComisionManager();
                var existing = cm.Obtener(id);
                if (existing == null)
                    return NotFound();
                cm.Eliminar(existing);
                return Ok(new { Message = $"Comision con ID {id} eliminada correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

