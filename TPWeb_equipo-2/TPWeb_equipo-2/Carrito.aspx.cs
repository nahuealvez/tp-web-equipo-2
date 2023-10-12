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
        public List<Articulo> ListaCarrito { get; set; }
        public ImagenNegocio imagenNegocio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ListaCarrito"] == null)
            {
                ListaCarrito = new List<Articulo>();
            }
            else
            {
                ListaCarrito = Session["ListaCarrito"] as List<Articulo>;
            }

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaCarrito;
                repRepetidor.DataBind();
            }

        }

        protected void VerDetalleButton_Click(object sender, EventArgs e)
        {
            string Id = ((Button)sender).CommandArgument;
            Response.Redirect("Detalle.aspx?ID=" + Id, false);
        }
        protected void EliminarDelCarritoButton_Click(object sender, EventArgs e)
        {
            ListaCarrito = Session["ListaCarrito"] as List<Articulo>;
            int Id = int.Parse(((Button)sender).CommandArgument);
            ListaCarrito.Remove(ListaCarrito.Find(x => x.Id == Id));
            Session.Add("ListaCarrito", ListaCarrito);

            Response.Redirect(Request.RawUrl);

        }
    }
}