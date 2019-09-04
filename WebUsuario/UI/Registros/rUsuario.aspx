<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rUsuario.aspx.cs" Inherits="WebUsuario.UI.Registros.rUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h5 class="display-4" style="font-weight: bold; background-color: #C0C0C0">Usuarios</h5>
    <div class="col-md-6 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="UsuarioId"></asp:Label>
                <asp:Button class="btn btn-outline-primary" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                <asp:TextBox class="form-control" ID="usuarioIdTextBox" type="number" Text="0" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <asp:Image ID="UsuarioImage" runat="server" Height="302px" ImageUrl="~/Imagenes/usuario.png" runat="server" Width="299px" AlternateText="Imagen no disponible" ImageAlign="right" />
    <div class="col-md-6 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label10" runat="server" Text="Fecha"></asp:Label>
                <asp:TextBox class="form-control" ID="fechaTextBox" type="date" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-6 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox class="form-control" ID="nombreTextBox" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-6 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Número de Teléfono"></asp:Label>
                <asp:TextBox class="form-control" ID="noTelefonoTextBox" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-6 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
                <asp:TextBox class="form-control" ID="emailTextBox" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-6 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="Contraseña"></asp:Label>
                <asp:TextBox class="form-control" ID="passwordTextBox" type="password" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-6 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text="Confirmar Contraseña"></asp:Label>
                <asp:TextBox class="form-control" ID="cpasswordTextBox" type="password" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-6 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label7" runat="server" Text="Tipo de Usuario"></asp:Label>
                <asp:DropDownList class="form-control" ID="tipoUsuarioDropDownList" runat="server">
                    <asp:ListItem>Administrador</asp:ListItem>
                    <asp:ListItem>Usuario</asp:ListItem>
                </asp:DropDownList>

            </div>
        </div>
    </div>

    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button class="btn btn-outline-primary" ID="nuevoButton" runat="server" Text="Nuevo" OnClick="nuevoButton_Click" />
                <asp:Button class="btn btn-outline-success" ID="guardarButton" runat="server" Text="Guardar" OnClick="guardarButton_Click" />
                <asp:Button class="btn btn-outline-danger" ID="eliminarutton" runat="server" Text="Eliminar" OnClick="eliminarutton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
