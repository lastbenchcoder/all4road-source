using DDWBlogger.Project.Source.App_Data;
using DDWBlogger.Project.Source.Helper;
using DDWBlogger.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDWBlogger.Project.Source.account
{
    public partial class invitation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string code = Request.QueryString["code"].ToString();
            string emailid = Request.QueryString["emailid"].ToString();
            Invitation _invit = null;
            using (var context = new DBContext())
            {
                _invit = context.Invitation.Include("Status").Where(m => m.InvitationCode == code).FirstOrDefault();
                if (_invit.Status.Title != DDWBlogger.Project.Source.Enums.eStatus.Active.ToString())
                {
                    Response.Redirect("/account/success.aspx?messageId=400&redirect_url=success-failure-message&pageId=87234234234234");
                }
            }
            hdnInviteCode.Value = Request.QueryString["code"].ToString();
            txtEmail.Text = _invit.EmailId;
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Invitations";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (var context = new DBContext())
            {
                Invitation _invit = context.Invitation.Include("Status").Where(m => m.InvitationCode == hdnInviteCode.Value).FirstOrDefault();

                if (_invit.Status.Title != DDWBlogger.Project.Source.Enums.eStatus.Active.ToString())
                {
                    Response.Redirect("/account/success.aspx?messageId=400&redirect_url=success-failure-message&pageId=87234234234234");
                }

                Administrator _administrators = context.Administrator.Where(m => m.PhoneNo == txtPhone.Text).FirstOrDefault();
                if (_administrators == null)
                {
                    Administrator Administrator = new Administrator()
                    {
                        FirstName = "FirstName Required",
                        LastName = "LastName Required",
                        EmailId = txtEmail.Text,
                        PhoneNo = txtPhone.Text,
                        Description = "Please Enter about yourself",
                        Banner = "content/noimage.png",
                        Password = txtPassword.Text,
                        StatusId = _invit.StatusId,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        RoleId = _invit.RoleId,
                        LoginId=_invit.EmailId,
                        InvitationId= _invit.InvitationId,
                        SecurityQuestion=context.SecurityQuestions.FirstOrDefault().Title,
                        SecurityAnswer="application"
                    };

                    context.Administrator.Add(Administrator);
                    context.SaveChanges();

                    _invit.StatusId = context.Status.Where(m=>m.Title== DDWBlogger.Project.Source.Enums.eStatus.Completed.ToString()).FirstOrDefault().StatusId;
                    _invit.DateUpdated = DateTime.Now;

                    context.Entry(_invit).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();

                    if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
                    {
                        string body = MailHelper.AccountCreated(Administrator.FirstName, Administrator.EmailId, Administrator.Password, _invit.Role.Title);
                        string mail_result = MailHelper.SendEmail(Administrator.EmailId, "["+ ConfigurationSettings.AppSettings["AppName"].ToString() + "] - New Account Creation", body, "[" + ConfigurationSettings.AppSettings["AppName"].ToString() + "] - New Account Creation");
                    }

                    Response.Redirect("/account/success.aspx?messageId=500&redirect_url=success-failure-message&pageId=87234234234234");
                }
                else
                {
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Failed!!! Entered phone number already exists, please choose different phone number.";
                }
            }
        }
    }
}