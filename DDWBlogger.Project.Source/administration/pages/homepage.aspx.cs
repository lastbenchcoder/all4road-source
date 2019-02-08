using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DDWBlogger.Project.Source.App_Data;
using DDWBlogger.Project.Source.Models;
using System.IO;

namespace DDWBlogger.Project.Source.administration.pages
{
    public partial class homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Home Page Detail";
            if (!IsPostBack)
            {
                LoadDetail();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new DBContext())
                {
                    HomePage _appData1 = context.HomePage.FirstOrDefault();
                    if (_appData1 == null)
                    {
                        _appData1 = new HomePage();
                    }

                    _appData1.AdministratorId = Convert.ToInt32(Session["AdminKey"].ToString());
                    _appData1.MetaTitle = txtTitle.Text;
                    _appData1.MetaDescription = txtDescription.Text;
                    _appData1.MetaKeyWords = txtSearchKeywords.Text;
                    if (imgInp.HasFile)
                    {
                        _appData1.Logo = "files/application/" + imgInp.FileName;
                        Upload();
                    }
                    _appData1.EmailId = (txtEmailId.Text != "") ? txtEmailId.Text : "admin@rachnateracotta.com";
                    _appData1.Phone = (txtPhone.Text != "") ? txtPhone.Text : "0000000000";
                    _appData1.DisplayTopMenuBar = (chkHomeTopBar.Checked == true) ? 1 : 0;
                    _appData1.Display_468_60 = (chkDisplay_468_60.Checked == true) ? 1 : 0;
                    _appData1.Display_250_250 = (chkDisplay_250_250.Checked == true) ? 1 : 0;
                    _appData1.DisplaySlider = (chkSlider.Checked == true) ? 1 : 0;
                    _appData1.DisplayFeatured = (chkDisplayFeatured.Checked == true) ? 1 : 0;
                    _appData1.DisplayBest = (chkDisplayBest.Checked == true) ? 1 : 0;
                    _appData1.CategoryId1 = Convert.ToInt32(ddlCatSubCat1.SelectedValue);
                    _appData1.CategoryId2 = Convert.ToInt32(ddlCatSubCat2.SelectedValue);
                    _appData1.Facebook = (txtFacebook.Text != "") ? txtFacebook.Text : "facebook";
                    _appData1.GooglePlus = (txtGoogle.Text != "") ? txtGoogle.Text : "google";
                    _appData1.Twitter = (txtTwitter.Text != "") ? txtTwitter.Text : "twitter";
                    _appData1.Pintrest = (txtPintrest.Text != "") ? txtPintrest.Text : "pintrest";
                    _appData1.Youtube = (txtYoutube.Text != "") ? txtYoutube.Text : "youtube";
                    _appData1.CopyrightMesssage = (txtCopyRight.Text != "") ? txtCopyRight.Text : "All4Roads All Rights Reserved";
                    _appData1.DateCreated = (_appData1.HomePageId != 0) ? _appData1.DateCreated : DateTime.Now;
                    _appData1.DateUpdated = DateTime.Now;

                    if (_appData1.HomePageId != 0)
                    {
                        context.Entry(_appData1).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        context.HomePage.Add(_appData1);
                    }
                    context.SaveChanges();
                    LoadDetail();
                    pnlErrorMessage.Attributes.Remove("class");
                    pnlErrorMessage.Attributes["class"] = "alert alert-success alert-dismissable";
                    pnlErrorMessage.Visible = true;
                    lblMessage.Text = "Application Detail Updated Successfully.";
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

        private void Upload()
        {
            try
            {
                using (var context = new DBContext())
                {
                    int iFileSize = imgInp.PostedFile.ContentLength;
                    if (iFileSize < 1048576)  // 1MB
                    {
                        string folderPath = Server.MapPath("~/files/application/");

                        HomePage _appData = context.HomePage.FirstOrDefault();
                        var logoPath = (_appData != null) ? _appData.Logo : "No Image";
                        FileInfo file = new FileInfo("~/" + logoPath);
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

                        //Save the File to the Directory (Folder).
                        imgInp.SaveAs(folderPath + Path.GetFileName(imgInp.FileName));
                    }
                    else
                    {
                        pnlErrorMessage.Attributes.Remove("class");
                        pnlErrorMessage.Attributes["class"] = "alert alert-danger alert-dismissable";
                        pnlErrorMessage.Visible = true;
                        lblMessage.Text = "Oops!! Selected banner should not be higher than 1MB.";
                    }
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

        private void LoadDetail()
        {
            using (var context = new DBContext())
            {
                List<SubCategory> SubCategory = new List<SubCategory>();
                SubCategory = context.SubCategory.Include("Category").Include("Status").ToList();
                foreach (var item in SubCategory)
                {
                    if (item.Status.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString())
                    {
                        ddlCatSubCat1.Items.Add(new ListItem { Text = item.Title + "(" + item.Category.Title + ")", Value = item.SubCategoryId.ToString() });
                        ddlCatSubCat2.Items.Add(new ListItem { Text = item.Title + "(" + item.Category.Title + ")", Value = item.SubCategoryId.ToString() });
                    }
                }

                HomePage _appData = context.HomePage.FirstOrDefault();
                if (_appData != null)
                {
                    txtTitle.Text = _appData.MetaTitle;
                    txtDescription.Text = _appData.MetaDescription;
                    txtSearchKeywords.Text = _appData.MetaKeyWords;
                    imgProduct.ImageUrl = "../../" + _appData.Logo;
                    txtEmailId.Text = _appData.EmailId;
                    txtPhone.Text = _appData.Phone;
                    chkHomeTopBar.Checked = (_appData.DisplayTopMenuBar == 1) ? true : false;
                    chkDisplay_468_60.Checked = (_appData.Display_468_60 == 1) ? true : false;
                    chkDisplay_250_250.Checked = (_appData.Display_250_250 == 1) ? true : false;
                    chkSlider.Checked = (_appData.DisplaySlider == 1) ? true : false;
                    chkDisplayFeatured.Checked = (_appData.DisplayFeatured == 1) ? true : false;
                    chkDisplayBest.Checked = (_appData.DisplayBest == 1) ? true : false;
                    ddlCatSubCat1.SelectedValue = _appData.CategoryId1.ToString();
                    ddlCatSubCat2.SelectedValue = _appData.CategoryId2.ToString();
                    txtFacebook.Text = _appData.Facebook;
                    txtTwitter.Text = _appData.Twitter;
                    txtGoogle.Text = _appData.GooglePlus;
                    txtPintrest.Text = _appData.Pintrest;
                    txtYoutube.Text = _appData.Youtube;
                    txtCopyRight.Text = _appData.CopyrightMesssage;
                    hdnAppId.Value = _appData.HomePageId.ToString();
                }
            }
        }
    }
}