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

            foreach(RepeaterItem item in repRepetidor.Items)
            {
                int Id = int.Parse((item.FindControl("btnAgregarAlCarrito") as Button).CommandArgument.ToString());
                Button btnAgregarAlCarrito = (Button)item.FindControl("btnAgregarAlCarrito");
                Button btnEliminarDelCarrito = (Button)item.FindControl("btnEliminarDelCarrito");
                if (ListaCarrito.Exists(x => x.Id == Id))
                {
                    btnAgregarAlCarrito.Visible = false;
                    btnEliminarDelCarrito.Visible = true;
                }
            }

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

        protected void EliminarDelCarritoButton_Click(object sender, EventArgs e)
        {
            int Id = int.Parse(((Button)sender).CommandArgument);
            ListaCarrito.Remove(ListaCarrito.Find(x => x.Id == Id));
            Session.Add("ListaCarrito", ListaCarrito);
            Session.Add("CantArtCarrito", ListaCarrito.Count);
            Response.Redirect(Request.RawUrl);

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBusqueda.Text.Trim().ToLower();

            List<Articulo> productosFiltrados = ListaArticulo.Where(producto => producto.Nombre.ToLower().Contains(busqueda)).ToList();

            repRepetidor.DataSource = productosFiltrados;
            repRepetidor.DataBind();
        }

    }
}