using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace TPWeb_equipo_2
{
    public partial class Detalle : System.Web.UI.Page
    {
        public Articulo ArticuloDetalle { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> listaArticulos = new List<Articulo>();
            listaArticulos = negocio.Listar();
            
            int id = int.Parse(Request.QueryString["ID"]);
            ArticuloDetalle = listaArticulos.Find(x => x.Id == id);

        }

        protected void AgregarAlCarritoButton_Click(object sender, EventArgs e)
        {
            ;
        }
    }
}