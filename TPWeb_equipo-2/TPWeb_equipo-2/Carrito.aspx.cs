using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPWeb_equipo_2
{
    public partial class Carrito : System.Web.UI.Page
    {
        public CultureInfo idioma = new CultureInfo("es-ES"); //Se usa para convertir el precio en sistemas decimales argentino
        public List<Articulo> ListaArticulosCarrito { get; set; }
        public ImagenNegocio imagenNegocio;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}