<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CatalogoWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Bienvenido a tu catalogo de tecnologia</h1>
    <p>Estos son todos nuestros productos en stock</p>

    <div class ="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("urlImagen") %>" class="card-img-top" alt="SinImagen" />
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("nombre") %> </h5>
                            <p class="card-text"><%# Eval("descripcion") %> </p>
                            <a href="DetalleArticulo.aspx?id=<%#Eval("id")%>">Ver Detalle</a>
                            <%if (Seguridad.SeguridadSession.sessionActiva(Session["usuario"]))
                                { %>                           
                            <asp:Button Text="Agregar a Favoritos" CssClass="btn btn-primary" runat="server" ID="btnFavoritos" CommandArgument='<%#Eval("Id") %>' CommandName="idArticulo" OnClick="btnFavoritos_Click"  />
                            <%} %>
                        </div>                       
                    </div>

                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
