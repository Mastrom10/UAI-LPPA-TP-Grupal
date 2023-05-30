using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;
using BLL;
using SERVICIOS;

public partial class Login2 : System.Web.UI.Page
{
    string Mail;
    string Password;
    BLL_Usuario _BLL_Usuario;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        try
        {
            LoginResult result = LoginResult.InvalidUsername;
            BE_Usuario _oUsuario = new BE_Usuario();
            _BLL_Usuario = new BLL_Usuario();
            _oUsuario.Email = TextBoxMail.Text;
            _oUsuario.Contrasena = TextBoxPassword.Text;

            if (_BLL_Usuario.Login(_oUsuario) == LoginResult.ValidUser)
            {
                result = LoginResult.ValidUser;
                Session["Usuario"] = _oUsuario;
                Response.Redirect("Home.aspx");
            }
            if (_BLL_Usuario.Login(_oUsuario) == LoginResult.InvalidStatus)
            {
                result = LoginResult.InvalidStatus;
            }
            if (_BLL_Usuario.Login(_oUsuario) == LoginResult.InvalidPassword)
            {
                result = LoginResult.InvalidPassword;
            }

            switch (result)
            {
                case LoginResult.InvalidStatus:
                    Response.Write("<script>alert('Su usuario se encuentra deshabilitado');</script>");
                    break;
                case LoginResult.InvalidPassword:
                    Response.Write("<script>alert('usuario o contraseña incorrectos');</script>");
                    break;
                case LoginResult.ValidUser:
                    Response.Redirect("Home.aspx");
                    break;
            }

        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
        }   
    }

    protected void TextBoxMail_TextChanged(object sender, EventArgs e)
    {
        if(TextBoxMail.Text != "") //agregar regex para validar mail
        {
            Mail = TextBoxMail.Text;
        }
    }

    protected void TextBoxPassword_TextChanged(object sender, EventArgs e)
    {
        if( TextBoxPassword.Text != "")
        {
            Password = TextBoxPassword.Text;
        }
    }

    protected void SignUP_Click(object sender, EventArgs e)
    {
        Response.Redirect("SignUP.aspx");
    }
}