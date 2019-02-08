using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Models
{
    public class EmailSubscriptions
    {
        [Key]
        public int EmailSubscriptionsId { get; set; }
        [MaxLength(300)]
        public string FullName { get; set; }
        [MaxLength(300)]
        public string EmailId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int StatusId { get; set; }

        public Status Status { get; set; }
    }
}