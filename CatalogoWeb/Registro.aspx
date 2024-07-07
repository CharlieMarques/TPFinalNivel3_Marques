<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="CatalogoWeb.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
    <div class="col-4">
        <h2>Crea tu perfil</h2>
        <div class="mb-3">
            <label class="form-label">Email</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" placeholder="example@email.com"></asp:TextBox>
            <asp:RegularExpressionValidator ErrorMessage="Ingrese un email valido" ControlToValidate="txtEmail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
        </div>
        <div class="mb-3">
            <label class="form-label">Password</label>
            <asp:TextBox runat="server" cssclass="form-control" ID="txtPassword" placeholder="********" TextMode="Password"/>
        </div>
        <asp:Button Text="Registrarse" cssclass="btn btn-primary" ID="btnResgistrarse" OnClick="btnResgistrarse_Click" runat="server" />
        <a href="/">Cancelar</a>

    </div>
</div>
</asp:Content>
