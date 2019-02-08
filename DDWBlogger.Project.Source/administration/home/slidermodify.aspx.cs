using DDWBlogger.Project.Source.App_Data;
using DDWBlogger.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDWBlogger.Project.Source.administration.home
{
    public partial class slidermodify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Modify Slider";
            if (Request.QueryString["sliderId"] != null)
            {
                using (var context = new DBContext())
                {
                    int sliderId = Convert.ToInt32(Request.QueryString["sliderId"]);
                    Slider Slider = context.Slider.Include("Article").Where(m => m.SliderId == sliderId).FirstOrDefault();
                    if (Slider != null)
                    {
                        lblArticleId.Text = Slider.ArticleId.ToString();
                        imgArticle.ImageUrl = "../../" + Slider.Banner;
                        lblArticle.Text = Slider.Article.Title;
                        hdnSliderId.Value = Slider.SliderId.ToString();
                    }
                    else
                    {
                        Response.Redirect("/administration/home/slider.aspx?updateMode=404&redirectUrl=category-administrator-home&pageId=1234HJHJKJ*7987979");
                    }
                }
            }
            else
            {
                Response.Redirect("/administration/home/slider.aspx?updateMode=404&redirectUrl=category-administrator-home&pageId=1234HJHJKJ*7987979");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int valueResult = 0;
            try
            {
                int sliderId = Convert.ToInt32(hdnSliderId.Value);
                using (var context = new DBContext())
                {
                    Slider Slider = context.Slider.Where(m => m.SliderId == sliderId).FirstOrDefault();

                    context.Entry(Slider).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                    valueResult = 200;
                }
            }
            catch (Exception ex)
            {
                valueResult = 404;
            }
            Response.Redirect("/administration/home/slider.aspx?updateMode=" + valueResult + "&redirectUrl=slider-administrator-home&pageId=1234HJHJKJ*7987979");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/administration/home/slider.aspx?updateMode=222&redirectUrl=category-administrator-home&pageId=1234HJHJKJ*7987979");
        }
    }
}