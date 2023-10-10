using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWeb_equipo_2
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public void contadorElementosCarrito(int cantidad)
        {
            string cantidadElementos = cantidad.ToString();
            
            CantidadElementosCarrito.Text = cantidadElementos;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}