using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Seguridad;


namespace DataBase
{
   public class ArticuloFavoritoDataBase
    {
        
		public List<Articulo>toList(int idUser)
		{
			List<Articulo>list = new List<Articulo>();
			AccesoDatos data = new AccesoDatos();
            //int idUser = SeguridadSession.sessionActiva(Session["usuario"])
            //Usuarios user = 

            try
			{
                //string query = "Select A.Id, A.Codigo, A.Nombre,A.Descripcion,Precio, C.Descripcion Categoria, M.Descripcion Marca, A.ImagenUrl, A.IdCategoria, A.IdMarca From ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdCategoria = C.Id and A.IdMarca = M.Id ";
                //string query = "select A.Id,A.Nombre,A.Descripcion,Precio, C.Descripcion Categoria, M.Descripcion Marca, A.ImagenUrl, A.IdCategoria, A.IdMarca, F.IdUsers from FAVORITOS F, ARTICULOS A, MARCAS M, CATEGORIAS C where f.IdUsers=@idUser and F.IdArticulo = A.Id and A.IdCategoria = C.Id and A.IdMarca = M.Id ";
                data.setQuery("select A.Id,A.Nombre,A.Descripcion,Precio, C.Descripcion Categoria, M.Descripcion Marca, A.ImagenUrl, A.IdCategoria, A.IdMarca, F.IdUsers from FAVORITOS F, ARTICULOS A, MARCAS M, CATEGORIAS C where f.IdUsers=@idUser and F.IdArticulo = A.Id and A.IdCategoria = C.Id and A.IdMarca = M.Id ");
                data.setParameter("@idUser", idUser);
                data.read();
                while (data.Reader.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)data.Reader["Id"];
                   // aux.codArticulo = (string)data.Reader["Codigo"];
                    aux.descripcion = (string)data.Reader["Descripcion"];
                    aux.nombre = (string)data.Reader["Nombre"];
                    aux.urlImagen = (string)data.Reader["ImagenUrl"];
                    aux.Precio = decimal.Parse(data.Reader["Precio"].ToString());
                    aux.categoria = new Categoria();
                    aux.categoria.Id = (int)data.Reader["IdCategoria"];
                    aux.categoria.Descripcion = (string)data.Reader["Categoria"];
                    aux.marca = new Marca();
                    aux.marca.Id = (int)data.Reader["IdMarca"];
                    aux.marca.Descripcion = (string)data.Reader["Marca"];
                    list.Add(aux);
                }
                return list;
            }
			catch (Exception ex)
			{

				throw ex;
			}
		}
        public void insertarFavorito(ArticuloFavorito art)
        {
            AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setQuery("Insert into FAVORITOS (IdUsers, IdArticulo) VALUES (@idUser, @idArticulo)");
				datos.setParameter("@idUser", art.IdUsers);
				datos.setParameter("@idArticulo", art.IdArticulo);
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
        public int ObtenerIdUser(int idUser)
        {
            
            int id = idUser;
            return id;
        }
        public void EliminarFavorito(int idArt, int idUser)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setQuery("Delete from FAVORITOS Where idArticulo = @idArt and idUsers = @idUser");
                datos.setParameter("idArt", idArt);
                datos.setParameter("@idUser", idUser);
                datos.runQuery() ;
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
