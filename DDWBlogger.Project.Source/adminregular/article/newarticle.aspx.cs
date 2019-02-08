using DDWBlogger.Project.Source.App_Data;
using DDWBlogger.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDWBlogger.Project.Source.adminregular.article
{
    public partial class newarticle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : New Article";
            if (!IsPostBack)
            {
                if(Request.QueryString["title"]!=null)
                {
                    txtTitle.Text = Request.QueryString["title"].ToString();
                }
                List<SubCategory> SubCategory = new List<SubCategory>();
                using (var context = new DBContext())
                {
                    SubCategory = context.SubCategory.Include("Category").Include("Status").ToList();
                    foreach (var item in SubCategory)
                    {
                        if (item.Status.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString())
                        {
                            ddlCatSubCat.Items.Add(new ListItem { Text = item.Title + "(" + item.Category.Title + ")", Value = item.StatusId.ToString() });
                        }
                    }
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int adminId = Convert.ToInt32(Session["RgAdminKey"].ToString());
                using (var context = new DBContext())
                {
                    Administrator Administrator = context.Administrator.Where(m => m.AdministratorId == adminId).FirstOrDefault();
                    Article Article = new Article
                    {
                        SubCategoryId = Convert.ToInt32(ddlCatSubCat.SelectedValue),
                        Title = txtTitle.Text,
                        Description = txtDescription.Text,
                        StatusId = context.Status.Where(m => m.Title == DDWBlogger.Project.Source.Enums.eStatus.Submitted.ToString() && m.StatusFor== "Articles").FirstOrDefault().StatusId,
                        AdministratorId = Administrator.AdministratorId,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now,
                        FeaturedBanner = "content/noimage.png"
                    };

                    context.Article.Add(Article);
                    context.SaveChanges();

                    if (Article.ArticleId != null && Article.ArticleId != 0)
                    {
                        if (imgInp.HasFile)
                        {                            
                            Upload(Article.ArticleId.ToString());
                            Article.FeaturedBanner = "files/Article/" + Article.ArticleId.ToString() + "/" + imgInp.FileName;
                            context.Entry(Article).State = System.Data.Entity.EntityState.Modified;
                            context.SaveChanges();
                        }
                    }

                    Response.Redirect("/adminregular/dashboard.aspx?articleUpdate=100&redirect-url=uyiretieyt7985798435ihtiuertireyte&id-red=alladmin.html");
                }
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }
        }

        private void Upload(string Id)
        {
            try
            {
                string folderPath = Server.MapPath("~/files/Article/" + Id + "/");
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
                lblMessage.Text = "Oops!! Server error occured, please contact administrator.";
            }
        }
    }
}