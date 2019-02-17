using DDWBlogger.Project.Source.App_Data;
using DDWBlogger.Project.Source.Enums;
using DDWBlogger.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDWBlogger.Project.Source.administration.pages
{
    public partial class menudetail : System.Web.UI.Page
    {
        private DBContext context;
        public menudetail()
        {
            context = new DBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<DDWBlogger.Project.Source.Models.Pages> Pages = new List<DDWBlogger.Project.Source.Models.Pages>();
                Pages = context.Pages.ToList();
                foreach (var item in Pages)
                {
                    ddlpage.Items.Add(new ListItem { Text = item.Title, Value = item.Page_Id.ToString() });
                }

                Array roles = Enum.GetValues(typeof(eMenu));
                foreach (eMenu rls in roles)
                {
                    ddlmenutype.Items.Add(new ListItem(rls.ToString()));
                }

                string id = Request.QueryString["menuId"].ToString();
                hdnPageId.Value = id;
                if (!IsPostBack)
                {
                    int menuId = Convert.ToInt32(id);
                    Menus Menu = context.Menus.Where(m => m.Menu_Id == menuId).FirstOrDefault();
                    lblBcTitle.Text = Menu.Title;
                    txtCategory.Text = Menu.Title;
                    ddlpage.SelectedValue = Menu.Page_Id.ToString();
                    ddlmenutype.Text = Menu.MenuType;
                    txtCustomURL.Text = Menu.Custom_Url;
                    isCustomURL.Checked = (txtCustomURL.Text == "Pages") ? true : false;
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int adminId = Convert.ToInt32(Session["AdminKey"].ToString());
            int menuId = Convert.ToInt32(hdnPageId.Value);
            Menus RMenu = context.Menus.Where(m => m.Menu_Id == menuId).FirstOrDefault();

            RMenu.Title = txtCategory.Text;
            RMenu.MenuType = ddlmenutype.Text;
            RMenu.Page_Id = (isCustomURL.Checked) ? context.Pages.Where(m => m.Title.ToLower() == "default").FirstOrDefault().Page_Id : Convert.ToInt32(ddlpage.SelectedValue);
            RMenu.Custom_Url = (isCustomURL.Checked) ? txtCustomURL.Text : "PageId";
            RMenu.StatusId = Convert.ToInt32(eStatus.Active);
            RMenu.DateUpdated = DateTime.Now;
            RMenu.AdministratorId = adminId;

            context.Entry(RMenu).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            Response.Redirect("/administration/pages/menus.aspx?id=100&redirect-url=uyiretieyt7985798435ihtiuertireyte&id-red=alladmin.html");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int pageId = Convert.ToInt32(hdnPageId.Value);
            Menus RMenu = context.Menus.Where(m => m.Page_Id == pageId).FirstOrDefault();
            context.Entry(RMenu).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            Response.Redirect("/administration/pages/menus.aspx?id=200&redirect-url=uyiretieyt7985798435ihtiuertireyte&id-red=alladmin.html");
        }
        protected void isCustomURL_CheckedChanged(object sender, EventArgs e)
        {
            if (isCustomURL.Checked)
            {
                pnlCustomURL.Visible = true;
                pnlPageSelection.Visible = false;
            }
            else
            {
                pnlCustomURL.Visible = false;
                pnlPageSelection.Visible = true;
            }
        }
    }
}