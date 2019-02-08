using DDWBlogger.Project.Source.App_Data;
using DDWBlogger.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDWBlogger.Project.Source.administration.admin
{
    public partial class invitations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Invitations";
            if (!IsPostBack)
            {
                using (var context = new DBContext())
                {
                    List<Role> Role = new List<Role>();
                    Role = context.Role.ToList();
                    foreach (var item in Role)
                    {
                        if (item.InDisplay == 1)
                        {
                            ddlRole.Items.Add(new ListItem { Text = item.Title, Value = item.RoleId.ToString() });
                        }
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
                    Invitation Invitation = new Invitation
                    {
                        InvitationCode = Guid.NewGuid().ToString(),
                        EmailId = txtEmailId.Text,
                        RoleId = Convert.ToInt32(ddlRole.SelectedValue),
                        StatusId = context.Status.Where(m => m.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString() && m.StatusFor=="Invitation").FirstOrDefault().StatusId,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now
                    };

                    context.Invitation.Add(Invitation);
                    context.SaveChanges();

                    txtEmailId.Text = "";
                    ddlRole.SelectedIndex = 0;

                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Success! New Invitation Successfully.";
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