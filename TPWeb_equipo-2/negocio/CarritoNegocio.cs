using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    internal class CarritoNegocio
    {
        public List<Articulo> ListaArticulosCarrito { get; set; }
        public CarritoNegocio(List<Articulo> ListaArticulos)
        {
            ;
        }
    }
}
