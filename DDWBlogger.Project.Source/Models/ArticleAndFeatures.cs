using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Models
{
    public class ArticleAndFeatures
    {
        [Key]
        public int ArticleAndFeaturesId { get; set; }
        public int AdministratorId { get; set; }
        public int ArticleId { get; set; }
        public int ArticleAndTypesId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public Article Article { get; set; }
        public ArticleAndTypes ArticleAndTypes { get; set; }
        public Administrator Administrator { get; set; }
    }
}