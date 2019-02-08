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
    public partial class featuredarticles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Article & Features";
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    if(Request.QueryString["id"].ToString()=="2000")
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Success! selected items deleted Successfully.";

                    }
                }
            }
        }

        protected void btnSearchArticle_Click(object sender, EventArgs e)
        {
            ddlArticleFeature.Items.Clear();
            ddlArticleFeature.Items.Add("Select..");
            pnlArticleSearch.Visible = false;
            using (var context = new DBContext())
            {
                int articleId = Convert.ToInt32(txtArticleId.Text);
                Article Article = context.Article.Include("Status").Where(m => m.ArticleId == articleId).FirstOrDefault();
                if (Article != null)
                {
                    if (Article.Status.Title == Enums.eStatus.Published.ToString())
                    {
                        pnlArticleSearch.Visible = true;
                        List<ArticleAndTypes> ArticleAndTypes = new List<ArticleAndTypes>();
                        ArticleAndTypes = context.ArticleAndTypes.ToList();
                        foreach (var item in ArticleAndTypes)
                        {
                            if (item.InDisplay == 1)
                            {
                                ddlArticleFeature.Items.Add(new ListItem { Text = item.Type, Value = item.ArticleAndTypesId.ToString() });
                            }
                        }
                        lblArticleId.Text = Article.ArticleId.ToString();
                        lblArticle.Text = Article.Title;
                        imgArticle.ImageUrl = "../../" + Article.FeaturedBanner;
                    }
                    else
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Oops! Article you are searching, not in published status.";
                    }
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops! No Articles found for your search.";
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int articleId = Convert.ToInt32(lblArticleId.Text);
            int featureId = Convert.ToInt32(ddlArticleFeature.SelectedValue);
            using (var context = new DBContext())
            {
                ArticleAndTypes ArticleAndTypes = context.ArticleAndTypes.Where(m => m.ArticleAndTypesId == featureId).FirstOrDefault();
                List<ArticleAndFeatures> lstArticleAndFeatures = context.ArticleAndFeatures.Where(m => m.ArticleAndTypesId == featureId).ToList();
                if (ArticleAndTypes.ArticleCount >= lstArticleAndFeatures.Count())
                {
                    ArticleAndFeatures ArticleAndFeatures = context.ArticleAndFeatures.Where(m => m.ArticleAndTypesId == featureId && m.ArticleId == articleId).FirstOrDefault();
                    if (ArticleAndFeatures == null)
                    {
                        int adminId = Convert.ToInt32(Session["AdminKey"].ToString());
                        Administrator Administrator = context.Administrator.Where(m => m.AdministratorId == adminId).FirstOrDefault();
                        ArticleAndFeatures ArticleAndFeaturesNew = new ArticleAndFeatures
                        {
                            AdministratorId = Administrator.AdministratorId,
                            ArticleId = articleId,
                            ArticleAndTypesId = featureId,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        };

                        context.ArticleAndFeatures.Add(ArticleAndFeaturesNew);
                        context.SaveChanges();

                        ddlArticleFeature.SelectedIndex = 0;
                        pnlArticleSearch.Visible = false;
                        lblArticle.Text = "";
                        lblArticleId.Text = "";
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Success! Article " + lblArticle.Text + " Added to the selected feature " + ddlArticleFeature.Text + " Successfully.";
                    }
                    else
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Oops! Failed to complete your action, because selected article already added to the selected feature.";
                    }
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops! Failed to complete your action, because you have reached maximum count. Total count will be "
                        + ArticleAndTypes.ArticleCount + " Already You have submitted the "
                        + lstArticleAndFeatures.Count() + " for this feature.";
                }
            }
        }

        [System.Web.Services.WebMethod]
        public static string DeleteFeaturedArticle(string featureId)
        {
            int featureId1 = Convert.ToInt32(featureId);
            using (var context = new DBContext())
            {
                ArticleAndFeatures ArticleAndFeatures = context.ArticleAndFeatures.Where(m => m.ArticleAndFeaturesId == featureId1).FirstOrDefault();
                context.Entry(ArticleAndFeatures).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
            return "100";
        }
    }
}