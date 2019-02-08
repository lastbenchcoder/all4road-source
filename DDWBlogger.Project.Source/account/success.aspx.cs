using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDWBlogger.Project.Source.account
{
    public partial class success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Success";
            if(Request.QueryString["messageId"]!=null)
            {
                if(Request.QueryString["messageId"].ToString()=="200")
                {
                    lblMessage.Text = "Success, Password Reset Done Successfully.";
                }
                else if(Request.QueryString["messageId"].ToString() == "300")
                {
                    lblMessage.Text = "Failed, Password Reset Link Expired.";
                }
                else if (Request.QueryString["messageId"].ToString() == "400")
                {
                    lblMessage.Text = "Failed, Invitation already Expired/completed.";
                }
                else if (Request.QueryString["messageId"].ToString() == "500")
                {
                    lblMessage.Text = "Success, Registration Completed Successfully.";
                }
            }
        }
    }
}