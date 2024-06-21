using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using System.Diagnostics.Eventing.Reader;
using Microsoft.SqlServer.Server;

namespace CatalogoWeb
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public bool confirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloDataBase articulo = new ArticuloDataBase();
            MarcaDataBase marcaData = new MarcaDataBase();
            CategoriaDataBase categoriaDataBase = new CategoriaDataBase();
            try
            {
                txtId.Enabled = false;
                confirmaEliminacion = false;
                if (!IsPostBack)
                {
                    List<Articulo> listaArticulo = articulo.toList();
                    Session["listaMarca"] = marcaData.toList();
                    List<Marca> listaMarcas = marcaData.toList();
                    List<Categoria> listaCategorias = categoriaDataBase.toList();
                    ddlMarca.DataSource = listaMarcas;
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();
                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();
                }
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";


                if (id != "" && !IsPostBack)
                {
                    ArticuloDataBase artNego = new ArticuloDataBase();
                    Articulo seleccionado = (artNego.toList(id))[0];
                    Session.Add("ArticuloSeleccionado", seleccionado);
                    txtId.Text = id;
                    txtCodArticulo.Text = seleccionado.codArticulo;
                    txtNombre.Text = seleccionado.nombre;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtDescripcion.Text = seleccionado.descripcion;
                    txtImagenUrl.Text = seleccionado.urlImagen;

                    ddlMarca.SelectedValue = seleccionado.marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.categoria.Id.ToString();
                    txtImagenUrl_TextChanged(sender, e);


                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo articuloNuevo = new Articulo();
                ArticuloDataBase artNego = new ArticuloDataBase();
                articuloNuevo.codArticulo = txtCodArticulo.Text;
                articuloNuevo.nombre = txtNombre.Text;
                articuloNuevo.descripcion = txtDescripcion.Text;
                articuloNuevo.Precio = decimal.Parse(txtPrecio.Text);
                articuloNuevo.urlImagen = txtImagenUrl.Text;

                articuloNuevo.marca = new Marca();
                articuloNuevo.categoria = new Categoria();
                articuloNuevo.marca.Id = int.Parse(ddlMarca.SelectedValue);
                articuloNuevo.categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    articuloNuevo.Id = int.Parse(txtId.Text);
                    artNego.modificarConSP(articuloNuevo);
                    Response.Redirect("ListaArticulos.aspx");
                }
                else
                {
                    artNego.agregarConSP(articuloNuevo);
                    Response.Redirect("ListaArticulos.aspx");
                }


            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    ArticuloDataBase artNego = new ArticuloDataBase();
                    artNego.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ListaArticulos.aspx");
                }

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);

            }


        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmaEliminacion = true;
        }
    }
}