namespace DDWBlogger.Project.Source.Migrations
{
    using App_Data;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DBContext context)
        {

        }

        public void ApplicationSetup()
        {
            using (var context = new DBContext())
            {
                #region Status
                context.Status.AddOrUpdate(
                   p => new { p.Title, p.StatusFor },
                        new Status
                        {
                            Title = DDWBlogger.Project.Source.Enums.eStatus.Active.ToString(),
                            Description = "All the items will be in active status",
                            StatusFor = "All",
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );

                context.Status.AddOrUpdate(
                   p => new { p.Title, p.StatusFor },
                        new Status
                        {
                            Title = DDWBlogger.Project.Source.Enums.eStatus.InActive.ToString(),
                            Description = "All the items will be in in-active status",
                            StatusFor = "All",
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );

                context.Status.AddOrUpdate(
                 p => new { p.Title, p.StatusFor },
                       new Status
                       {
                           Title = DDWBlogger.Project.Source.Enums.eStatus.Active.ToString(),
                           Description = "All the items will be in active status, Admin need to complete the registration.",
                           StatusFor = "Invitation",
                           InDisplay = 1,
                           DateCreated = DateTime.Now,
                           DateUpdated = DateTime.Now
                       }
               );
                context.Status.AddOrUpdate(
                  p => new { p.Title, p.StatusFor },
                       new Status
                       {
                           Title = DDWBlogger.Project.Source.Enums.eStatus.Completed.ToString(),
                           Description = "All the items will be in completed status, Admin has completed registration.",
                           StatusFor = "Invitation",
                           InDisplay = 1,
                           DateCreated = DateTime.Now,
                           DateUpdated = DateTime.Now
                       }
               );

                context.Status.AddOrUpdate(
                   p => new { p.Title, p.StatusFor },
                        new Status
                        {
                            Title = "Draft",
                            Description = "All the articles will be set to draft status",
                            StatusFor = "Articles",
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );

                context.Status.AddOrUpdate(
                p => new { p.Title, p.StatusFor },
                        new Status
                        {
                            Title = "Submitted",
                            Description = "All the articles will be set to submitted status",
                            StatusFor = "Articles",
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );

                context.Status.AddOrUpdate(
                  p => new { p.Title, p.StatusFor },
                        new Status
                        {
                            Title = DDWBlogger.Project.Source.Enums.eStatus.Published.ToString(),
                            Description = "All the articles will be set to published status",
                            StatusFor = "Articles",
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );

                context.Status.AddOrUpdate(
                  p => new { p.Title, p.StatusFor },
                        new Status
                        {
                            Title = "Rejected",
                            Description = "All the articles will be set to rejected status",
                            StatusFor = "Articles",
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );

                context.SaveChanges();
                #endregion
                #region Roles 
                context.Role.AddOrUpdate(
                p => p.Title,
                        new Role
                        {
                            Title = "Super",
                            Description = "Super admi has all the rights to the application.",
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );
                context.Role.AddOrUpdate(
                p => p.Title,
                        new Role
                        {
                            Title = "RegularAdmin",
                            Description = "Can Create/Update/Delete the Articles, no modication allowed for articles created by another admin.",
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );
                context.SaveChanges();
                #endregion
                #region SecurityQuestions
                context.SecurityQuestions.AddOrUpdate(
                p => p.Title,
                        new SecurityQuestions
                        {
                            Title = "What is your pet’s name?",
                            Description = "What is your pet’s name?",
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );
                context.SecurityQuestions.AddOrUpdate(
                p => p.Title,
                        new SecurityQuestions
                        {
                            Title = "In what year was your father born?",
                            Description = "In what year was your father born?",
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );
                context.SecurityQuestions.AddOrUpdate(
                p => p.Title,
                       new SecurityQuestions
                       {
                           Title = "What was the name of your elementary / primary school?",
                           Description = "What was the name of your elementary / primary school?",
                           InDisplay = 1,
                           DateCreated = DateTime.Now,
                           DateUpdated = DateTime.Now
                       }
                );
                context.SecurityQuestions.AddOrUpdate(
                  p => p.Title,
                          new SecurityQuestions
                          {
                              Title = "In what city or town does your nearest sibling live?",
                              Description = "In what city or town does your nearest sibling live?",
                              InDisplay = 1,
                              DateCreated = DateTime.Now,
                              DateUpdated = DateTime.Now
                          }
                  );
                context.SecurityQuestions.AddOrUpdate(
                 p => p.Title,
                         new SecurityQuestions
                         {
                             Title = "What time of the day were you born?",
                             Description = "What time of the day were you born?",
                             InDisplay = 1,
                             DateCreated = DateTime.Now,
                             DateUpdated = DateTime.Now
                         }
                 );
                context.SaveChanges();
                #endregion
                #region Invitation
                context.Invitation.AddOrUpdate(
                   p => p.EmailId,
                           new Invitation
                           {
                               EmailId = "admin@all4road.com",
                               InvitationCode = Guid.NewGuid().ToString(),
                               RoleId = context.Role.Where(m => m.Title == "Super").FirstOrDefault().RoleId,
                               StatusId = context.Status.Where(m => m.Title == DDWBlogger.Project.Source.Enums.eStatus.Completed.ToString() && m.StatusFor=="Invitation").FirstOrDefault().StatusId,
                               DateCreated = DateTime.Now,
                               DateUpdated = DateTime.Now
                           }
                   );
                context.Invitation.AddOrUpdate(
                   p => p.EmailId,
                           new Invitation
                           {
                               EmailId = "radmin@all4road.com",
                               InvitationCode = Guid.NewGuid().ToString(),
                               RoleId = context.Role.Where(m => m.Title == "RegularAdmin").FirstOrDefault().RoleId,
                               StatusId = context.Status.Where(m => m.Title == DDWBlogger.Project.Source.Enums.eStatus.Completed.ToString() && m.StatusFor == "Invitation").FirstOrDefault().StatusId,
                               DateCreated = DateTime.Now,
                               DateUpdated = DateTime.Now
                           }
                   );
                context.SaveChanges();
                #endregion
                #region Administrator
                context.Administrator.AddOrUpdate(
                  p => p.EmailId,
                          new Administrator
                          {
                              EmailId = "admin@all4road.com",
                              PhoneNo = "9900990099",
                              InvitationId = context.Invitation.Where(m => m.EmailId == "admin@all4road.com").FirstOrDefault().InvitationId,
                              RoleId = context.Invitation.Where(m => m.EmailId == "admin@all4road.com").FirstOrDefault().RoleId,
                              StatusId = context.Status.Where(m => m.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString()).FirstOrDefault().StatusId,
                              FirstName = "super",
                              LastName = "administrator",
                              Description = "Super administrator, created by system also called as master admin. one which has all the rights.",
                              Banner = "content/noimage.png",
                              LoginId = "admin@all4road.com",
                              Password = "Passw0rd1",
                              SecurityQuestion = context.SecurityQuestions.FirstOrDefault().Title,
                              SecurityAnswer = "application",
                              DateCreated = DateTime.Now,
                              DateUpdated = DateTime.Now
                          }
                  );
                context.Administrator.AddOrUpdate(
                  p => p.EmailId,
                          new Administrator
                          {
                              EmailId = "radmin@all4road.com",
                              PhoneNo = "990099009",
                              InvitationId = context.Invitation.Where(m => m.EmailId == "radmin@all4road.com").FirstOrDefault().InvitationId,
                              RoleId = context.Invitation.Where(m => m.EmailId == "radmin@all4road.com").FirstOrDefault().RoleId,
                              StatusId = context.Status.Where(m => m.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString()).FirstOrDefault().StatusId,
                              FirstName = "regular",
                              LastName = "administrator",
                              Description = "Regular administrator, created by system also called as Regular Admin. one which has limited rights.",
                              Banner = "content/noimage.png",
                              LoginId = "radmin@all4road.com",
                              Password = "Passw0rd2",
                              SecurityQuestion = context.SecurityQuestions.FirstOrDefault().Title,
                              SecurityAnswer = "application",
                              DateCreated = DateTime.Now,
                              DateUpdated = DateTime.Now
                          }
                  );
                context.SaveChanges();
                #endregion
                #region Category
                context.Category.AddOrUpdate(
               p => p.Title,
                       new Category
                       {
                           Title = "Travel",
                           Description = "Travel Category",
                           StatusId = context.Status.Where(m => m.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString()).FirstOrDefault().StatusId,
                           AdministratorId = context.Administrator.Where(m => m.EmailId == "admin@all4road.com").FirstOrDefault().StatusId,
                           DateCreated = DateTime.Now,
                           DateUpdated = DateTime.Now
                       }
               );
                context.Category.AddOrUpdate(
               p => p.Title,
                       new Category
                       {
                           Title = "Hotel",
                           Description = "Hotel Category",
                           StatusId = context.Status.Where(m => m.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString()).FirstOrDefault().StatusId,
                           AdministratorId = context.Administrator.Where(m => m.EmailId == "radmin@all4road.com").FirstOrDefault().StatusId,
                           DateCreated = DateTime.Now,
                           DateUpdated = DateTime.Now
                       }
               );
                context.Category.AddOrUpdate(
              p => p.Title,
                      new Category
                      {
                          Title = "Automobiles",
                          Description = "Automobiles Category",
                          StatusId = context.Status.Where(m => m.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString()).FirstOrDefault().StatusId,
                          AdministratorId = context.Administrator.Where(m => m.EmailId == "radmin@all4road.com").FirstOrDefault().StatusId,
                          DateCreated = DateTime.Now,
                          DateUpdated = DateTime.Now
                      }
              );
                context.SaveChanges();
                #endregion
                #region SubCategory
                context.SubCategory.AddOrUpdate(
               p => p.Title,
                       new SubCategory
                       {
                           Title = "Trip to Location",
                           Description = "My trip to location SubCategory",
                           CategoryId = context.Category.Where(m => m.Title == "Travel").FirstOrDefault().CategoryId,
                           StatusId = context.Status.Where(m => m.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString()).FirstOrDefault().StatusId,
                           AdministratorId = context.Administrator.Where(m => m.EmailId == "admin@all4road.com").FirstOrDefault().AdministratorId,
                           DateCreated = DateTime.Now,
                           DateUpdated = DateTime.Now
                       }
               );
                context.SubCategory.AddOrUpdate(
               p => p.Title,
                       new SubCategory
                       {
                           Title = "About the Place",
                           Description = "How is the place SubCategory",
                           CategoryId = context.Category.Where(m => m.Title == "Travel").FirstOrDefault().CategoryId,
                           StatusId = context.Status.Where(m => m.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString()).FirstOrDefault().StatusId,
                           AdministratorId = context.Administrator.Where(m => m.EmailId == "radmin@all4road.com").FirstOrDefault().AdministratorId,
                           DateCreated = DateTime.Now,
                           DateUpdated = DateTime.Now
                       }
               );
                context.SubCategory.AddOrUpdate(
              p => p.Title,
                      new SubCategory
                      {
                          Title = "Better Hotel",
                          Description = "Hotels are better and safe to stay sub Category",
                          CategoryId = context.Category.Where(m => m.Title == "Hotel").FirstOrDefault().CategoryId,
                          StatusId = context.Status.Where(m => m.Title == DDWBlogger.Project.Source.Enums.eStatus.Active.ToString()).FirstOrDefault().StatusId,
                          AdministratorId = context.Administrator.Where(m => m.EmailId == "radmin@all4road.com").FirstOrDefault().AdministratorId,
                          DateCreated = DateTime.Now,
                          DateUpdated = DateTime.Now
                      }
              );
                context.SaveChanges();
                #endregion
                #region ArticleTypes
                context.ArticleAndTypes.AddOrUpdate(
                    p => p.Type,
                           new ArticleAndTypes
                           {
                               Type = "Best",
                               Description = "Best Articles selected by editor",
                               InDisplay = 1,
                               ArticleCount = 5,
                               DateCreated = DateTime.Now,
                               DateUpdated = DateTime.Now
                           }
                    );
                context.ArticleAndTypes.AddOrUpdate(
                 p => p.Type,
                        new ArticleAndTypes
                        {
                            Type = "Top",
                            Description = "Top Articles selected by editor",
                            InDisplay = 1,
                            ArticleCount = 5,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                 );
                context.ArticleAndTypes.AddOrUpdate(
                   p => p.Type,
                          new ArticleAndTypes
                          {
                              Type = "Featured",
                              Description = "Featured Articles selected by editor",
                              InDisplay = 1,
                              ArticleCount = 5,
                              DateCreated = DateTime.Now,
                              DateUpdated = DateTime.Now
                          }
                   );
                context.ArticleAndTypes.AddOrUpdate(
                  p => p.Type,
                         new ArticleAndTypes
                         {
                             Type = "EditorChoice",
                             Description = "Editor Choice Articles selected by editor",
                             InDisplay = 1,
                             ArticleCount = 5,
                             DateCreated = DateTime.Now,
                             DateUpdated = DateTime.Now
                         }
                  );
                context.SaveChanges();
                #endregion
                #region Ads Sizes
                context.AddSize.AddOrUpdate(
                   p => new { p.Description, p.Title },
                        new AddSize
                        {
                            Title = "250 x 250",
                            Description = "Square",
                            Width=250,
                            Height=250,
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );
                context.AddSize.AddOrUpdate(
                   p => new { p.Description, p.Title },
                        new AddSize
                        {
                            Title = "200 x 200",
                            Description = "Small Square",
                            Width = 200,
                            Height = 200,
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );
                context.AddSize.AddOrUpdate(
                   p => new { p.Description, p.Title },
                        new AddSize
                        {
                            Title = "468 x 60",
                            Description = "Banner",
                            Width = 468,
                            Height = 60,
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );
                context.AddSize.AddOrUpdate(
                   p => new { p.Description, p.Title },
                        new AddSize
                        {
                            Title = "728 x 90",
                            Description = "Leaderboard",
                            Width = 728,
                            Height = 90,
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );
                context.AddSize.AddOrUpdate(
                   p => new { p.Description, p.Title },
                        new AddSize
                        {
                            Title = "300 x 250",
                            Description = "Inline Rectangle",
                            Width = 300,
                            Height = 250,
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );
                context.AddSize.AddOrUpdate(
                   p => new { p.Description, p.Title },
                        new AddSize
                        {
                            Title = "336 x 280",
                            Description = "Large Rectangle",
                            Width = 336,
                            Height = 280,
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );
                context.AddSize.AddOrUpdate(
                   p => new { p.Description, p.Title },
                        new AddSize
                        {
                            Title = "120 x 600",
                            Description = "Skyscraper",
                            Width = 120,
                            Height = 600,
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );
                context.AddSize.AddOrUpdate(
                   p => new { p.Description, p.Title },
                        new AddSize
                        {
                            Title = "160 x 600",
                            Description = "Wide Skyscraper",
                            Width = 160,
                            Height = 600,
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );
                context.AddSize.AddOrUpdate(
                   p => new { p.Description, p.Title },
                        new AddSize
                        {
                            Title = "300 x 600",
                            Description = "Half-Page Ad",
                            Width = 300,
                            Height = 600,
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );
                context.AddSize.AddOrUpdate(
                   p => new { p.Description, p.Title },
                        new AddSize
                        {
                            Title = "970 x 90",
                            Description = "Large Leaderboard",
                            Width = 970,
                            Height = 90,
                            InDisplay = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now
                        }
                );

                context.SaveChanges();
                #endregion
            }
        }
    }
}
