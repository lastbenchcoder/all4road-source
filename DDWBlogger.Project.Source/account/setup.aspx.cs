using DDWBlogger.Project.Source.App_Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDWBlogger.Project.Source.account
{
    public partial class setup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Application SetUp";
        }

        protected void btnSetUp_Click(object sender, EventArgs e)
        {
            Migrations.Configuration AppSetUp = new Migrations.Configuration();
            AppSetUp.ApplicationSetup();
            lblMessage.Text = "Success!! Application set up completed successfully.";
        }
    }
}