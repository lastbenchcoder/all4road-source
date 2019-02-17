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
    public partial class menus : System.Web.UI.Page
    {
        private DBContext context;
        public menus()
        {
            context = new DBContext();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                if (Request.QueryString["id"].ToString() == "200")
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Menu Deleted Successfully";
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Menu Created Successfully";
                }
            }

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
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int adminId = Convert.ToInt32(Session["AdminKey"].ToString());
                Menus Menu = new Menus();
                Menu = context.Menus.Where(m => m.MenuType == ddlmenutype.Text && m.Title == txtCategory.Text).FirstOrDefault();
                if (Menu == null)
                {
                    Menus RMenu = new Menus()
                    {
                        Title = txtCategory.Text,
                        MenuType = ddlmenutype.Text,
                        Page_Id = (isCustomURL.Checked) ? context.Pages.Where(m => m.Title.ToLower() == "default").FirstOrDefault().Page_Id : Convert.ToInt32(ddlpage.SelectedValue),
                        Custom_Url = (isCustomURL.Checked) ? txtCustomURL.Text : "PageId",
                        StatusId = Convert.ToInt32(eStatus.Active),
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        AdministratorId = adminId,
                    };

                    context.Menus.Add(RMenu);
                    context.SaveChanges();
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Menu Created Successfully";
                    ClearFields();
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Menu Created Successfully";
                }
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.Message.ToString();
            }
        }
        private void ClearFields()
        {
            ddlpage.SelectedIndex = 0;
            ddlmenutype.SelectedIndex = 0;
            txtCategory.Text = "";
            txtCustomURL.Text = "";
            isCustomURL.Checked = false;
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