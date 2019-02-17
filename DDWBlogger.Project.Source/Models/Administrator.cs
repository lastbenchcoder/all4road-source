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
        [Column("admin_id")]
        public int AdministratorId { get; set; }
        [MaxLength(50)]
        [Column("admin_code")]
        public string AdminCode { get; set; }
        [MaxLength(50)]
        [Column("firstname")]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [Column("lastname")]
        public string LastName { get; set; }
        [MaxLength(300)]
        [Index(IsUnique = true)]
        [Column("emailid")]
        public string EmailId { get; set; }
        [MaxLength(20)]
        [Index(IsUnique = true)]
        [Column("phone")]
        public string PhoneNo { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [MaxLength(300)]
        [Column("banner")]
        public string Banner { get; set; }
        [MaxLength(100)]
        [Index(IsUnique = true)]
        [Column("loginid")]
        public string LoginId { get; set; }
        [MaxLength(30)]
        [Column("password")]
        public string Password { get; set; }
        [MaxLength(500)]
        [Column("sec_question")]
        public string SecurityQuestion { get; set; }
        [MaxLength(300)]
        [Column("sec_q_answer")]
        public string SecurityAnswer { get; set; }
        [Column("datecreated")]
        public DateTime DateCreated { get; set; }
        [Column("dateupdated")]
        public DateTime DateUpdated { get; set; }
        [Column("invitation_id")]
        public int InvitationId { get; set; }
        [Column("status_id")]
        public int StatusId { get; set; }
        [Column("role_id")]
        public int RoleId { get; set; }
        [Column("activity_mail")]
        public int Send_Activity_Mail { get; set; }
        [NotMapped]
        public string ErrorMessage { get; set; }

        public ICollection<Article> Article { get; set; }
        public Invitation Invitation { get; set; }
        public Status Status { get; set; }
        public Role Role { get; set; }
    }
}