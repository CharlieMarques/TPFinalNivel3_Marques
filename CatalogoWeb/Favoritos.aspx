<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="CatalogoWeb.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Favoritos</h1>
    <p>Aca estan todos tus articulos favoritos</p>

<div class ="row row-cols-1 row-cols-md-3 g-4">
    <asp:Repeater runat="server" ID="repRepetidorFav">
        <ItemTemplate>
            <div class="col">
                <div class="card">
                    <img src="<%#Eval("urlImagen") %>" class="card-img-top" alt="SinImagen" />
                    <div class="card-body">
                        <h5 class="card-title"><%#Eval("nombre") %> </h5>
                        <p class="card-text"><%# Eval("descripcion") %> </p>
                       <%-- <a href="DetalleArticulo.aspx?id=<%#Eval("id")%>">Ver Detalle</a>--%>
                        <%--<asp:Button Text="Ejemplo" CssClass="btn btn-primary" runat="server" ID="btnEjemplo" CommandArgument='<%#Eval("id") %>' CommandName="ArticuloId" OnClick="btnEjemplo_Click" />--%>
                        <asp:Button Text="Quitar de Favoritos" CssClass="btn btn-primary" runat="server" ID="btnQuitarFavoritos" CommandArgument='<%#Eval("Id") %>' CommandName="idArticulo" OnClick="btnQuitarFavoritos_Click"  />
                    </div>
                    

                </div>

            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
        
</asp:Content>
