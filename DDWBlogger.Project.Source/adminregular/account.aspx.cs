using DDWBlogger.Project.Source.App_Data;
using DDWBlogger.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDWBlogger.Project.Source.adminregular
{
    public partial class account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["adminId"] != null)
                {
                    int adminId = Convert.ToInt32(Request.QueryString["adminId"].ToString());
                    using (var context = new DBContext())
                    {
                        Administrator Administrator = context.Administrator.Where(m => m.AdministratorId == adminId).FirstOrDefault();
                        if (Administrator != null)
                        {
                            lblSecurityQuestion.Text = Administrator.SecurityQuestion;
                            lblBcTitle.Text = Administrator.FirstName +" "+Administrator.LastName;
                            hdnAdminId.Value = Administrator.AdministratorId.ToString();
                        }
                    }
                }
            }
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Password Reset";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int adminId = Convert.ToInt32(hdnAdminId.Value);
            using (var context = new DBContext())
            {
                Administrator Administrator = context.Administrator.Where(m => m.AdministratorId == adminId).FirstOrDefault();
                if (Administrator != null)
                {
                    if (Administrator.SecurityAnswer == txtAnswer.Text)
                    {
                        pnlErrorMessage.Visible = false;
                        lblMessage.Text = "";
                        Administrator.Password = txtPassword.Text;
                        context.Entry(Administrator).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();

                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Account Password Updated Successfully.";
                    }
                    else
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Entered Answer is wrong.";
                    }
                }
            }
        }
    }
}