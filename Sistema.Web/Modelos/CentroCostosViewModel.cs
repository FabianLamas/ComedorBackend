﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Modelos
{
    public class CentroCostosViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int BColor { get; set; }
        public int FColor { get; set; }
        public int PropiCat { get; set; }
        public string Responsable { get; set; }
        public int Precio { get; set; }
    }
}