using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace CatalogoWeb
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloDataBase articulo = new ArticuloDataBase();
            MarcaDataBase marcaData = new MarcaDataBase();
            CategoriaDataBase categoriaDataBase = new CategoriaDataBase();
            try
            {
                if(!IsPostBack)
                {
                    List<Articulo> listaArticulo = articulo.toList();
                    Session["listaMarca"] = marcaData.toList();
                    List<Marca> listaMarcas = marcaData.toList();
                    List<Categoria>listaCategorias = categoriaDataBase.toList();
                    ddlMarca.DataSource = listaMarcas;
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();
                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}