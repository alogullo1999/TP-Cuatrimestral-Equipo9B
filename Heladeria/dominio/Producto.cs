﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace dominio
{
    public class Producto
    {
        public int IdProducto { get; set; }

        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public string Descripcion { get; set; }

        public Marcas marcas { get; set; }
    }
}