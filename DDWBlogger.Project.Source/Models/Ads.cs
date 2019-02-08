using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Models
{
    public class Ads
    {
        [Key]
        public int AdsId { get; set; }
        public int AdSizeId { get; set; }
        [MaxLength(50)]
        public string Type { get; set; }
        public int AdministratorId { get; set; }
        [MaxLength(500)]
        public string Banner { get; set; }
        [MaxLength(500)]
        public string RedirectUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public AddSize AddSize { get; set; }
        public Administrator Administrator { get; set; }
    }
}