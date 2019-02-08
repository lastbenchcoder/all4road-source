using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDWBlogger.Project.Source.administration.article
{
    public partial class ratingsreview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["articleUpdate"] != null)
                {
                    if (Request.QueryString["articleUpdate"] == "100")
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Success! Ratings & Review Approved Successfully.";
                    }
                    else if (Request.QueryString["articleUpdate"] == "200")
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Success!  Ratings & Review Detail Rejected Successfully.";
                    }
                }
            }

            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Ratings & Review";
        }
    }
}