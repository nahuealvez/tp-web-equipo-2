using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using dominio;
using negocio;

namespace TPWeb_equipo_2
{
    public partial class Default : System.Web.UI.Page
    {
        public CultureInfo idioma = new CultureInfo("es-ES"); //Se usa para convertir el precio en sistemas decimales argentino
        public ImagenNegocio imagenNegocio;
        private int IndiceImagen;
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            imagenNegocio = new ImagenNegocio();
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulo = negocio.Listar();
            
        }

        protected void AgregarAlCarritoButton_Click(object sender, EventArgs e)
        {
            ;
        }

    }
}