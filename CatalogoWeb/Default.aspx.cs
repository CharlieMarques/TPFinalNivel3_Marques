using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBase;
using Dominio;
using Seguridad;

namespace CatalogoWeb
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloDataBase articulo = new ArticuloDataBase();
            ListaArticulo = articulo.toList();
            if(!IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulo;
                repRepetidor.DataBind();
            }
        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }

        protected void btnFavoritos_Click(object sender, EventArgs e)
        {
            int articuloId = int.Parse(((Button)sender).CommandArgument);
            AccesoDatos datos = new AccesoDatos();
            try
            {
            UsuariosDataBase userData = new UsuariosDataBase();
            ArticuloFavoritoDataBase articuloFavoritoDataBase = new ArticuloFavoritoDataBase();
            ArticuloFavorito artFav= new ArticuloFavorito();
            Usuarios user = new Usuarios();
                if (SeguridadSession.sessionActiva(Session["usuario"]))
                {
                    user = (Usuarios)Session["usuario"];
                    artFav.IdUsers = user.id;
                    artFav.IdArticulo = articuloId;
                    articuloFavoritoDataBase.insertarFavorito(artFav);
                }
                else
                {
                    Session.Add("Error", "Debe Ingresar para poder guardar en favoritos");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}