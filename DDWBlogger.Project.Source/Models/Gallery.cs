using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Models
{
    public class Gallery
    {
        [Key]
        public int GalleryId { get; set; }
        public int AdministratorId { get; set; }
        [MaxLength(300)]
        public string Title { get; set; }
        [MaxLength(5000)]
        public string Description { get; set; }
        public int StatusId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public Administrator Administrator { get; set; }
        public Status Status { get; set; }
        public ICollection<GalleryBanners> GalleryBanners { get; set; }
    }
}