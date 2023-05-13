using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login2 : System.Web.UI.Page
{
    string Mail;
    string Password;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
        }
    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        if(Mail!=null && Password !=null)
        {
            string script = "<script>console.log('" + Mail + " " + Password + "');</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Console", script);

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