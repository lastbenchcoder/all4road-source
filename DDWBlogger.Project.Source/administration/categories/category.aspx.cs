using DDWBlogger.Project.Source.App_Data;
using DDWBlogger.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDWBlogger.Project.Source.administration.categories
{
    public partial class category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Categories";
            if (Request.QueryString["updateMode"] != null)
            {
                if (Request.QueryString["updateMode"] == "200")
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Success! Category Modified Successfully.";
                }
                else if (Request.QueryString["updateMode"] == "300")
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Success! Category Deleted Successfully.";
                }
                else if (Request.QueryString["updateMode"] == "404")
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops! Category detail Failed to Updated (Error may be, same category name entered).";
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Visible = false;
                    lblMessage.Text = "";
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int adminId = Convert.ToInt32(Session["AdminKey"].ToString());
                using (var context = new DBContext())
                {
                    Administrator Administrator = context.Administrator.Where(m => m.AdministratorId == adminId).FirstOrDefault();
                    Category Category = new Category
                    {
                        Title = txtTitle.Text,
                        Description = txtDescription.Text,
                        StatusId = context.Status.Where(m => m.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString()).FirstOrDefault().StatusId,
                        AdministratorId = Administrator.AdministratorId,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now
                    };

                    context.Category.Add(Category);
                    context.SaveChanges();

                    txtTitle.Text = "";
                    txtDescription.Text = "";

                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Success! New Category Successfully.";
                }
            }
            catch(Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }
        }
    }
}