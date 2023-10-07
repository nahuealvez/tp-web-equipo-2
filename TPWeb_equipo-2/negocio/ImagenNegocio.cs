using dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace negocio
{
    public class ImagenNegocio
    {
        public ImagenNegocio()
        {

        }

        //public List<string> GetImagenesNegocio(Articulo articulo)
        //{
        //    List<string> ListaImagenes = new List<string>();
        //    ArticuloNegocio articuloNegocio = new ArticuloNegocio();

        //    ListaImagenes = articuloNegocio.ListarImagenesPorArticulo(articulo.Codigo);

        //    return ListaImagenes;
        //}

        // REVISAR POR NICO

        /*public bool ImagenURLValida(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                byte[] imageData = webClient.DownloadData(url);
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    if (image != null)
                        return true;
                    else return false;
                }
            }
            catch (Exception ex)
            {
                return false;
                //throw ex;
            }
        }*/

        public string cargarImagen(string url)
        {
            string defaultImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic.vecteezy.com%2Fsystem%2Fresources%2Fpreviews%2F005%2F337%2F799%2Fnon_2x%2Ficon-image-not-found-free-vector.jpg&f=1&nofb=1&ipt=b1f6177c0dea54678b440945501a9969e721a2f91f76b8c9e18d8b30885fab8a&ipo=images";
            try
            {
                WebClient webClient = new WebClient();
                byte[] imageData = webClient.DownloadData(url);
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    if (image != null)
                        return url;
                    else return defaultImageUrl;
                }
            } 
            catch (Exception ex)
            {
                return defaultImageUrl;
                //return defaultImageUrl;
            }
        }

                /*if (isValidUrl)
                {
                    %>
                    <div class="row g-4">
                        <div class="col">
                            <div class="card h-100">
                                <img src = "<%: imageUrl %>" class="card-img-top" alt="...">
                                <div class="card-body">
                                    <h5 class="card-title"><%: articulo.Nombre %></h5>
                                    <p class="card-text"><%: articulo.Descripcion %></p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%
                }
                else
                {
                    string defaultImageUrl = "https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic.vecteezy.com%2Fsystem%2Fresources%2Fpreviews%2F005%2F337%2F799%2Fnon_2x%2Ficon-image-not-found-free-vector.jpg&f=1&nofb=1&ipt=b1f6177c0dea54678b440945501a9969e721a2f91f76b8c9e18d8b30885fab8a&ipo=images";
                    %>
                    <div class="row g-4">
                        <div class="col">
                            <div class="card h-100">
                                <img src = "<%: defaultImageUrl %>" class="card-img-top" alt="Imagen por defecto">
                                <div class="card-body">
                                    <h5 class="card-title"><%: articulo.Nombre %></h5>
                                    <p class="card-text"><%: articulo.Descripcion %></p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%
                }*/


    }
}
