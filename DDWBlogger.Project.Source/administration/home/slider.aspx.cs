using DDWBlogger.Project.Source.App_Data;
using DDWBlogger.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDWBlogger.Project.Source.administration.home
{
    public partial class slider : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Home Slider";
            if (Request.QueryString["updateMode"] != null)
            {
                if (Request.QueryString["updateMode"] == "200")
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Success! Slider Deleted Successfully.";
                }
                else if (Request.QueryString["updateMode"] == "404")
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops! Slider detail Failed to Delete No Slider Id found or Invalid.";
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Visible = false;
                    lblMessage.Text = "";
                }
            }
        }

        protected void btnSearchArticle_Click(object sender, EventArgs e)
        {
            pnlArticleSearch.Visible = false;
            using (var context = new DBContext())
            {
                int articleId = Convert.ToInt32(txtArticleId.Text);
                Article Article = context.Article.Include("Status").Where(m => m.ArticleId == articleId).FirstOrDefault();
                if (Article != null)
                {
                    Slider Sliders = context.Slider.Where(m => m.ArticleId == articleId).FirstOrDefault();

                    if (Sliders == null)
                    {
                        if (Article.Status.Title == Enums.eStatus.Published.ToString())
                        {
                            pnlArticleSearch.Visible = true;
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
                        lblMessage.Text = "Oops! Failed to complete your action, because selected article already added slider section.";
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
            int adminId = Convert.ToInt32(Session["AdminKey"].ToString());


            using (var context = new DBContext())
            {
                Administrator Administrator = context.Administrator.Where(m => m.AdministratorId == adminId).FirstOrDefault();
                Article Article = context.Article.Where(m => m.ArticleId == articleId).FirstOrDefault();
                
                Slider Slider = new Slider()
                {
                    AdministratorId = Administrator.AdministratorId,
                    ArticleId = articleId,
                    DateCreated=DateTime.Now,
                    DateUpdated=DateTime.Now
                };

                if (rdoBannerType.SelectedValue == "1")
                {
                    Slider.Banner = Article.FeaturedBanner;

                    context.Slider.Add(Slider);
                    context.SaveChanges();

                    pnlArticleSearch.Visible = false;
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Success! New Slider Successfully.";
                }               
                else if (rdoBannerType.SelectedValue == "2" && imgInp.HasFile)
                {
                    Upload(Article.ArticleId.ToString());
                    Slider.Banner = "files/Sliders/" + Article.ArticleId.ToString() + "/" + imgInp.FileName;

                    context.Slider.Add(Slider);
                    context.SaveChanges();

                    pnlArticleSearch.Visible = false;
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Success! New Slider Successfully.";
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops! Please select the banner image to complete the action.";
                }
            }
        }

        protected void rdoBannerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoBannerType.SelectedValue == "2")
            {
                pnlImage.Visible = true;
            }
            else
            {
                pnlImage.Visible = false;
            }
        }

        private void Upload(string Id)
        {
            try
            {
                string folderPath = Server.MapPath("~/files/Sliders/" + Id + "/");
                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }

                Stream strm = imgInp.PostedFile.InputStream;
                using (var image = System.Drawing.Image.FromStream(strm))
                {
                    int newWidth = 695; // New Width of Image in Pixel  
                    int newHeight = 460; // New Height of Image in Pixel  
                    var thumbImg = new Bitmap(newWidth, newHeight);
                    var thumbGraph = Graphics.FromImage(thumbImg);
                    thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                    thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                    thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                    thumbGraph.DrawImage(image, imgRectangle);
                    // Save the file  
                    string targetPath = folderPath + imgInp.FileName;
                    thumbImg.Save(targetPath, image.RawFormat);

                }

                //Save the File to the Directory (Folder).
                //imgInp.SaveAs(folderPath + Path.GetFileName(Id + "_" + imgInp.FileName));
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