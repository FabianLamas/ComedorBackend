using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.DataEntidades;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumosHistsController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ConsumosHistsController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/ConsumosHists
        [HttpGet]
        public IEnumerable<ConsumoHist> GetConsumosHists()
        {
            return _context.ConsumosHists;
        }

        // GET: api/ConsumosHists/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConsumoHist([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consumoHist = await _context.ConsumosHists.FindAsync(id);

            if (consumoHist == null)
            {
                return NotFound();
            }

            return Ok(consumoHist);
        }

        // PUT: api/ConsumosHists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumoHist([FromRoute] int id, [FromBody] ConsumoHist consumoHist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consumoHist.Id)
            {
                return BadRequest();
            }

            _context.Entry(consumoHist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumoHistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ConsumosHists
        [HttpPost]
        public async Task<IActionResult> PostConsumoHist([FromBody] ConsumoHist consumoHist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ConsumosHists.Add(consumoHist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsumoHist", new { id = consumoHist.Id }, consumoHist);
        }

        // DELETE: api/ConsumosHists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumoHist([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consumoHist = await _context.ConsumosHists.FindAsync(id);
            if (consumoHist == null)
            {
                return NotFound();
            }

            _context.ConsumosHists.Remove(consumoHist);
            await _context.SaveChangesAsync();

            return Ok(consumoHist);
        }

        private bool ConsumoHistExists(int id)
        {
            return _context.ConsumosHists.Any(e => e.Id == id);
        }
    }
}