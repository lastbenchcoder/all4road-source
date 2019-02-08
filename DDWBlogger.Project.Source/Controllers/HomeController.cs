using DDWBlogger.Project.Source.App_Data;
using DDWBlogger.Project.Source.Enums;
using DDWBlogger.Project.Source.Helper;
using DDWBlogger.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDWBlogger.Project.Source.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ArticlesByCategory(int id)
        {
            ViewBag.CategoryId = id.ToString();
            return View();
        }

        public ActionResult ArticlesBySubCategory(int id)
        {
            ViewBag.SubCategoryId = id.ToString();
            return View();
        }

        public ActionResult ArticleDetail(int id)
        {
            ViewBag.Id = id.ToString();
            return View();
        }

        [ValidateInput(false)]
        public ActionResult ArticleComments(string articleId, string rating, string EmailId, string FullName, string likeunlike, string description)
        {
            int articleIdSelected = Convert.ToInt32(articleId);
            ReviewComment Comments = new ReviewComment()
            {
                IpAddress = IpAddress.GetLocalIPAddress(),
                EmailId = EmailId,
                FullName = FullName,
                ArticleId = articleIdSelected,
                CommentDescription = description,
                Rating = Convert.ToInt32(rating),
                Like = 1,
                StatusId = Convert.ToInt32(eStatus.InActive),
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };
            using (var context = new DBContext())
            {
                context.ReviewComment.Add(Comments);
                context.SaveChanges();
            }
            return Redirect("/home/articledetail?id=" + articleId + "&pageurl=JGJHGJH3wr2353253453hbjhbjh3j45jkh345kj34h5k");
        }

        [ValidateInput(false)]
        public ActionResult ArticleCommentsReply(string articleId, string rating, string EmailId, string FullName, string likeunlike, string description, string commentId)
        {
            int commentIdSel = Convert.ToInt32(commentId);
            ReplyReviewComment Comments = new ReplyReviewComment()
            {
                IpAddress = IpAddress.GetLocalIPAddress(),
                EmailId = EmailId,
                FullName = FullName,
                ReviewCommentId = commentIdSel,
                CommentDescription = description,
                Rating = Convert.ToInt32(rating),
                Like = 1,
                StatusId = Convert.ToInt32(eStatus.InActive),
                DateCreated = DateTime.Now,
                DateUpdated = DateTime.Now
            };
            using (var context = new DBContext())
            {
                context.ReplyReviewComment.Add(Comments);
                context.SaveChanges();
            }
            return Redirect("/home/articledetail?id=" + articleId + "&pageurl=JGJHGJH3wr2353253453hbjhbjh3j45jkh345kj34h5k");
        }
    }
}