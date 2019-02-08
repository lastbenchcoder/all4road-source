using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(50)]
        [Index(IsUnique = true)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int StatusId { get; set; }
        public int AdministratorId { get; set; }

        public ICollection<SubCategory> SubCategory { get; set; }
        public Status Status { get; set; }
        public Administrator Administrator { get; set; }
    }
}