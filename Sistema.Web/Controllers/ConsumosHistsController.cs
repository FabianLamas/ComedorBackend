using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class ConsumosHistsController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ConsumosHistsController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/ConsumosHists/listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ConsumoHistsViewModel>> Listar()
        {
            var consumo = await _context.ConsumosHists.ToListAsync();

            return consumo.Select(c => new ConsumoHistsViewModel {
                Id = c.Id,
                Fecha_Consumo = c.Fecha_consumo,
                Numero_turno = c.Numero_turno,
                Numero_tarjeta = c.Numero_tarjeta,
                Numero_comida = c.Numero_comida,
                DASSCO = c.DASSCO,
                Numero_pago = c.Numero_pago,
                Hora = c.Hora,
                Departamento = c.Departamento,
                Automatico = c.Automatico,
                Numero_Lote = c.Numero_Lote,
                Legajo = c.Legajo,
                Nombre = c.Nombre,
                CentroCosto = c.CentroCosto,
                EsVisita = c.EsVisita              
            });
        }

        // GET: api//ConsumosHists/buscarConsumos/desde/hasta/centro
        [HttpGet("[action]/{desde}/{hasta}/{centro?}")]
        public async Task<IEnumerable<ReporteViewModel>> BuscarConsumos([FromRoute] string desde, [FromRoute] string hasta, [FromRoute] string centro)
        {

            DateTime _desde = DateTime.ParseExact(desde, "yyyyMMdd", CultureInfo.InvariantCulture);
            DateTime _hasta = DateTime.ParseExact(hasta, "yyyyMMdd", CultureInfo.InvariantCulture);

            var consumo = await _context.ConsumosHists.ToListAsync();

            if (centro is null)
            {
                consumo = await _context.ConsumosHists.Where(c =>
                (DateTime.ParseExact(c.Fecha_consumo, "yyyyMMdd", CultureInfo.InvariantCulture) > _desde)
                && (DateTime.ParseExact(c.Fecha_consumo, "yyyyMMdd", CultureInfo.InvariantCulture) < _hasta) && (DateTime.ParseExact(c.Fecha_consumo, "yyyyMMdd", CultureInfo.InvariantCulture) < _hasta)).ToListAsync();
            }else
            {
                consumo = await _context.ConsumosHists.Where(c =>
                (DateTime.ParseExact(c.Fecha_consumo, "yyyyMMdd", CultureInfo.InvariantCulture) > _desde)
                && (DateTime.ParseExact(c.Fecha_consumo, "yyyyMMdd", CultureInfo.InvariantCulture) < _hasta) && (c.CentroCosto == centro)).ToListAsync();
            }
            

            return consumo.Select(c => new ReporteViewModel
            {
                Id = c.Id,
                Numero_tarjeta = c.Numero_tarjeta,
                Nombre = c.Nombre,
                CentroCosto = c.CentroCosto,
                Numero_turno = c.Numero_turno,
                Fecha_Consumo = c.Fecha_consumo,
                Hora = c.Hora
            });
        }

        private bool ConsumoHistExists(int id)
        {
            return _context.ConsumosHists.Any(e => e.Id == id);
        }
    }
}