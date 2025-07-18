using BaseManager;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComisionController : ControllerBase
    {
        private readonly ComisionManager _cm;

        public ComisionController()
        {
            _cm = new ComisionManager();
        }

        // GET api/comision
        [HttpGet]
        public ActionResult<IEnumerable<Comision>> Get()
        {
            try
            {
                var lista = _cm.Listar();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/comision/{id}
        [HttpGet("{id}")]
        public ActionResult<Comision> Get(int id)

        {
            try
            {
                var comision = _cm.Obtener(id);
                if (comision == null) return NotFound();
                return Ok(comision);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/comision/Create
        [HttpPost]
        public async Task<ActionResult<Comision>> Post([FromBody] Comision comision)
        {
            try
            {
                await _cm.Create(comision);
                // Devuelve 201 Created + Location header
                return CreatedAtAction(nameof(Get), new { id = comision.Id }, comision);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/comision/Update
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Comision comision)
        {
            try
            {
                // Opción: validar que comision.Id == id
                var existing = _cm.Obtener(id);
                if (existing == null)
                    return NotFound();

                _cm.Actualizar(comision);
                return NoContent();      // 204 es más estándar en PUT RESTful
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/Comision/Delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var existing = _cm.Obtener(id);
                if (existing == null) return NotFound();

                _cm.Eliminar(existing);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}