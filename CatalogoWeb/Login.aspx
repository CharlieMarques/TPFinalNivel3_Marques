<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CatalogoWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <div class="col-4">
        <h2>Login</h2>
        <div class="mb-3">
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox  TextMode="Email" runat="server"  CssClass="form-control" ID="txtEmail" placeholder="example@email.com"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Password</label>
            <asp:TextBox runat="server" cssclass="form-control" ID="txtPassword" placeholder="********" TextMode="Password"/>
        </div>
        <asp:Button Text="Ingresar" cssclass="btn btn-primary" ID="btnLogin" OnClick="btnLogin_Click" runat="server" />
        <a href="/">Cancelar</a>

    </div>
</div>
</asp:Content>
