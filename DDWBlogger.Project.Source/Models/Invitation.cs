using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Models
{
    public class Invitation
    {
        [Key]
        public int InvitationId { get; set; }
        public int RoleId { get; set; }
        [MaxLength(50)]
        public string InvitationCode { get; set; }
        [MaxLength(300)]
        [Index(IsUnique = true)]
        public string EmailId { get; set; }
        public int StatusId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public Status Status { get; set; }
        public Role Role { get; set; }
    }
}