<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="CatalogoWeb.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3>Detalle Articulo</h3>

        <div class="row">
            <%if (Seguridad.SeguridadSession.sessionActiva(Session["usuario"]))
                {
                    foreach (Dominio.Articulo articulo in artDetalle)
                    { %>
            <div class="col-6">
                <div class="mb-3">
                    <div class="card">
                        <img src="<%: articulo.urlImagen %>" class="card-img-top imgDetalle mx-auto d-block" alt=".." />
                        <div class="card-body">
                            <h5 class="card-title"><%: articulo.nombre %></h5>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <div class="card">
                        <div class="card-body">
                            <p class="card-text">Código: <%: articulo.codArticulo %></p>
                            <p class="card-text">Descripcion: <%: articulo.descripcion %></p>
                            <p class="card-text">Marca: <%: articulo.marca.Descripcion %></p>
                            <p class="card-text">Categoria: <%: articulo.categoria.Descripcion %></p>
                            <p class="card-text">Precio: $<%: articulo.Precio %></p>
                        </div>
                    </div>
                </div>
            </div>

            <%}
            }%>
        </div>
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <asp:Button ID="btnVolver" CssClass="btn btn-primary" OnClick="btnVolver_Click" runat="server" Text="Volver" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
