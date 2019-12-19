using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Entidades.DataEntidades
{
    public class Consumo
    {
        public string Fecha_Consumo { get; set; }
        public decimal Numero_turno { get; set; }
        public string Numero_tarjeta { get; set; }
        public decimal Numero_comida { get; set; }
        public string DASSCO { get; set; }
        public decimal Numero_pago { get; set; }
        public string Hora { get; set; }
        public string Departamento { get; set; }
        public bool Automatico { get; set; }
        public string Numero_Lote { get; set; }
        public int Transferida { get; set; }
    }
}
