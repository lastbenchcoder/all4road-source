using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        [MaxLength(300)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        [MaxLength(300)]
        public string FeaturedBanner { get; set; }
        public int StatusId { get; set; }
        public int AdministratorId { get; set; }
        public int SubCategoryId { get; set; }

        public SubCategory SubCategory { get; set; }
        public Status Status { get; set; }
        public Administrator Administrator { get; set; }
        public ICollection<ReviewComment> ReviewComment { get; set; }
    }
}