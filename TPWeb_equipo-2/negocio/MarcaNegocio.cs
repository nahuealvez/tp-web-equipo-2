using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> Listar()
        {
            List <Marca> listaMarcas = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Select Id, Descripcion From MARCAS");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Descripcion"];

                    listaMarcas.Add(aux);
                }

                return listaMarcas;

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

        public void Agregar(Marca nuevaMarca)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Insert into MARCAS(Descripcion) values(@descripcion)");
                datos.SetearParametro("@descripcion", nuevaMarca.Nombre);
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

                datos.SetearConsulta("Delete From MARCAS Where Id = @id");
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

        public void Modificar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.SetearConsulta("update MARCAS set Descripcion = @Descripcion where Id = @Id");
                datos.SetearParametro("@Descripcion", marca.Nombre);
                datos.SetearParametro("@Id", marca.Id);
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
        
        public bool ExistenRegistrosAsociados(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            List<int> lista = new List<int>();

            bool existenRegistrosAsociados = false;

            try
            {
                datos.SetearConsulta("Select IdMarca From ARTICULOS");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    int idMarca = (int)datos.Lector["IdMarca"];
                    lista.Add(idMarca);
                }

                for (int i = 0; i < lista.Count; i++)
                {
                    if (lista[i] == marca.Id)
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
