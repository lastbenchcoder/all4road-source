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

        public ActionResult ContactUs()
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

        public ActionResult Author(int id)
        {
            ViewBag.AuthorId = id.ToString();
            return View();
        }

        public ActionResult Mypages(int q)
        {
            ViewBag.PageId = q.ToString();
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

        public ActionResult ArticleSearch(string s)
        {
            ViewBag.SearchKey = s;
            return View();
        }

        public ActionResult Success(string s)
        {
            ViewBag.SuccessMessage = s;
            return View();
        }

        public ActionResult Subscribe(string emailid)
        {
            string result = string.Empty;
            using (var ctx = new DBContext())
            {
                EmailSubscriptions _subscribeUser = ctx.EmailSubscriptions.Where(m => m.EmailId == emailid).FirstOrDefault();
                if (_subscribeUser == null)
                {
                    EmailSubscriptions _subscr = new EmailSubscriptions()
                    {
                        EmailId = emailid,
                        StatusId = ctx.Status.Where(m => m.Title == eStatus.Active.ToString()).FirstOrDefault().StatusId,
                        DateCreated = DateTime.Now,
                        DateUpdated = DateTime.Now
                    };

                    ctx.EmailSubscriptions.Add(_subscr);
                    ctx.SaveChanges();
                    result = "Thank you for sbscribing our news letter! we have triggered a email to you. Please activate the subscription by clicking on the link.";
                }
                else
                {
                    result = "Oops!! Entered Email Id already exists with us.";
                }
            }
            return Redirect("/home/Success?s=" + result);
        }

        public ActionResult CustomerRequest(CustomerRequest customerRequest)
        {
            string result = string.Empty;
            using (var ctx = new DBContext())
            {
                CustomerRequest _customerRequest = new CustomerRequest()
                {
                    FullName = customerRequest.FullName,
                    EmailId = customerRequest.EmailId,
                    Subject = customerRequest.Subject,
                    Description = customerRequest.Description,
                    IpAddress = IpAddress.GetLocalIPAddress(),
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now
                };

                ctx.CustomerRequest.Add(_customerRequest);
                ctx.SaveChanges();
                result = "Thank you for submitting your request we will work on your request.";
            }
            return Redirect("/home/Success?s=" + result);
        }
    }
}