using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Models
{
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }
        public int ArticleId { get; set; }
        public int AdministratorId { get; set; }
        [MaxLength(500)]
        public string Banner { get; set; }     
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public Administrator Administrator { get; set; }
        public Article Article { get; set; }
    }
}