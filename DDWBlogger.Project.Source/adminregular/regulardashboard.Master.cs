using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDWBlogger.Project.Source.adminregular
{
    public partial class regulardashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RgAdminKey"] == null)
            {
                string url = HttpContext.Current.Request.Url.PathAndQuery;
                Session["PreviousUrl"] = url;
                Response.Redirect("~/account/logout.aspx?logout=100&redUrl=HGHGH786876");
            }
        }
    }
}