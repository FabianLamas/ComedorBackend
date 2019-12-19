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
    public class ConsumosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ConsumosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Consumos/listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ConsumoViewModel>> Listar()
        {
            var consumo = await _context.Consumos.ToListAsync();

            return consumo.Select(c => new ConsumoViewModel {
                Fecha_Consumo = c.Fecha_Consumo,
                Numero_turno = c.Numero_turno,
                Numero_tarjeta = c.Numero_tarjeta,
                Numero_comida = c.Numero_comida,
                DASSCO = c.DASSCO,
                Numero_pago = c.Numero_pago,
                Hora = c.Hora,
                Departamento = c.Departamento,
                Automatico = c.Automatico,
                Numero_Lote = c.Numero_Lote,
                Transferida = c.Transferida
            });
        }



        private bool ConsumoExists(string id)
        {
            return _context.Consumos.Any(e => e.Fecha_Consumo == id);
        }
    }
}