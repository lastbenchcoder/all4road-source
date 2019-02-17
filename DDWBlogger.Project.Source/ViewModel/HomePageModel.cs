using DDWBlogger.Project.Source.App_Data;
using DDWBlogger.Project.Source.Enums;
using DDWBlogger.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.ViewModel
{
    public class HomePageModel
    {
        public HomePage HomePage { get; set; }
        public List<Category> Category { get; set; }
        public List<Ads> Ads { get; set; }
        public List<Menus> Menus { get; set; }
    }

    public class HomePageIndexModel
    {
        public HomePage HomePage { get; set; }
        public List<Slider> Slider { get; set; }
        public List<ArticleAndFeatures> ArticleAndFeatures { get; set; }
        public List<Article> Article { get; set; }
        public List<Article> ArticleCategory1 { get; set; }
        public List<Article> ArticleCategory2 { get; set; }
        public List<Ads> Ads { get; set; }
        public List<GalleryBanners> GalleryBanners { get; set; }
    }

    public class ArticleDetailPageModel
    {
        public HomePage HomePage { get; set; }
        public Article Article { get; set; }
        public List<Article> RelatedArticle { get; set; }
        public List<Ads> Ads { get; set; }
        public List<GalleryBanners> GalleryBanners { get; set; }
        public List<Category> Category { get; set; }
    }

    public class SideBar
    {
        public List<Ads> Ads { get; set; }
        public List<GalleryBanners> GalleryBanners { get; set; }
        public List<Category> Category { get; set; }
    }

    public class FEHomePage
    {
        public HomePageModel GetHomePageDetail()
        {
            HomePageModel HomePageModel = new HomePageModel();
            try
            {
                using (var context = new DBContext())
                {
                    int StatusId = context.Status.Where(m => m.Title == eStatus.Active.ToString()).FirstOrDefault().StatusId;
                    HomePageModel.HomePage = context.HomePage.FirstOrDefault();
                    HomePageModel.Category = context.Category.Include("SubCategory").Where(m => m.StatusId == StatusId).ToList();
                    HomePageModel.Ads = context.Ads.Include("AddSize").ToList();
                    HomePageModel.Menus = context.Menus.ToList();
                    return HomePageModel;
                }
            }
            catch
            {
                return HomePageModel;
            }            
        }

        public HomePageIndexModel GetIndexPageDetail()
        {
            HomePageIndexModel HomePageIndexModel = new HomePageIndexModel();
            try
            {
                using (var context = new DBContext())
                {
                    int articleStatusId = context.Status.Where(m => m.Title == eStatus.Published.ToString()).FirstOrDefault().StatusId;
                    HomePageIndexModel.HomePage = context.HomePage.FirstOrDefault();
                    HomePageIndexModel.Slider = context.Slider.ToList();
                    HomePageIndexModel.ArticleAndFeatures = context.ArticleAndFeatures.Include("ArticleAndTypes").Include("Article").ToList();
                    foreach (var item in HomePageIndexModel.ArticleAndFeatures)
                    {
                        item.Article.SubCategory = context.SubCategory.Where(m => m.SubCategoryId == item.Article.SubCategoryId).FirstOrDefault();
                    }
                    HomePageIndexModel.Article = context.Article.Include("SubCategory").Include("Administrator").Include("ReviewComment").Where(m => m.StatusId == articleStatusId).ToList();
                    HomePageIndexModel.ArticleCategory1 = context.Article.Include("SubCategory").Include("Administrator").Where(m => m.StatusId == articleStatusId && m.SubCategoryId == HomePageIndexModel.HomePage.CategoryId1).Take(2).ToList();
                    HomePageIndexModel.ArticleCategory2 = context.Article.Include("SubCategory").Include("Administrator").Where(m => m.StatusId == articleStatusId && m.SubCategoryId == HomePageIndexModel.HomePage.CategoryId2).Take(1).ToList();
                    HomePageIndexModel.Ads = context.Ads.Include("AddSize").ToList();
                    HomePageIndexModel.GalleryBanners = context.GalleryBanners.Include("Gallery").Take(4).ToList();
                    return HomePageIndexModel;
                }
            }
            catch
            {
                return HomePageIndexModel;
            }
        }

        public ArticleDetailPageModel GetArticleDetailPageDetail(int id)
        {
            ArticleDetailPageModel ArticleDetailPageModel = new ArticleDetailPageModel();
            try
            {
                using (var context = new DBContext())
                {
                    int articleStatusId = context.Status.Where(m => m.Title == eStatus.Published.ToString()).FirstOrDefault().StatusId;
                    int StatusId = context.Status.Where(m => m.Title == eStatus.Active.ToString()).FirstOrDefault().StatusId;
                    ArticleDetailPageModel.Article = context.Article.Include("SubCategory").Include("Administrator").Include("ReviewComment")
                        .Where(m => m.StatusId == articleStatusId && m.ArticleId == id).FirstOrDefault();
                    foreach (var item in ArticleDetailPageModel.Article.ReviewComment)
                    {
                        item.ReplyReviewComment = context.ReplyReviewComment.Where(m => m.ReviewCommentId == item.ReviewCommentId).ToList();
                    }
                    ArticleDetailPageModel.RelatedArticle = context.Article.Include("SubCategory").Include("Administrator").Where(m => m.StatusId == articleStatusId &&
                     m.SubCategory.SubCategoryId == ArticleDetailPageModel.Article.SubCategory.SubCategoryId &&
                     m.ArticleId != id).ToList();
                    ArticleDetailPageModel.Ads = context.Ads.Include("AddSize").ToList();
                    ArticleDetailPageModel.GalleryBanners = context.GalleryBanners.Include("Gallery").Take(4).ToList();
                    ArticleDetailPageModel.Category = context.Category.Include("SubCategory").Where(m => m.StatusId == StatusId).ToList();
                    return ArticleDetailPageModel;
                }
            }
            catch
            {
                return ArticleDetailPageModel;
            }            
        }

        public SideBar GetSideBarDetail()
        {
            SideBar SideBarModel = new SideBar();
            try
            {
                using (var context = new DBContext())
                {
                    int StatusId = context.Status.Where(m => m.Title == eStatus.Active.ToString()).FirstOrDefault().StatusId;
                    SideBarModel.Ads = context.Ads.Include("AddSize").ToList();
                    SideBarModel.GalleryBanners = context.GalleryBanners.Include("Gallery").Take(4).ToList();
                    SideBarModel.Category = context.Category.Include("SubCategory").Where(m => m.StatusId == StatusId).ToList();
                    return SideBarModel;
                }
            }
            catch
            {
                return SideBarModel;
            }
        }
    }
}