using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Models
{
    public class HomePage
    {
        [Key]
        public int HomePageId { get; set; }
        public int AdministratorId { get; set; }
        [MaxLength(300)]
        public string MetaTitle { get; set; }
        [MaxLength(3000)]
        public string MetaDescription { get; set; }
        [MaxLength(300)]
        public string MetaKeyWords { get; set; }
        [MaxLength(500)]
        public string Logo { get; set; }
        [MaxLength(300)]
        public string EmailId { get; set; }
        [MaxLength(300)]
        public string Phone { get; set; }
        public int DisplayTopMenuBar { get; set; }
        public int Display_468_60 { get; set; }
        public int Display_250_250 { get; set; }
        public int DisplaySlider { get; set; }
        public int DisplayFeatured { get; set; }
        public int DisplayBest { get; set; }
        public int CategoryId1 { get; set; }
        public int CategoryId2 { get; set; }
        [MaxLength(300)]
        public string Facebook { get; set; }
        [MaxLength(300)]
        public string Twitter { get; set; }
        [MaxLength(300)]
        public string GooglePlus { get; set; }
        [MaxLength(300)]
        public string Youtube { get; set; }
        [MaxLength(300)]
        public string Pintrest { get; set; }
        [MaxLength(300)]
        public string CopyrightMesssage { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}