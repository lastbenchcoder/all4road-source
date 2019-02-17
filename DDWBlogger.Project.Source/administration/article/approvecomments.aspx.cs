using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DDWBlogger.Project.Source.Models;
using DDWBlogger.Project.Source.App_Data;
using System.Configuration;

namespace DDWBlogger.Project.Source.administration.article
{
    public partial class approvecomments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["commentid"] != null && Session["AdminKey"] != null)
                {
                    using (var context = new DBContext())
                    {
                        int commentid = Convert.ToInt32(Request.QueryString["commentid"].ToString());
                        ReviewComment ReviewComment = context.ReviewComment.Include("Article").Where(m => m.ReviewCommentId == commentid).FirstOrDefault();
                        lblProductTitle.Text = ReviewComment.Article.Title;
                        lblUserDetail.Text = ReviewComment.EmailId + "(" + ReviewComment.FullName + ")";
                        lblBcTitle.Text = ReviewComment.Article.Title;
                        lblDescription.Text = ReviewComment.CommentDescription;
                        imgProduct.ImageUrl = "../../" + ReviewComment.Article.FeaturedBanner;
                        hdnCommentId.Value = ReviewComment.ReviewCommentId.ToString();
                        lblDate.Text = ReviewComment.DateCreated.ToString("D");
                        this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Article Update " + ReviewComment.CommentDescription;
                    }
                }
                else
                {
                    string url = HttpContext.Current.Request.Url.PathAndQuery;
                    Session["PreviousUrl"] = url;
                    Response.Redirect("~/account/logout.aspx?logout=100&redUrl=HGHGH786876");
                }
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            if (Session["AdminKey"] != null)
            {
                using (var context = new DBContext())
                {
                    int commentid = Convert.ToInt32(hdnCommentId.Value);
                    ReviewComment ReviewComment = context.ReviewComment.Include("Article").Where(m => m.ReviewCommentId == commentid).FirstOrDefault();
                    int loginAdminId = Convert.ToInt32(Session["AdminKey"].ToString());
                    Administrator loginAdministrator = context.Administrator.Include("Role").Where(m => m.AdministratorId == loginAdminId).FirstOrDefault();
                    ReviewComment.StatusId= context.Status.Where(m => m.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString() && m.StatusFor=="All").FirstOrDefault().StatusId;
                    ReviewComment.DateUpdated = DateTime.Now;
                    context.Entry(ReviewComment).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    Response.Redirect("/administration/article/ratingsreview.aspx?articleUpdate=100&redirect-url=uyiretieyt7985798435ihtiuertireyte&id-red=alladmin.html");
                }
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            if (Session["AdminKey"] != null)
            {
                using (var context = new DBContext())
                {
                    int commentid = Convert.ToInt32(hdnCommentId.Value);
                    ReviewComment ReviewComment = context.ReviewComment.Include("Article").Where(m => m.ReviewCommentId == commentid).FirstOrDefault();
                    int loginAdminId = Convert.ToInt32(Session["AdminKey"].ToString());
                    Administrator loginAdministrator = context.Administrator.Include("Role").Where(m => m.AdministratorId == loginAdminId).FirstOrDefault();
                    ReviewComment.StatusId = context.Status.Where(m => m.Title == DDWBlogger.Project.Source.Enums.eStatus.InActive.ToString() && m.StatusFor == "All").FirstOrDefault().StatusId;
                    ReviewComment.DateUpdated = DateTime.Now;
                    context.Entry(ReviewComment).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    Response.Redirect("/administration/article/ratingsreview.aspx?articleUpdate=200&redirect-url=uyiretieyt7985798435ihtiuertireyte&id-red=alladmin.html");
                }
            }
        }
    }
}