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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["a4rredirectUrl"] != null)
            {
                this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Login";
            }
            else
            {
                Response.Redirect("/account/login.aspx?a4rredirectUrl=login-administrator-home&pageId=1234HJHJKJ*7987979");
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            using (var context = new DBContext())
            {
                Administrator Administrator = context.Administrator.Include("Role").Where(m => m.EmailId == txtUserId.Text && m.Password == txtPassword.Text).FirstOrDefault();
                if (Administrator != null)
                {
                    pnlErrorMessage.Visible = false;
                    lblMessage.Text = "";                    
                    if (Session["PreviousUrl"] != null)
                    {
                        if (Administrator.Role.Title.ToLower() == "super")
                        {
                            Session["AdminKey"] = Administrator.AdministratorId.ToString();
                            Response.Redirect(Session["PreviousUrl"].ToString(), false);
                        }
                        else
                        {
                            Session["RgAdminKey"] = Administrator.AdministratorId.ToString();
                            Response.Redirect(Session["PreviousUrl"].ToString(), false);
                        }                        
                    }
                    else
                    {
                        if (Administrator.Role.Title.ToLower() == "super")
                        {
                            Session["AdminKey"] = Administrator.AdministratorId.ToString();
                            Response.Redirect("/administration/dashboard.aspx?redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979");
                        }
                        else
                        {
                            Session["RgAdminKey"] = Administrator.AdministratorId.ToString();
                            Response.Redirect("/adminregular/dashboard.aspx?redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979");
                        }
                    }
                }
                else
                {
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops! Invalid UserId/Password.";
                }
            }
        }
    }
}