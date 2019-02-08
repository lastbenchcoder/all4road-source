using DDWBlogger.Project.Source.App_Data;
using DDWBlogger.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDWBlogger.Project.Source.administration.home
{
    public partial class gallerydetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["galid"] != null)
                {
                    int GalleryId = Convert.ToInt32(Request.QueryString["galid"].ToString());
                    using (var context = new DBContext())
                    {
                        Gallery Gallery = context.Gallery.Where(m => m.GalleryId == GalleryId).FirstOrDefault();
                        List<Status> Status = new List<Status>();
                        Status = context.Status.Where(m => m.StatusFor == "All").ToList();
                        foreach (var item in Status)
                        {
                            ddlStatus.Items.Add(new ListItem { Text = item.Title, Value = item.StatusId.ToString() });
                        }

                        txtTitle.Text = Gallery.Title;
                        txtDescription.Text = Gallery.Description;
                        hdnGalleryId.Value = Gallery.GalleryId.ToString();
                        ddlStatus.SelectedValue = Gallery.StatusId.ToString();
                        lblBcTitle.Text = Gallery.Title;
                    }
                    this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Categories";
                }
                else
                {
                    Response.Redirect("/administration/home/Gallery.aspx?updateMode=404&redirectUrl=Gallery-administrator-home&pageId=1234HJHJKJ*7987979");
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int valueResult = 0;
            try
            {
                int adminId = Convert.ToInt32(Session["AdminKey"].ToString());
                int GalleryId = Convert.ToInt32(hdnGalleryId.Value);
                using (var context = new DBContext())
                {
                    Administrator Administrator = context.Administrator.Where(m => m.AdministratorId == adminId).FirstOrDefault();
                    Gallery Gallery = context.Gallery.Where(m => m.GalleryId == GalleryId).FirstOrDefault();
                    Gallery.Title = txtTitle.Text;
                    Gallery.Description = txtDescription.Text;
                    Gallery.StatusId = Convert.ToInt32(ddlStatus.SelectedValue);

                    context.Entry(Gallery).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    valueResult = 200;
                }
            }
            catch (Exception ex)
            {
                valueResult = 404;
            }
            Response.Redirect("/administration/home/Gallery.aspx?updateMode=" + valueResult + "&redirectUrl=Gallery-administrator-home&pageId=1234HJHJKJ*7987979");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/administration/home/Gallery.aspx?updateMode=800&redirectUrl=Gallery-administrator-home&pageId=1234HJHJKJ*7987979");
        }
    }
}