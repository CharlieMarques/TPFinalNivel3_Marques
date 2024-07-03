﻿using System;
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
            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
            if (!(Page is Login || Page is Registro || Page is Default || Page is Error))
            {
                if (!SeguridadSession.sessionActiva(Session["usuario"]))
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    Usuarios user = (Usuarios)Session["usuario"];
                    if(user.Nombre == null)
                    {
                        lblUser.Text = user.Email;
                    }
                    else lblUser.Text = user.Nombre;
                    
                }
            }
            if (SeguridadSession.sessionActiva(Session["usuario"]))
            {
                imgAvatar.ImageUrl = "~/Images/" + ((Usuarios)Session["usuario"]).ImagenPerfil;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}