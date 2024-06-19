<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="CatalogoWeb.FormularioArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <div class="col-6">
        <div class="mb-3">
            <label for="txtId" class="form-label">Id: </label>
            <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label for="txtNumero" class="form-label">Nombre: </label>
            <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label for="txtDescripcion" class="form-label">Descripcion: </label>
            <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label for="ddlMarca" class="form-label">Marca: </label>
            <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label for="ddlCategoria" class="form-label">Categoria: </label>
            <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
            <a href="ListaArticulos.aspx">Cancelar</a>

        </div>
    </div>
</div>
</asp:Content>
