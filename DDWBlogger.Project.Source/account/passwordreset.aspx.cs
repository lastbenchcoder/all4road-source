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
    public partial class passwordreset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FgPwdSession"] != null)
            {
                int adminId = Convert.ToInt32(Session["FgPwdSession"].ToString());
                using (var context = new DBContext())
                {
                    Administrator Administrator = context.Administrator.Where(m => m.AdministratorId == adminId).FirstOrDefault();
                    if (Administrator != null)
                    {
                        lblSecQuestion.Text = Administrator.SecurityQuestion;
                    }
                }
                this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Password Reset";
            }
            else
            {
                Response.Redirect("/account/success.aspx?messageId=300&redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979");
            }
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            int adminId = Convert.ToInt32(Session["FgPwdSession"].ToString());
            using (var context = new DBContext())
            {
                Administrator Administrator = context.Administrator.Where(m => m.AdministratorId == adminId).FirstOrDefault();
                if (Administrator != null)
                {
                    if(Administrator.SecurityAnswer==txtAnswer.Text)
                    {
                        pnlErrorMessage.Visible = false;
                        lblMessage.Text = "";
                        Administrator.Password = txtPassword.Text;
                        context.Entry(Administrator).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                        Session["FgPwdSession"] = null;
                        Response.Redirect("/account/success.aspx?messageId=200&redirectUrl=dashboard-administrator-home&pageId=1234HJHJKJ*7987979");
                    }
                    else
                    {
                        pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Entered Answer is wrong.";
                    }
                }
            }
        }
    }
}