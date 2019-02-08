using DDWBlogger.Project.Source.App_Data;
using DDWBlogger.Project.Source.Helper;
using DDWBlogger.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDWBlogger.Project.Source.administration.home
{
    public partial class galleryphotos : System.Web.UI.Page
    {
        private DBContext context;
        public galleryphotos()
        {
            context = new DBContext();
        }
        private string _prdId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Gallery Banner";
            if (Request.QueryString["Galleryid"] != null)
            {
                if (!IsPostBack)
                {
                    string _prdId = Request.QueryString["Galleryid"].ToString();
                    hdnGalleryId.Value = _prdId;
                    LoadGrid();
                }
            }
            else
            {
                Response.Redirect("/administration/default.aspx?id=1003&redirecturl=admin-home-RachnaTeracotta");
            }
        }

        private void LoadGrid()
        {
            int prdId = Convert.ToInt32(hdnGalleryId.Value);
            Gallery Gallery = context.Gallery.Where(m => m.GalleryId == prdId).FirstOrDefault();
            lblBcTitle.Text = Gallery.Title;
            List<GalleryBanners> _banners = context.GalleryBanners.Where(m => m.GalleryId == prdId).ToList();
            if (_banners.Count > 4)
            {
                pnlCreateBanner.Visible = false;
            }
            else
            {
                pnlCreateBanner.Visible = true;
            }
            grdPrdSlider.DataSource = _banners;
            grdPrdSlider.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string result = Upload(hdnGalleryId.Value);
            if (result == "100")
            {
                int prdId = Convert.ToInt32(hdnGalleryId.Value);
                GalleryBanners currentBanner = context.GalleryBanners.Where(m => m.GalleryId == prdId).FirstOrDefault();
                GalleryBanners Gallery = new GalleryBanners()
                {
                    GalleryId = Convert.ToInt32(hdnGalleryId.Value),
                    Gallery_Banner_Photo = "files/Gallery/" + hdnGalleryId.Value + "/" + hdnGalleryId.Value + "_" + imgInp.FileName,
                    AdministratorId = Convert.ToInt32(Session["AdminKey"].ToString()),
                    Gallery_Banner_Default = Convert.ToInt32(ddlStatus.SelectedValue),
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };

                if (Gallery.Gallery_Banner_Default == 1)
                {
                    List<GalleryBanners> Gallerybnrs = context.GalleryBanners.Where(m => m.GalleryId == prdId).ToList();
                    foreach (var item in Gallerybnrs)
                    {
                        item.Gallery_Banner_Default = 0;
                        context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
                else
                {
                    if (currentBanner == null)
                    {
                        Gallery.Gallery_Banner_Default = 1;
                    }
                }

                context.GalleryBanners.Add(Gallery);
                context.SaveChanges();

                LoadGrid();
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Success!!! Banner Created Successfully.";
                ddlStatus.SelectedIndex = 0;
            }
        }
        private string Upload(string Id)
        {
            try
            {
                int iFileSize = imgInp.PostedFile.ContentLength;
                if (iFileSize < 1048576)  // 1MB
                {
                    string folderPath = Server.MapPath("~/files/Gallery/" + Id + "/");

                    FileInfo file = new FileInfo(folderPath + imgInp.FileName);
                    if (file.Exists)
                    {
                        file.Delete();
                    }

                    //Check whether Directory (Folder) exists.
                    if (!Directory.Exists(folderPath))
                    {
                        //If Directory (Folder) does not exists. Create it.
                        Directory.CreateDirectory(folderPath);
                    }

                    Bitmap bmpPostedImage = new Bitmap(imgInp.PostedFile.InputStream);

                    //Save the File to the Directory (Folder).
                    //imgInp.SaveAs(folderPath + Path.GetFileName(Id + "_" + imgInp.FileName));

                    ImageHandler imghndle = new ImageHandler();

                    imghndle.Save(bmpPostedImage, Convert.ToInt32(ConfigurationSettings.AppSettings["GalleryImageWidth"].ToString()), Convert.ToInt32(ConfigurationSettings.AppSettings["GalleryImageHight"].ToString()), 0, (folderPath + Path.GetFileName(Id + "_" + imgInp.FileName)));

                    return "100";
                }
                else
                {
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Oops!! Selected banner should not be higher than 1MB.";
                    return "404";
                }
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! Server error occured, please contact administrator.";
                return "500";
            }
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int GalId = Convert.ToInt32(hdnGalleryId.Value);
                using (var ctx = new DBContext())
                {
                    GalleryBanners _banner = ctx.GalleryBanners.ToList().Where(m => m.Gallery_Banner_Id == GalId).FirstOrDefault();
                    string filePath = Server.MapPath("~/" + _banner.Gallery_Banner_Photo);
                    if (!filePath.Contains("noimage.png"))
                    {
                        FileInfo file = new FileInfo(filePath);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                    ctx.Entry(_banner).State = EntityState.Deleted;
                    ctx.SaveChanges();

                    GalleryBanners currentBanner = ctx.GalleryBanners.ToList().Where(m => m.GalleryId == GalId).FirstOrDefault();
                    if (currentBanner != null)
                    {
                        currentBanner.Gallery_Banner_Default = 1;
                        ctx.Entry(currentBanner).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                    }
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Gallery Slider Deleted Successfully.";
                    LoadGrid();
                }
            }
            catch (Exception ex)
            {
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Oops!! Server error occured, please contact administrator.";
            }
        }

        protected void Gallery_Command(Object sender, CommandEventArgs e)
        {
            String GalleryID = e.CommandArgument.ToString();
            string result = SetDefaultImage(GalleryID);
        }

        public string SetDefaultImage(string id)
        {
            using (var ctx = new DBContext())
            {
                List<GalleryBanners> Gallerybnrs = ctx.GalleryBanners.ToList().Where(f => f.GalleryId == Convert.ToInt32(hdnGalleryId.Value)).ToList();
                foreach (var item in Gallerybnrs)
                {
                    item.Gallery_Banner_Default = 0;
                    ctx.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                }

                GalleryBanners _banner = ctx.GalleryBanners.ToList().Where(m => m.Gallery_Banner_Id == Convert.ToInt32(id)).FirstOrDefault();
                _banner.Gallery_Banner_Default = 1;
                ctx.Entry(_banner).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Banner Updated Successfully.";
            }
            LoadGrid();
            return "";
        }
        protected void btnSearchPrdHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("/administration/home/Gallerydetail.aspx?galid=" + hdnGalleryId.Value);
        }
    }
}