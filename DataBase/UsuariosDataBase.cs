using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using DataBase;
using System.Net;
using System.Runtime.Remoting.Messaging;


namespace DataBase
{
    public class UsuariosDataBase
    {
        public bool Loguear(Usuarios usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("select id, email, nombre, apellido, pass, admin, urlimagenPerfil from Users where email = @email AND pass = @pass ");
                datos.setParameter("@email", usuario.Email);
                datos.setParameter("@pass", usuario.Password);
                datos.read();

                while (datos.Reader.Read())
                {
                    usuario.id = (int)datos.Reader["id"];
                    usuario.Admin = (bool)datos.Reader["admin"];
                    if (!(datos.Reader["nombre"] is DBNull))
                    {
                        usuario.Nombre = (string)datos.Reader["nombre"];
                    }
                    if (!(datos.Reader["apellido"] is DBNull))
                    {
                        usuario.Apellido = (string)datos.Reader["apellido"];
                    }
                    usuario.Email = (string)datos.Reader["email"];
                    if (!(datos.Reader["urlimagenPerfil"] is DBNull))
                    {
                        usuario.ImagenPerfil = (string)datos.Reader["urlimagenPerfil"];
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.closeConnection();
            }
        }

        public int insertarNuevo(Usuarios usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setProcedure("insertarNuevo");
                datos.setParameter("@email", usuario.Email);
                datos.setParameter("@pass", usuario.Password);
                return datos.runQueryScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.closeConnection();
            }
        }
        public void actualizar(Usuarios usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("Update USERS set urlimagenPerfil = @imagen, Nombre = @nombre, Apellido = @apellido WHERE Id = @id");
                datos.setParameter("@imagen", (object)usuario.ImagenPerfil ?? DBNull.Value);
                datos.setParameter("@nombre", usuario.Nombre);
                datos.setParameter("@apellido", usuario.Apellido);
                datos.setParameter("@id", usuario.id);
                datos.runQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.closeConnection();
            }
        }
        public bool validarUsuario(Usuarios usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("select id from USERS where Email = @email");
                datos.setParameter("@email", usuario.Email);
                datos.read();

                while (datos.Reader.Read())
                {
                    return true;
                }
                return false;


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.closeConnection();
            }


        }
    }
}
