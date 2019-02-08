using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Models
{
    public class GalleryBanners
    {
        [Key]
        public int Gallery_Banner_Id { get; set; }
        public int GalleryId { get; set; }
        public int AdministratorId { get; set; }
        public int Gallery_Banner_Default { get; set; }
        [MaxLength(450)]
        public string Gallery_Banner_Photo { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Administrator Administrator { get; set; }
        public Gallery Gallery { get; set; }
    }
}