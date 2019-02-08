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
    public partial class subcategorydetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["catId"] != null)
                {
                    int SubCategoryId = Convert.ToInt32(Request.QueryString["catId"].ToString());
                    using (var context = new DBContext())
                    {
                        SubCategory SubCategory = context.SubCategory.Where(m => m.SubCategoryId == SubCategoryId).FirstOrDefault();
                        List<Status> Status = new List<Status>();
                        Status = context.Status.Where(m => m.StatusFor == "All").ToList();
                        foreach (var item in Status)
                        {
                            ddlStatus.Items.Add(new ListItem { Text = item.Title, Value = item.StatusId.ToString() });
                        }

                        List<Category> Category = new List<Category>();
                        Category = context.Category.Include("Status").ToList();
                        foreach (var item in Category)
                        {
                            if (item.Status.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString())
                            {
                                ddlCategory.Items.Add(new ListItem { Text = item.Title, Value = item.CategoryId.ToString() });
                            }
                        }

                        txtTitle.Text = SubCategory.Title;
                        txtDescription.Text = SubCategory.Description;
                        hdnSubCategoryId.Value = SubCategory.SubCategoryId.ToString();
                        ddlStatus.SelectedValue = SubCategory.StatusId.ToString();
                        ddlCategory.Text = SubCategory.CategoryId.ToString();
                        lblBcTitle.Text= SubCategory.Title;
                    }
                    this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Categories";
                }
                else
                {
                    Response.Redirect("/administration/categories/SubCategory.aspx?updateMode=404&redirectUrl=SubCategory-administrator-home&pageId=1234HJHJKJ*7987979");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int valueResult = 0;
            try
            {
                int adminId = Convert.ToInt32(Session["AdminKey"].ToString());
                int SubCategoryId = Convert.ToInt32(hdnSubCategoryId.Value);
                using (var context = new DBContext())
                {
                    Administrator Administrator = context.Administrator.Where(m => m.AdministratorId == adminId).FirstOrDefault();
                    SubCategory SubCategory = context.SubCategory.Where(m => m.SubCategoryId == SubCategoryId).FirstOrDefault();
                    SubCategory.Title = txtTitle.Text;
                    SubCategory.Description = txtDescription.Text;
                    SubCategory.StatusId = Convert.ToInt32(ddlStatus.SelectedValue);
                    SubCategory.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);

                    context.Entry(SubCategory).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    valueResult = 200;
                }
            }
            catch (Exception ex)
            {
                valueResult = 404;
            }
            Response.Redirect("/administration/categories/SubCategory.aspx?updateMode="+ valueResult + "&redirectUrl=SubCategory-administrator-home&pageId=1234HJHJKJ*7987979");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/administration/categories/SubCategory.aspx?updateMode=800&redirectUrl=SubCategory-administrator-home&pageId=1234HJHJKJ*7987979");
        }
    }
}