using DataBase;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CatalogoWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            UsuariosDataBase userDataBase = new UsuariosDataBase();
            try
            {
                usuario.Email = txtEmail.Text;
                usuario.Password = txtPassword.Text;
                if (userDataBase.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("LoginPrueba.aspx", false);
                }
                else
                {
                    Session.Add("Error", "Usuario o contraseña incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
                
            }
        }
    }
}