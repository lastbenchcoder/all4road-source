
using DDWBlogger.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.App_Data
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name=DDWConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DBContext, Migrations.Configuration>("DDWConnectionString"));
        }

        public DbSet<Slider> Slider { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<SecurityQuestions> SecurityQuestions { get; set; }
        public DbSet<ContactOwner> ContactOwner { get; set; }
        public DbSet<Invitation> Invitation { get; set; }
        public DbSet<AdminActivity> AdminActivity { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<EmailTracker> EmailTracker { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleAndTypes> ArticleAndTypes { get; set; }
        public DbSet<ArticleAndFeatures> ArticleAndFeatures { get; set; }
        public DbSet<ReviewComment> ReviewComment { get; set; }
        public DbSet<ReplyReviewComment> ReplyReviewComment { get; set; }
        public DbSet<EmailSubscriptions> EmailSubscriptions { get; set; }
        public DbSet<AddSize> AddSize { get; set; }
        public DbSet<Ads> Ads { get; set; }
        public DbSet<HomePage> HomePage { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        public DbSet<GalleryBanners> GalleryBanners { get; set; }
        public DbSet<CustomerRequest> CustomerRequest { get; set; }
        public DbSet<Pages> Pages { get; set; }
        public DbSet<Menus> Menus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Slider>().ToTable("tbl_slider");
            modelBuilder.Entity<Status>().ToTable("tbl_status");
            modelBuilder.Entity<Role>().ToTable("tbl_role");
            modelBuilder.Entity<SecurityQuestions>().ToTable("tbl_security_question");
            modelBuilder.Entity<Invitation>().ToTable("tbl_invitation");
            modelBuilder.Entity<Administrator>().ToTable("tbl_admin");
            modelBuilder.Entity<AdminActivity>().ToTable("tbl_admin_activity");
            modelBuilder.Entity<EmailTracker>().ToTable("tbl_admin_email_tracker");
            modelBuilder.Entity<Category>().ToTable("tbl_category");
            modelBuilder.Entity<SubCategory>().ToTable("tbl_sub_category");
            modelBuilder.Entity<Article>().ToTable("tbl_article");
            modelBuilder.Entity<ArticleAndTypes>().ToTable("tbl_article_types");
            modelBuilder.Entity<ArticleAndFeatures>().ToTable("tbl_article_features");
            modelBuilder.Entity<ReviewComment>().ToTable("tbl_review_comment");
            modelBuilder.Entity<ReplyReviewComment>().ToTable("tbl_reply_review_comment");
            modelBuilder.Entity<EmailSubscriptions>().ToTable("tbl_email_subscription");
            modelBuilder.Entity<AddSize>().ToTable("tbl_ad_size");
            modelBuilder.Entity<Ads>().ToTable("tbl_ads");
            modelBuilder.Entity<HomePage>().ToTable("tbl_homepage");
            modelBuilder.Entity<Gallery>().ToTable("tbl_gallery");
            modelBuilder.Entity<GalleryBanners>().ToTable("tbl_gallery_banner");
            modelBuilder.Entity<ContactOwner>().ToTable("tbl_contact_owner");
            modelBuilder.Entity<CustomerRequest>().ToTable("tbl_customer_request");
            modelBuilder.Entity<Pages>().ToTable("tbl_pages");
            modelBuilder.Entity<Menus>().ToTable("tbl_menus");
        }
    }
}