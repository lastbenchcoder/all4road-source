using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Models
{
    public class Gallery
    {
        [Key]
        [Column("gallery_id")]
        public int GalleryId { get; set; }
        [Column("admin_id")]
        public int AdministratorId { get; set; }
        [MaxLength(300)]
        [Column("title")]
        public string Title { get; set; }
        [MaxLength(5000)]
        [Column("description")]
        public string Description { get; set; }
        [Column("statusid")]
        public int StatusId { get; set; }
        [Column("datecreated")]
        public DateTime DateCreated { get; set; }
        [Column("dateupdated")]
        public DateTime DateUpdated { get; set; }

        public Administrator Administrator { get; set; }
        public Status Status { get; set; }
        public ICollection<GalleryBanners> GalleryBanners { get; set; }
    }
}