using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Models
{
    public class ReviewComment
    {
        [Key]
        public int ReviewCommentId { get; set; }
        [MaxLength(30)]
        public string IpAddress { get; set; }
        [MaxLength(300)]
        public string FullName { get; set; }       
        [MaxLength(300)]
        public string EmailId { get; set; }
        [MaxLength(500)]
        public string CommentDescription { get; set; }
        public int Like { get; set; }
        public int Rating { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int ArticleId { get; set; }
        public int StatusId { get; set; }

        public Status Status { get; set; }
        public Article Article { get; set; }
        public ICollection<ReplyReviewComment> ReplyReviewComment { get; set; }
    }
}