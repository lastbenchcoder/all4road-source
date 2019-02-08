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

namespace DDWBlogger.Project.Source.administration
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["adminid"] != null)
            {
                if (!IsPostBack)
                {
                    hdnAdminId.Value = Request.QueryString["adminid"].ToString();
                    loadDetail();
                }

                this.Title = ConfigurationSettings.AppSettings["AppName"].ToString() + " : Profile Update";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new DBContext())
                {
                    int adminId = Convert.ToInt32(hdnAdminId.Value);
                    Administrator _admin = context.Administrator.Include("Role").Where(m => m.AdministratorId == adminId).FirstOrDefault();

                    int loginAdminId = Convert.ToInt32(Session["AdminKey"].ToString());
                    Administrator loginAdministrator = context.Administrator.Include("Role").Where(m => m.AdministratorId == loginAdminId).FirstOrDefault();

                    _admin.FirstName = txtFirstName.Text;
                    _admin.LastName = txtLastName.Text;
                    _admin.EmailId = txtEmailId.Text;
                    _admin.LoginId = txtLoginId.Text;
                    _admin.Description = txtDescription.Text;
                    _admin.PhoneNo = txtPhone.Text;
                    _admin.SecurityQuestion = ddlSecQuestion.SelectedItem.Text;
                    _admin.SecurityAnswer = txtAnswer.Text;
                    if (loginAdministrator.Role.Title == "Super")
                    {
                        _admin.RoleId = Convert.ToInt32(ddlRole.SelectedValue);
                    }
                    _admin.Banner = _admin.Banner;
                    if (imgInp.HasFile)
                    {
                        if (imgInp.HasFile)
                        {
                            string path = Server.MapPath("../" + _admin.Banner);
                            FileInfo file = new FileInfo(path);
                            if (file.Exists)//check file exsit or not
                            {
                                file.Delete();
                            }
                            Upload(_admin.AdministratorId.ToString());
                        }

                        _admin.Banner = "files/administrators/" + "Admin_" + _admin.AdministratorId + ".png";
                        context.Entry(_admin).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                    else
                    {
                        _admin.DateUpdated = DateTime.Now;
                        context.Entry(_admin).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                    Response.Redirect("/administration/admin/alladmin.aspx?admUpdate=100&redirect-url=uyiretieyt7985798435ihtiuertireyte&id-red=alladmin.html");
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

        private void loadDetail()
        {            
            using (var context = new DBContext())
            {
                int loginAdminId = Convert.ToInt32(Session["AdminKey"].ToString());
                Administrator loginAdministrator = context.Administrator.Include("Role").Where(m => m.AdministratorId == loginAdminId).FirstOrDefault();

                List<Role> Role = new List<Role>();
                Role = context.Role.ToList();
                foreach (var item in Role)
                {
                    if (item.InDisplay == 1)
                    {
                        ddlRole.Items.Add(new ListItem { Text = item.Title, Value = item.RoleId.ToString() });
                    }
                }

                List<SecurityQuestions> SecurityQuestions = new List<SecurityQuestions>();
                SecurityQuestions = context.SecurityQuestions.ToList();
                foreach (var item in SecurityQuestions)
                {
                    if (item.InDisplay == 1)
                    {
                        ddlSecQuestion.Items.Add(new ListItem { Text = item.Title, Value = item.SecurityQuestionsId.ToString() });
                    }
                }
                int adminId = Convert.ToInt32(hdnAdminId.Value);
                Administrator Administrator = context.Administrator.Include("Role").Include("Status").Where(m => m.AdministratorId == adminId).FirstOrDefault();
                lblBcTitle.Text = Administrator.FirstName + " " + Administrator.LastName;
                txtFirstName.Text = Administrator.FirstName;
                txtLastName.Text = Administrator.LastName;
                txtEmailId.Text = Administrator.EmailId;
                txtPhone.Text = Administrator.PhoneNo;
                txtLoginId.Text = Administrator.LoginId;
                txtDescription.Text = Administrator.Description;
                imgProduct.ImageUrl = "../../" + Administrator.Banner;
                ddlRole.SelectedValue = Administrator.RoleId.ToString();
                ddlSecQuestion.SelectedValue = context.SecurityQuestions
                    .Where(m=>m.Title==Administrator.SecurityQuestion)
                    .FirstOrDefault().SecurityQuestionsId.ToString();
                txtAnswer.Text = Administrator.SecurityAnswer.ToString();
                pnlRole.Visible = false;
                if (loginAdministrator.Role.Title == "Super")
                {
                    pnlRole.Visible = true;
                }
                if (Administrator.Status.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString())
                {
                    lblStatus.Attributes.Remove("class");
                    lblStatus.Attributes["class"] = "label label-success";
                    lblStatus.Text = Administrator.Status.Title;
                }
                else
                {
                    lblStatus.Attributes.Remove("class");
                    lblStatus.Attributes["class"] = "label label-danger";
                    lblStatus.Text = Administrator.Status.Title;
                }
            }
        }

        private void Upload(string Id)
        {
            try
            {
                using (var context = new DBContext())
                {
                    string folderPath = Server.MapPath("~/files/administrators/");
                    int adminId = Convert.ToInt32(hdnAdminId.Value);
                    Administrator Administrator = context.Administrator.Include("Role").Where(m => m.AdministratorId == adminId).FirstOrDefault();

                    //Check whether Directory (Folder) exists.
                    if (!Directory.Exists(folderPath))
                    {
                        //If Directory (Folder) does not exists. Create it.
                        Directory.CreateDirectory(folderPath);
                    }

                    Stream strm = imgInp.PostedFile.InputStream;
                    using (var image = System.Drawing.Image.FromStream(strm))
                    {
                        int newWidth = 120; // New Width of Image in Pixel  
                        int newHeight = 120; // New Height of Image in Pixel  
                        var thumbImg = new Bitmap(newWidth, newHeight);
                        var thumbGraph = Graphics.FromImage(thumbImg);
                        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                        thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        var imgRectangle = new Rectangle(0, 0, newWidth, newHeight);
                        thumbGraph.DrawImage(image, imgRectangle);
                        // Save the file  
                        string targetPath = folderPath + "Admin_" + Administrator.AdministratorId + ".png";
                        thumbImg.Save(targetPath, image.RawFormat);

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
    }
}