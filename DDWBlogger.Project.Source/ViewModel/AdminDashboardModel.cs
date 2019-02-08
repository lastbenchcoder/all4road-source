using DDWBlogger.Project.Source.App_Data;
using DDWBlogger.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.ViewModel
{
    public class AdminDashboardModel
    {
        public Administrator Administrator { get; set; }
        public List<Invitation> Invitation { get; set; }
        public int totAdministrator { get; set; }
        public int totInvitation { get; set; }
        public int totCategory { get; set; }
        public int totSubCategory { get; set; }
        public int totArticle { get; set; }
        public int totReviewComment { get; set; }
        public List<Article> Article { get; set; }
    }

    public class AdminDashBoard
    {
        public DBContext DBContext;
        public AdminDashBoard()
        {
            DBContext = new DBContext();
        }
        public AdminDashboardModel GetDashboard(int adminId)
        {
            AdminDashboardModel adm = new AdminDashboardModel();

            Administrator Administrator = DBContext.Administrator.Include("Role").Where(m => m.AdministratorId == adminId).FirstOrDefault();

            if (Administrator.Role.Title == "Super")
            {
                adm.Administrator = DBContext.Administrator.Include("Role").Where(m => m.AdministratorId == adminId).FirstOrDefault();
                adm.Invitation = DBContext.Invitation.Include("Role").Include("Status").ToList();
                adm.totInvitation = DBContext.Invitation.ToList().Count();
                adm.totAdministrator = DBContext.Administrator.ToList().Count();
                adm.totCategory = DBContext.Category.ToList().Count();
                adm.totSubCategory = DBContext.SubCategory.ToList().Count();
                adm.totArticle = DBContext.Article.ToList().Count();
                adm.totReviewComment = DBContext.ReviewComment.ToList().Count();
            }
            else
            {
                adm.Administrator = DBContext.Administrator.Include("Role").Where(m => m.AdministratorId == adminId).FirstOrDefault();
                adm.totArticle = DBContext.Article.Where(m => m.AdministratorId == adminId).ToList().Count();
                adm.Article = DBContext.Article.Include("Administrator").Include("SubCategory").Include("ReviewComment").Include("Status").Where(m => m.AdministratorId == adminId).ToList();
                foreach (var item in adm.Article)
                {
                    item.SubCategory.Category = DBContext.Category.Where(m => m.CategoryId == item.SubCategory.CategoryId).FirstOrDefault();
                }
            }

            return adm;
        }
    }
}