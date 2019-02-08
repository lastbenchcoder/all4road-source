using DDWBlogger.Project.Source.App_Data;
using DDWBlogger.Project.Source.Enums;
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
    public partial class ads : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Advertisement";
            if (!IsPostBack)
            {
                LoadBannerSize();
                Array eAds = Enum.GetValues(typeof(eAds));
                foreach (eAds sts in eAds)
                {
                    rdoAddType.Items.Add(new ListItem(sts.ToString()));
                }

                if (Request.QueryString["updateMode"] != null)
                {
                    if (Request.QueryString["updateMode"] == "200")
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Success! Ads Deleted Successfully.";
                    }
                    else if (Request.QueryString["updateMode"] == "404")
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Oops! Ads detail Failed to Delete No Ads Id found or Invalid.";
                    }
                    else
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Visible = false;
                        lblMessage.Text = "";
                    }
                }
            }
        }

        private void LoadBannerSize()
        {
            ddlSize.Items.Clear();
            List<Ads> Ads = new List<Ads>();
            List<AddSize> AddSize = new List<AddSize>();
            using (var context = new DBContext())
            {
                Ads = context.Ads.Include("AddSize").ToList();
                AddSize = context.AddSize.ToList();
                string[] asize = new string[100];
                for (int i = 0; i < Ads.Count; i++)
                {
                    asize[i] = Ads[i].AddSize.Title;
                }

                foreach (var item in AddSize)
                {
                    if (item.InDisplay == 1)
                    {
                        if (!asize.Contains(item.Title))
                        {
                            ddlSize.Items.Add(new ListItem { Text = item.Title, Value = item.AdSizeId.ToString() });
                        }
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int adminId = Convert.ToInt32(Session["AdminKey"].ToString());
            int adSizeId = Convert.ToInt32(ddlSize.SelectedValue);
            using (var context = new DBContext())
            {
                Administrator Administrator = context.Administrator.Where(m => m.AdministratorId == adminId).FirstOrDefault();
                AddSize AddSize = context.AddSize.Where(m => m.AdSizeId == adSizeId).FirstOrDefault();

                Ads Ads = new Ads()
                {
                    Type = rdoAddType.Text,
                    AdministratorId = Administrator.AdministratorId,
                    AdSizeId = AddSize.AdSizeId,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                };

                if (rdoAddType.Text == eAds.Banner.ToString())
                {
                    Upload(AddSize.Width, AddSize.Height);
                    Ads.Banner = "files/ads/" + imgInp.FileName;
                    Ads.RedirectUrl = "Not Required";
                }
                else
                {
                    Ads.Banner = txtScript.Text;
                    Ads.RedirectUrl = txtRedirectUrl.Text;
                }

                context.Ads.Add(Ads);
                context.SaveChanges();

                txtRedirectUrl.Text = "";
                txtScript.Text = "";
                ddlSize.SelectedIndex = 0;
                rdoAddType.ClearSelection();
                pnlImage.Visible = false;
                pnlScript.Visible = false;
                LoadBannerSize();

                pnlErrorMessage.Attributes.Remove("class");
                pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                pnlErrorMessage.Visible = true;
                lblMessage.Text = "Success! New Ad Successfully.";
            }
        }

        private void Upload(int width, int height)
        {
            try
            {
                string folderPath = Server.MapPath("~/files/ads/");
                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists. Create it.
                    Directory.CreateDirectory(folderPath);
                }

                Stream strm = imgInp.PostedFile.InputStream;
                using (var image = System.Drawing.Image.FromStream(strm))
                {
                    int newWidth = width; // New Width of Image in Pixel  
                    int newHeight = height; // New Height of Image in Pixel  
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

        protected void rdoAddType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (eAds.Banner.ToString() == rdoAddType.Text)
            {
                pnlImage.Visible = true;
                pnlScript.Visible = false;
            }
            else
            {
                pnlImage.Visible = false;
                pnlScript.Visible = true;
            }
        }
    }
}