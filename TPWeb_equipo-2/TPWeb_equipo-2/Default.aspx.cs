using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPWeb_equipo_2
{
    public partial class Default : System.Web.UI.Page
    {
        private ImagenNegocio imagenNegocio;
        private List<string> UrlImagenesArticulo;
        private int IndiceImagen;
        public Articulo articulo;
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulo = negocio.Listar();
        }

        private void CargarImagen()
        {
            UrlImagenesArticulo = imagenNegocio.GetImagenesNegocio(Articulo);
            imagenNegocio.CargarImagenDesdeURL(UrlImagenesArticulo[IndiceImagen]);
        }
    }
}