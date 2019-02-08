
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
        public DbSet<Invitation> Invitation { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}