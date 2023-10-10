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
            }

            /*if(Session["ListaCarrito"] == null)
            {
                ListaCarrito = new List<Articulo>();
            }
            else
            {
                ListaCarrito = Session["ListaCarrito"] as List<Articulo>;
            }*/

        }
        protected void VerDetalleButton_Click(object sender, EventArgs e)
        {
            string Id = ((Button)sender).CommandArgument;
            Response.Redirect("Detalle.aspx?ID=" + Id, false);
        }
        protected void AgregarAlCarritoButton_Click(object sender, EventArgs e)
        {   
            if(Session["ListaCarrito"] == null)
            {
                ListaCarrito = new List<Articulo>();
            }
            else
            {
                ListaCarrito = Session["ListaCarrito"] as List<Articulo>;
            }
            int Id = int.Parse(((Button)sender).CommandArgument);
            ListaCarrito.Add(ListaArticulo.Find(x =>  x.Id == Id));
            Session.Add("ListaCarrito", ListaCarrito);

        }

        protected void repRepetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Image imgProducto = e.Item.FindControl("imgProducto") as Image;

                string imageUrl = DataBinder.Eval(e.Item.DataItem, "urlimagen") as string;

                if (!string.IsNullOrEmpty(imageUrl))
                {
                    imgProducto.ImageUrl = imagenNegocio.ValidarURLImagen(imageUrl);
                    //imgProducto.ImageUrl = imageUrl;

                }
                else
                {
                    imgProducto.ImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic.vecteezy.com%2Fsystem%2Fresources%2Fpreviews%2F005%2F337%2F799%2Fnon_2x%2Ficon-image-not-found-free-vector.jpg&f=1&nofb=1&ipt=b1f6177c0dea54678b440945501a9969e721a2f91f76b8c9e18d8b30885fab8a&ipo=images"; // Cambia esto por tu imagen de reemplazo
                }
            }
        }

    }
}