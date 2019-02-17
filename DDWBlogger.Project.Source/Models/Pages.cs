using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Models
{
    public class Pages
    {
        [Key]
        [Column("page_id")]
        public int Page_Id { get; set; }
        [MaxLength(100)]
        [Column("title")]
        public string Title { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("datecreated")]
        public DateTime DateCreated { get; set; }
        [Column("dateupdated")]
        public DateTime DateUpdated { get; set; }
        [Column("status_id")]
        public int StatusId { get; set; }
        [Column("admin_id")]
        public int AdministratorId { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }

        public Administrator Administrator { get; set; }
        public Status Status { get; set; }
        public ICollection<Menus> Menus { get; set; }
    }
}