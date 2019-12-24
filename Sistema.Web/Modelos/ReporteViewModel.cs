using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Modelos
{
    public class ReporteViewModel
    {
        public int Id { get; set; }
        public string Numero_tarjeta { get; set; }
        public string Nombre { get; set; }
        public string CentroCosto { get; set; }
        public decimal Numero_turno { get; set; }
        public string Fecha_Consumo { get; set; }
        public string Hora { get; set; }
    }
}
