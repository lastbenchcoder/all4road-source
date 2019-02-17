using DDWBlogger.Project.Source.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDWBlogger.Project.Source.administration.pages
{
    public partial class pagedetail : System.Web.UI.Page
    {
        private DBContext context;
        public pagedetail()
        {
            context = new DBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["pageid"].ToString();
                hdnPageId.Value = id;
                if (!IsPostBack)
                {
                    int pageId = Convert.ToInt32(id);
                    DDWBlogger.Project.Source.Models.Pages Pages = context.Pages.Where(m => m.Page_Id == pageId).FirstOrDefault();
                    txtOfferTitle.Text = Pages.Title;
                    txtSmallDescription.Text = Pages.Description;
                    bcTitle.Text= Pages.Title;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int adminId = Convert.ToInt32(Session["AdminKey"].ToString());
            int pageId = Convert.ToInt32(hdnPageId.Value);
            DDWBlogger.Project.Source.Models.Pages Pages = context.Pages.Where(m => m.Page_Id == pageId).FirstOrDefault();

            Pages.AdministratorId = adminId;
            Pages.Title = txtOfferTitle.Text;
            Pages.Description = txtSmallDescription.Text;
            Pages.DateUpdated = DateTime.Now;

            context.Entry(Pages).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            Response.Redirect("/administration/pages/allpages.aspx?id=100&redirect-url=uyiretieyt7985798435ihtiuertireyte&id-red=alladmin.html");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int pageId = Convert.ToInt32(hdnPageId.Value);
            DDWBlogger.Project.Source.Models.Pages Pages = context.Pages.Where(m => m.Page_Id == pageId).FirstOrDefault();
            context.Entry(Pages).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            Response.Redirect("/administration/pages/allpages.aspx?id=200&redirect-url=uyiretieyt7985798435ihtiuertireyte&id-red=alladmin.html");
        }
    }
}