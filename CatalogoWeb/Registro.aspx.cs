using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using DataBase;

namespace CatalogoWeb
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResgistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                Usuarios user = new Usuarios();
                UsuariosDataBase userDatabase = new UsuariosDataBase();

                user.Email = txtEmail.Text;
                user.Password = txtPassword.Text;
                int id = userDatabase.insertarNuevo(user);
                Response.Redirect("Login.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}