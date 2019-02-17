using DDWBlogger.Project.Source.Enums;
using System;
using System.Configuration;

namespace DDWBlogger.Project.Source.administration.pages
{
    public partial class newpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : New Page";
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int adminId = Convert.ToInt32(Session["AdminKey"].ToString());
            using (var context = new DDWBlogger.Project.Source.App_Data.DBContext())
            {
                DDWBlogger.Project.Source.Models.Pages Pages = new DDWBlogger.Project.Source.Models.Pages()
                {
                    AdministratorId = adminId,
                    Title = txtOfferTitle.Text,
                    Description = txtSmallDescription.Text,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    StatusId = Convert.ToInt32(eStatus.Active)
                };

                context.Pages.Add(Pages);
                context.SaveChanges();
            }
            Response.Redirect("/administration/pages/allpages.aspx?id=100&redirect-url=uyiretieyt7985798435ihtiuertireyte&id-red=alladmin.html");
        }
    }
}