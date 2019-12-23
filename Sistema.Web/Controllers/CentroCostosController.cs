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
    public class CentroCostosController : ControllerBase
    {
        private readonly DbContextAccesos _context;

        public CentroCostosController(DbContextAccesos context)
        {
            _context = context;
        }

        // GET: api/CentroCostos/listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<CentroCostosViewModel>> Listar()
        {
            var centro = await _context.CentroCostos.ToListAsync();

            return centro.Select(c => new CentroCostosViewModel
            {
                Id = c.Id,
                Codigo = c.Codigo,
                Descripcion = c.Descripcion,
                BColor = c.BColor,
                FColor = c.FColor,
                PropiCat = c.PropiCat,
                Responsable = c.Responsable,
                Precio = c.Precio
            });
        }

        private bool CentroCostoExists(int id)
        {
            return _context.CentroCostos.Any(e => e.Id == id);
        }
    }
}