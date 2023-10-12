using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using System.Globalization;

namespace TPWeb_equipo_2
{
    public partial class Detalle : System.Web.UI.Page
    {
        public CultureInfo idioma = new CultureInfo("es-ES"); //Se usa para convertir el precio en sistemas decimales argentino
        public Articulo ArticuloDetalle { get; set; }
        public List<Articulo> ListaCarrito { get; set; }
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!IsPostBack)
            {
                if(ListaCarrito == null)
                    ListaCarrito = new List<Articulo>();
            }*/


            if(Request.QueryString["ID"] != null) { 
                ArticuloNegocio negocio = new ArticuloNegocio();
                ListaArticulos = negocio.Listar();
            
                int id = int.Parse(Request.QueryString["ID"]);
                ArticuloDetalle = ListaArticulos.Find(x => x.Id == id);
                ListaCarrito = Session["ListaCarrito"] as List<Articulo>;
            }

        }

        protected void AgregarAlCarritoButton_Click(object sender, EventArgs e)
        {
            
            /*if (Session["ListaCarrito"] == null)
            {
                ListaCarrito = new List<Articulo>();
            }
            else
            {
                ListaCarrito = Session["ListaCarrito"] as List<Articulo>;
            }*/
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.Listar();
            int Id = int.Parse(Request.QueryString["ID"]);
            ListaCarrito.Add(ListaArticulos.Find(x => x.Id == Id));
            Session.Add("ListaCarrito", ListaCarrito);
            Session.Add("CantArtCarrito", ListaCarrito.Count);
            Response.Redirect(Request.RawUrl);
        }

        protected void EliminarDelCarritoButton_Click(Object sender, EventArgs e)
        {
            ListaCarrito = Session["ListaCarrito"] as List<Articulo>;
            int Id = int.Parse(Request.QueryString["ID"]);
            ListaCarrito.Remove(ListaCarrito.Find(x => x.Id == Id));
            Session.Add("ListaCarrito", ListaCarrito);
            Session.Add("CantArtCarrito", ListaCarrito.Count);

            Response.Redirect(Request.RawUrl);
        }
    }
}