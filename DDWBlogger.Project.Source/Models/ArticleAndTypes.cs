using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Models
{
    public class ArticleAndTypes
    {
        [Key]
        public int ArticleAndTypesId { get; set; }
        [MaxLength(100)]
        [Index(IsUnique = true)]
        public string Type { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public int ArticleCount { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int InDisplay { get; set; }
    }
}