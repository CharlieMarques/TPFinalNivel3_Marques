<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="CatalogoWeb.ListaArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista Articulos</h1>

    <asp:GridView ID="dgvArticulos" runat="server" DataKeyNames="Id" CssClass="table" AutoGenerateColumns="false"
        OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="true" PageSize="5" PageIndex="0">
        <Columns>
            <asp:BoundField HeaderText="Codigo de Articulo" DataField="codArticulo" />
            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.descripcion" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="precio" />
            <asp:BoundField HeaderText="Descripcion" DataField="descripcion" />
            <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true" SelectText="Modificar" />

        </Columns>

    </asp:GridView>
    <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
