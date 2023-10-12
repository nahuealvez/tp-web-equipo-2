using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using dominio;
using negocio;
using System.Web.UI.HtmlControls;

namespace TPWeb_equipo_2
{
    public partial class Default : System.Web.UI.Page
    {
        public ImagenNegocio imagenNegocio;
        private int IndiceImagen;
        public List<Articulo> ListaArticulo { get; set; }
        public List<Articulo> ListaCarrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            imagenNegocio = new ImagenNegocio();
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulo = negocio.Listar();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulo;
                repRepetidor.DataBind();
                if (Session["ListaCarrito"] == null)
                {
                    ListaCarrito = new List<Articulo>();
                    Session.Add("ListaCarrito", ListaCarrito);
                }
                else
                {
                    ListaCarrito = Session["ListaCarrito"] as List<Articulo>;
                }

            }
            ListaCarrito = Session["ListaCarrito"] as List<Articulo>;

        }
        protected void VerDetalleButton_Click(object sender, EventArgs e)
        {
            string Id = ((Button)sender).CommandArgument;
            Response.Redirect("Detalle.aspx?ID=" + Id, false);
        }
        protected void AgregarAlCarritoButton_Click(object sender, EventArgs e)
        {   
            /*if(Session["ListaCarrito"] == null)
            {
                ListaCarrito = new List<Articulo>();
            }
            else
            {
                ListaCarrito = Session["ListaCarrito"] as List<Articulo>;
            }*/
            int Id = int.Parse(((Button)sender).CommandArgument);
            ListaCarrito.Add(ListaArticulo.Find(x =>  x.Id == Id));
            Session.Add("ListaCarrito", ListaCarrito);
            Session.Add("CantArtCarrito", ListaCarrito.Count);
            Response.Redirect(Request.RawUrl);

        }
    }
}