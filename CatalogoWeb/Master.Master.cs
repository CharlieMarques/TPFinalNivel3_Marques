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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "~/Images/avatarVacio.png";
            if (!(Page is Login || Page is Registro || Page is Default || Page is Error))
            {
                if (!SeguridadSession.sessionActiva(Session["usuario"]))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
            if (SeguridadSession.sessionActiva(Session["usuario"]))
            {
                Usuarios user = (Usuarios)Session["usuario"];
                if (user.Nombre == null)
                    lblUser.Text = user.Email;
                else
                    lblUser.Text = user.Nombre;
                if(!string.IsNullOrEmpty(user.ImagenPerfil))
                {
                    string image = Server.MapPath("~/Images/" + user.ImagenPerfil);
                    if(System.IO.File.Exists(image))
                    {
                    imgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                    }
                    else
                    {
                        imgAvatar.ImageUrl = "~/Images/avatarVacio.png"; 
                    }
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}