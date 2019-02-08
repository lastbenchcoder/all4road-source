using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int InDisplay { get; set; }
    }
}