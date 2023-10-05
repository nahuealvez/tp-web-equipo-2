using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Select Id, Descripcion From Categorias");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
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
        public void Agregar(Categoria nuevaCategoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Insert into CATEGORIAS(Descripcion) values(@descripcion)");
                datos.SetearParametro("@descripcion", nuevaCategoria.Descripcion);
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

                datos.SetearConsulta("Delete From CATEGORIAS Where Id = @id");
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

        public void Modificar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.SetearConsulta("update CATEGORIAS set Descripcion = @Descripcion where Id = @Id");
                datos.SetearParametro("@Descripcion", categoria.Descripcion);
                datos.SetearParametro("@Id", categoria.Id);
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

        public bool ExistenRegistrosAsociados(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            List<int> lista = new List<int>();

            bool existenRegistrosAsociados = false;

            try
            {
                datos.SetearConsulta("Select IdCategoria From ARTICULOS");
                datos.EjecutarLectura();

                while(datos.Lector.Read())
                {
                    int idCategoria = (int)datos.Lector["IdCategoria"];
                    lista.Add(idCategoria);
                }

                for (int i = 0; i < lista.Count; i++)
                {
                    if (lista[i] == categoria.Id)
                    {
                        existenRegistrosAsociados = true;
                    }
                }

                return existenRegistrosAsociados;
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
