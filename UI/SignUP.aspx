<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUP.aspx.cs" Inherits="SingUP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro</title>
    <link href="SignUP.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <img class="imgFondo" src="images\Login\hambuguesasFondo.jpg" />
        <div class="container">
                <h1>Registrarse</h1>
            <div class="containerRow">
                <div class="columnLeft">
                    <h2 for="mail">Mail:</h2>
                    <asp:TextBox ID="TextBoxMail" placeholder="Ingrese su mail" runat="server" OnTextChanged="TextBoxMail_TextChanged1"></asp:TextBox>
                    <h2 for="password">Contraseña:</h2>
                    <asp:TextBox ID="TextBoxPassword" placeholder="Ingrese su contraseña" runat="server" OnTextChanged="TextBoxPassword_TextChanged" TextMode="Password"></asp:TextBox>
                    <h2 for="password2">Confirmar contraseña:</h2>
                    <asp:TextBox ID="TextBoxPassword2" placeholder="Ingrese su contraseña nuevamente" runat="server" OnTextChanged="TextBoxPassword2_TextChanged" TextMode="Password"></asp:TextBox>
                </div>
                <div class="columnRight">
                    <h2 for="telefono">Telefono:</h2>
                    <asp:TextBox ID="TextBoxPhone" placeholder="Ingrese su telefono" runat="server" OnTextChanged="TextBoxPhone_TextChanged"></asp:TextBox>
                    <h2 for="direccion">Dirección:</h2>
                    <asp:TextBox ID="TextBoxAdress" placeholder="Ingrese su direcci[on" runat="server" OnTextChanged="TextBoxAdress_TextChanged"></asp:TextBox>

                </div>
            </div>
            <asp:Button ID="ButtonSignUp" runat="server" Text="Button" OnClick="ButtonSignUp_Click" />
        </div>
    </form>
</body>
</html>
