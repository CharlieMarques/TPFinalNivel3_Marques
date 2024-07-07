using DataBase;
using Dominio;
using Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            ArticuloFavoritoDataBase artDb = new ArticuloFavoritoDataBase();
            Usuarios user = new Usuarios();
            if (SeguridadSession.sessionActiva(Session["usuario"]))
            {
                user = (Usuarios)Session["usuario"];
            }           
            listaArticulos = artDb.toList(user.id);
            if(!IsPostBack)
            {
                repRepetidorFav.DataSource = listaArticulos;
                repRepetidorFav.DataBind();
            }
        }

        protected void btnQuitarFavoritos_Click(object sender, EventArgs e)
        {
            int articuloId = int.Parse(((Button)sender).CommandArgument);
            ArticuloDataBase artDb = new ArticuloDataBase();
            ArticuloFavoritoDataBase artFavDB = new ArticuloFavoritoDataBase();
            Usuarios user = new Usuarios();
            try
            {
                if (SeguridadSession.sessionActiva(Session["usuario"]))
                {
                user = (Usuarios)Session["usuario"];
                }
                artFavDB.EliminarFavorito(articuloId,user.id);
                Response.Redirect("Favoritos.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("Error",ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}