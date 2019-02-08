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
    public partial class categorydetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["catId"] != null)
                {
                    int categoryId = Convert.ToInt32(Request.QueryString["catId"].ToString());
                    using (var context = new DBContext())
                    {
                        Category Category = context.Category.Where(m => m.CategoryId == categoryId).FirstOrDefault();
                        List<Status> Status = new List<Status>();
                        Status = context.Status.Where(m => m.StatusFor == "All").ToList();
                        foreach (var item in Status)
                        {
                            ddlStatus.Items.Add(new ListItem { Text = item.Title, Value = item.StatusId.ToString() });
                        }
                        txtTitle.Text = Category.Title;
                        txtDescription.Text = Category.Description;
                        hdnCategoryId.Value = Category.CategoryId.ToString();
                        ddlStatus.SelectedValue = Category.StatusId.ToString();
                        lblBcTitle.Text= Category.Title;
                    }
                    this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Categories";
                }
                else
                {
                    Response.Redirect("/administration/categories/category.aspx?updateMode=404&redirectUrl=category-administrator-home&pageId=1234HJHJKJ*7987979");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int valueResult = 0;
            try
            {
                int adminId = Convert.ToInt32(Session["AdminKey"].ToString());
                int categoryId = Convert.ToInt32(hdnCategoryId.Value);
                using (var context = new DBContext())
                {
                    Administrator Administrator = context.Administrator.Where(m => m.AdministratorId == adminId).FirstOrDefault();
                    Category Category = context.Category.Where(m => m.CategoryId == categoryId).FirstOrDefault();
                    Category.Title = txtTitle.Text;
                    Category.Description = txtDescription.Text;
                    Category.StatusId = Convert.ToInt32(ddlStatus.SelectedValue);

                    context.Entry(Category).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    valueResult = 200;
                }
            }
            catch (Exception ex)
            {
                valueResult = 404;
            }
            Response.Redirect("/administration/categories/category.aspx?updateMode="+ valueResult + "&redirectUrl=category-administrator-home&pageId=1234HJHJKJ*7987979");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/administration/categories/category.aspx?updateMode=800&redirectUrl=category-administrator-home&pageId=1234HJHJKJ*7987979");
        }
    }
}