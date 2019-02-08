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
    public partial class adsmodify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Modify Slider";
            if (Request.QueryString["adsid"] != null)
            {
                using (var context = new DBContext())
                {
                    int adsId = Convert.ToInt32(Request.QueryString["adsid"]);
                    Ads Ads = context.Ads.Include("AddSize").Where(m => m.AdsId == adsId).FirstOrDefault();
                    if (Ads != null)
                    {
                        lblAdsId.Text = Ads.AdsId.ToString();
                        lblTitle.Text = Ads.Type;
                        lblHeightWidth.Text = Ads.AddSize.Title;
                        if(Ads.Type==Enums.eAds.Banner.ToString())
                        {
                            imgArticle.ImageUrl = "../../" + Ads.Banner;
                            lblBanner.Visible = false;
                        }
                        else
                        {
                            imgArticle.Visible = false;
                            lblBanner.Text = Server.HtmlEncode(Ads.Banner.ToString());
                        }
                        hdnSliderId.Value = Ads.AdsId.ToString();
                    }
                    else
                    {
                        Response.Redirect("/administration/home/ads.aspx?updateMode=404&redirectUrl=ads-administrator-home&pageId=1234HJHJKJ*7987979");
                    }
                }
            }
            else
            {
                Response.Redirect("/administration/home/ads.aspx?updateMode=404&redirectUrl=ads-administrator-home&pageId=1234HJHJKJ*7987979");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int valueResult = 0;
            try
            {
                int adsId = Convert.ToInt32(hdnSliderId.Value);
                using (var context = new DBContext())
                {
                    Ads Ads = context.Ads.Where(m => m.AdsId == adsId).FirstOrDefault();

                    context.Entry(Ads).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                    valueResult = 200;
                }
            }
            catch (Exception ex)
            {
                valueResult = 404;
            }
            Response.Redirect("/administration/home/ads.aspx?updateMode=" + valueResult + "&redirectUrl=ads-administrator-home&pageId=1234HJHJKJ*7987979");

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/administration/home/ads.aspx?updateMode=222&redirectUrl=category-administrator-home&pageId=1234HJHJKJ*7987979");
        }
    }
}