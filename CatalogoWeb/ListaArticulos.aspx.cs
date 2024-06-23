using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBase;
using Dominio;

namespace CatalogoWeb
{
    public partial class ListaArticulos : System.Web.UI.Page
    {
        public bool filtroAvanzado { get;set;}
        protected void Page_Load(object sender, EventArgs e)
        {
            filtroAvanzado = false;
            ArticuloDataBase articulo = new ArticuloDataBase();
            Session.Add("listaArticulo", articulo.toList());
            dgvArticulos.DataSource = Session["listaArticulo"];
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            filtroAvanzado =chkAvanzado.Checked;
            txtfiltro.Enabled = !filtroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            
            if(ddlCampo.SelectedItem.ToString()=="Precio")
            {
                ddlCriterio.Items.Add("Hasta");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloDataBase articulo = new ArticuloDataBase();
                dgvArticulos.DataSource = articulo.filtrar(
                    ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltroAvanzado.Text);
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                throw;
            }

        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulo"];
            List<Articulo> listaFiltada = lista.FindAll(x => x.nombre.ToUpper().Contains(txtfiltro.Text.ToUpper()));
            dgvArticulos.DataSource = listaFiltada;
            dgvArticulos.DataBind();
        }
    }
}