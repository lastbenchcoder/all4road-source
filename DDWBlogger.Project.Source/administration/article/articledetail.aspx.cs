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

namespace DDWBlogger.Project.Source.administration.article
{
    public partial class articledetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["articleid"] != null && Session["AdminKey"] != null)
                {
                    Article Article = null;
                    List<SubCategory> SubCategory = new List<SubCategory>();
                    using (var context = new DBContext())
                    {
                        SubCategory = context.SubCategory.Include("Category").Include("Status").ToList();
                        foreach (var item in SubCategory)
                        {
                            if (item.Status.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString())
                            {
                                ddlCatSubCat.Items.Add(new ListItem { Text = item.Title + "(" + item.Category.Title + ")", Value = item.SubCategoryId.ToString() });
                            }
                        }

                        int loginAdminId = Convert.ToInt32(Session["AdminKey"].ToString());
                        Administrator loginAdministrator = context.Administrator.Include("Role").Where(m => m.AdministratorId == loginAdminId).FirstOrDefault();

                        if (loginAdministrator.Role.Title == "Super")
                        {
                            pnlRole.Visible = true;
                            List<Status> Status = context.Status.Where(m => m.InDisplay == 1 && m.StatusFor == "Articles").ToList();
                            foreach (var item in Status)
                            {
                                ddlStatus.Items.Add(new ListItem { Text = item.Title, Value = item.StatusId.ToString() });
                            }
                        }
                        int articleId = Convert.ToInt32(Request.QueryString["articleid"].ToString());
                        Article = context.Article.Where(m => m.ArticleId == articleId).FirstOrDefault();
                        ddlCatSubCat.SelectedValue = Article.SubCategoryId.ToString();
                        ddlStatus.SelectedValue = Article.StatusId.ToString();
                        txtTitle.Text = Article.Title;
                        lblBcTitle.Text = Article.Title;
                        txtDescription.Text = Article.Description;
                        imgProduct.ImageUrl = "../../" + Article.FeaturedBanner;
                        hdnArticleId.Value = Article.ArticleId.ToString();
                        this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Article Update " + Article.Title;
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int loginAdminId = Convert.ToInt32(Session["AdminKey"].ToString());
                using (var context = new DBContext())
                {
                    Administrator loginAdministrator = context.Administrator.Include("Role").Where(m => m.AdministratorId == loginAdminId).FirstOrDefault();

                    int articleId = Convert.ToInt32(hdnArticleId.Value.ToString());
                    Article Article = context.Article.Where(m => m.ArticleId == articleId).FirstOrDefault();

                    Article.SubCategoryId = Convert.ToInt32(ddlCatSubCat.SelectedValue);
                    Article.Title = txtTitle.Text;
                    Article.Description = txtDescription.Text;
                    if (loginAdministrator.Role.Title == "Super")
                    {
                        Article.StatusId = context.Status.Where(m => m.Title == DDWBlogger.Project.Source.Enums.eStatus.Published.ToString()).FirstOrDefault().StatusId;
                    }
                    else
                    {
                        Article.StatusId = context.Status.Where(m => m.Title == "Submitted").FirstOrDefault().StatusId;
                    }
                    Article.AdministratorId = loginAdministrator.AdministratorId;
                    Article.DateUpdated = DateTime.Now;


                    if (imgInp.HasFile)
                    {
                        Article.FeaturedBanner = "files/Article/" + Article.ArticleId.ToString() + "/" + imgInp.FileName;
                        string path = Server.MapPath("../" + Article.FeaturedBanner);
                        FileInfo file = new FileInfo(path);
                        if (file.Exists)//check file exsit or not
                        {
                            file.Delete();
                        }
                        Upload(Article.ArticleId.ToString());
                    }

                    context.Entry(Article).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();

                    Response.Redirect("/administration/article/articles.aspx?articleUpdate=200&redirect-url=uyiretieyt7985798435ihtiuertireyte&id-red=alladmin.html");
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
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = ex.Message;
            }
        }
    }
}