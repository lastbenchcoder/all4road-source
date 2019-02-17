using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Models
{
    public class Menus
    {
        [Key]
        [Column("menu_id")]
        public int Menu_Id { get; set; }
        [MaxLength(100)]
        [Column("title")]
        public string Title { get; set; }
        [MaxLength(100)]
        [Column("type")]
        public string MenuType { get; set; }
        [Column("page_id")]
        public int Page_Id { get; set; }
        [MaxLength(300)]
        [Column("custom_url")]
        public string Custom_Url { get; set; }
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

        public Pages Pages { get; set; }
        public Status Status { get; set; }
        public Administrator Administrator { get; set; }
    }
}