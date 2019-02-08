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
    public partial class subcategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Categories";
            if (!IsPostBack)
            {
                List<Category> Category = new List<Category>();
                using (var context = new DBContext())
                {
                    Category = context.Category.Include("Status").ToList();
                    foreach (var item in Category)
                    {
                        if (item.Status.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString())
                        {
                            ddlCategory.Items.Add(new ListItem { Text = item.Title, Value = item.CategoryId.ToString() });
                        }
                    }
                }
                if (Request.QueryString["updateMode"] != null)
                {
                    if (Request.QueryString["updateMode"] == "200")
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Success! SubCategory Modified Successfully.";
                    }
                    else if (Request.QueryString["updateMode"] == "300")
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Success! SubCategory Deleted Successfully.";
                    }
                    else if (Request.QueryString["updateMode"] == "404")
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Oops! SubCategory detail Failed to Updated (Error may be, same sub category name entered).";
                    }
                    else
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Visible = false;
                        lblMessage.Text = "";
                    }
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
                    SubCategory SubCategory = new SubCategory
                    {
                        CategoryId = Convert.ToInt32(ddlCategory.SelectedValue),
                        Title = txtTitle.Text,
                        Description = txtDescription.Text,
                        StatusId = context.Status.Where(m => m.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString()).FirstOrDefault().StatusId,
                        AdministratorId = Administrator.AdministratorId,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now
                    };

                    context.SubCategory.Add(SubCategory);
                    context.SaveChanges();

                    txtTitle.Text = "";
                    txtDescription.Text = "";
                    ddlCategory.SelectedIndex = 0;

                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Success! New SubCategory Successfully.";
                }
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }
        }
    }
}