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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    if (SeguridadSession.sessionActiva(Session["usuario"]))
                    {
                        Usuarios user = (Usuarios)Session["usuario"];
                        
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        if (!string.IsNullOrEmpty(user.ImagenPerfil))
                        {

                            string image = Server.MapPath("~/Images/" + user.ImagenPerfil);
                            if (System.IO.File.Exists(image))
                            {
                                imgNuevoPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                            }
                            else
                            {
                                imgNuevoPerfil.ImageUrl = "~/Images/avatarVacio.png";
                            }                         
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                UsuariosDataBase userDB = new UsuariosDataBase();
                string ruta = Server.MapPath("./Images/");
                Usuarios user = (Usuarios)Session["usuario"];
                if (txtImagen.PostedFile.FileName != "")
                {
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.id + ".jpg");
                }
                if(string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtNombre.Text))
                {
                    Session.Add("Error", "Los campos Nombre y Apellido no pueden quedar vacios");
                    Response.Redirect("Error.aspx", false);
                }
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.ImagenPerfil = "perfil-" + user.id + ".jpg";
                userDB.actualizar(user);
                Image img = (Image)Master.FindControl("imgAvatar");
                img.ImageUrl = "~/Images/" + user.ImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();                            
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            
        }
    }
}