using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.DataEntidades;
using Sistema.Web.Modelos;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistPersos1Controller : ControllerBase
    {
        private readonly DbContextSistema _context;

        public HistPersos1Controller(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/HistPersos1/listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<HistPerso1ViewModel>> Listar()
        {
            var consumo = await _context.HistPerso1s.ToListAsync();

            return consumo.Select(c => new HistPerso1ViewModel
            {
                ZAUSW = c.ZAUSW,
                ZAUVE = c.ZAUVE,
                ZANBE = c.ZANBE,
                PERNR = c.PERNR,
                ENAME = c.ENAME,
                INFO1 = c.INFO1,
                INFOA = c.INFOA,
                IMAIL = c.IMAIL,
                FECALTA = c.FECALTA,
                FECBAJA = c.FECBAJA
            });
        }

        // GET: api/HistPerso1
        [HttpGet]
        public IEnumerable<HistPerso1> GetHistPerso1s()
        {
            return _context.HistPerso1s;
        }

        // GET: api/HistPerso1/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistPerso1([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var histPerso1 = await _context.HistPerso1s.FindAsync(id);

            if (histPerso1 == null)
            {
                return NotFound();
            }

            return Ok(histPerso1);
        }

        // PUT: api/HistPerso1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistPerso1([FromRoute] string id, [FromBody] HistPerso1 histPerso1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != histPerso1.ZAUSW)
            {
                return BadRequest();
            }

            _context.Entry(histPerso1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistPerso1Exists(id))
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

        // POST: api/HistPerso1
        [HttpPost]
        public async Task<IActionResult> PostHistPerso1([FromBody] HistPerso1 histPerso1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.HistPerso1s.Add(histPerso1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistPerso1", new { id = histPerso1.ZAUSW }, histPerso1);
        }

        // DELETE: api/HistPerso1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistPerso1([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var histPerso1 = await _context.HistPerso1s.FindAsync(id);
            if (histPerso1 == null)
            {
                return NotFound();
            }

            _context.HistPerso1s.Remove(histPerso1);
            await _context.SaveChangesAsync();

            return Ok(histPerso1);
        }

        private bool HistPerso1Exists(string id)
        {
            return _context.HistPerso1s.Any(e => e.ZAUSW == id);
        }
    }
}