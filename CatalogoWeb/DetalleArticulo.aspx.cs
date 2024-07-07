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
    public partial class Detalle : System.Web.UI.Page
    {
        public List<Articulo> artDetalle {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if(id != null && !IsPostBack)
            {
                ArticuloDataBase articuloDataBase = new ArticuloDataBase();
                artDetalle = articuloDataBase.toList(id);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }
    }
}