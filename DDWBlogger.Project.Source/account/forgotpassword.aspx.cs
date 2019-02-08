using DDWBlogger.Project.Source.App_Data;
using DDWBlogger.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDWBlogger.Project.Source.account
{
    public partial class forgotpassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Forgot Password";
            if (!IsPostBack)
            {
                Session["FgPwdSession"] = null;
            }            
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            using (var context = new DBContext())
            {
                Administrator Administrator = context.Administrator.Where(m => m.EmailId == txtUserId.Text).FirstOrDefault();
                if (Administrator != null)
                {
                    pnlErrorMessage.Visible = false;
                    lblMessage.Text = "";
                    Session["FgPwdSession"] = Administrator.AdministratorId.ToString();
                    Response.Redirect("/account/passwordreset.aspx?redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979");
                }
                else
                {
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops! Entered EmailId Not Exists.";
                }
            }
        }
    }
}