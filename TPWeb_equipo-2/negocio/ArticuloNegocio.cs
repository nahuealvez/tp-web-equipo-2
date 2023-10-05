using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //datos.SetearConsulta("Select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion As Marca, IsNull (C.Descripcion, 'Sin categorizar') As Categoria, A.Precio\r\nFrom ARTICULOS As A\r\nLeft Join MARCAS As M\r\n\tOn A.IdMarca = M.Id\r\nLeft Join CATEGORIAS As C\r\n\tOn A.IdCategoria = C.Id");
                datos.SetearConsulta("Select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion As Marca, IsNull (C.Descripcion, 'Sin categorizar') As Categoria, A.Precio As Precio \r\nFrom ARTICULOS As A \r\n\tLeft Join MARCAS As M On A.IdMarca = M.Id \r\n\tLeft Join CATEGORIAS As C On A.IdCategoria = C.Id");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Nombre = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<string> ListarImagenesPorArticulo(string cod)
        {
            List<string> listaImagenes = new List<string>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select i.ImagenUrl from IMAGENES I join ARTICULOS A on A.Id = I.IdArticulo where A.Codigo = @CodArticulo");
                datos.SetearParametro("@CodArticulo", cod);

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];

                    if(aux.UrlImagen !=  null)
                        listaImagenes.Add(aux.UrlImagen);

                }

                return listaImagenes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Agregar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Insert into ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) Values(@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");
                datos.SetearParametro("@Codigo", articulo.Codigo);
                datos.SetearParametro("@Nombre", articulo.Nombre);
                datos.SetearParametro("@Descripcion", articulo.Descripcion);
                datos.SetearParametro("@IdMarca", articulo.Marca.Id);
                datos.SetearParametro("@IdCategoria", articulo.Categoria.Id);
                datos.SetearParametro("@Precio", articulo.Precio);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("delete from ARTICULOS WHERE Id=@id");
                datos.SetearParametro("@id", id);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
