using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Models
{
    public class Administrator
    {
        [Key]
        public int AdministratorId { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(300)]
        [Index(IsUnique = true)]
        public string EmailId { get; set; }
        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string PhoneNo { get; set; }
        public string Description { get; set; }
        [MaxLength(300)]
        public string Banner { get; set; }
        [MaxLength(100)]
        [Index(IsUnique = true)]
        public string LoginId { get; set; }
        [MaxLength(30)]
        public string Password { get; set; }
        [MaxLength(500)]
        public string SecurityQuestion { get; set; }
        [MaxLength(300)]
        public string SecurityAnswer { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int InvitationId { get; set; }
        public int StatusId { get; set; }
        public int RoleId { get; set; }

        public ICollection<Article> Article { get; set; }
        public Invitation Invitation { get; set; }
        public Status Status { get; set; }
        public Role Role { get; set; }
    }
}