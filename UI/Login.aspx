<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>Inicio de Sesión</title>
    <link href="LoginStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <img class="imgFondo" src="images\Login\hambuguesasFondo.jpg" />
        <div class="container">
            <img class="imgIconoForm" src="images\Login\hamburguesaFuego.png" alt="icono" />
            <h1>Inicio de sesión</h1>
            <h2 for="mail">Mail:</h2>
            <asp:TextBox ID="TextBoxMail" placeholder="Ingrese su mail" runat="server" OnTextChanged="TextBoxMail_TextChanged"></asp:TextBox>
            <h2 for="password">Contraseña:</h2>
            <asp:TextBox ID="TextBoxPassword" placeholder="Ingrese su contraseña" runat="server" OnTextChanged="TextBoxPassword_TextChanged" TextMode="Password"></asp:TextBox>
            <asp:Button ID="ButtonLogin" runat="server" Text="Iniciar sesión" OnClick="ButtonLogin_Click" />
            <asp:LinkButton ID="SignUP" runat="server" OnClick="SignUP_Click">¿No tienes cuenta? Registrarse</asp:LinkButton>
        </div>
    </form>
</body>
</html>
