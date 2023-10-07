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

        public bool ImagenURLValida(string url)
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
        }


    }
}
