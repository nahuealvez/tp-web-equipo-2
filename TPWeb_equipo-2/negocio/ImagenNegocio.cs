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
        public PictureBox PictureBox { get; set; }

        public ImagenNegocio(PictureBox pictureBox)
        {
            PictureBox = pictureBox;
        }

        public List<string> GetImagenesNegocio(Articulo articulo)
        {
            List<string> ListaImagenes = new List<string>();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            ListaImagenes = articuloNegocio.ListarImagenesPorArticulo(articulo.Codigo);

            return ListaImagenes;
        }

        public void CargarImagenDesdeURL(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                byte[] imageData = webClient.DownloadData(url);
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image image = Image.FromStream(ms);
                    if (image != null)
                        PictureBox.Image = image;
                    else PictureBox.Load("https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic.vecteezy.com%2Fsystem%2Fresources%2Fpreviews%2F005%2F337%2F799%2Fnon_2x%2Ficon-image-not-found-free-vector.jpg&f=1&nofb=1&ipt=b1f6177c0dea54678b440945501a9969e721a2f91f76b8c9e18d8b30885fab8a&ipo=images");
                }
            }
            catch (Exception ex)
            {
                PictureBox.Load("https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fstatic.vecteezy.com%2Fsystem%2Fresources%2Fpreviews%2F005%2F337%2F799%2Fnon_2x%2Ficon-image-not-found-free-vector.jpg&f=1&nofb=1&ipt=b1f6177c0dea54678b440945501a9969e721a2f91f76b8c9e18d8b30885fab8a&ipo=images");
                //throw ex;
            }
        }


    }
}
