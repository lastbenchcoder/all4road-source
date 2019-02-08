using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Models
{
    public class SecurityQuestions
    {
        [Key]
        public int SecurityQuestionsId { get; set; }
        [MaxLength(500)]
        [Index(IsUnique = true)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int InDisplay { get; set; }
    }
}