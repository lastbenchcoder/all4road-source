using DDWBlogger.Project.Source.App_Data;
using DDWBlogger.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Core.dal
{
    internal class dAdministrator
    {
        private DBContext context;
        internal dAdministrator()
        {
            context = new DBContext();
        }

        internal Administrator Create(Administrator Administrator)
        {
            try
            {
                int maxAdministratorsId = 0;
                if (context.Administrator.ToList().Count > 0)
                    maxAdministratorsId = context.Administrator.Max(m => m.AdministratorId);
                maxAdministratorsId = (maxAdministratorsId > 0) ? (maxAdministratorsId + 1) : 1;
                Administrator.AdminCode = "AR" + maxAdministratorsId + "ADMCODE" + (maxAdministratorsId + 1);
                context.Administrator.Add(Administrator);
                context.SaveChanges();
                return Administrator;
            }
            catch (Exception ex)
            {
                Administrator.ErrorMessage = ex.Message;
                return Administrator;
            }
        }

        internal EmailTracker CreateEmailTracker(EmailTracker EmailTracker)
        {
            context.EmailTracker.Add(EmailTracker);
            context.SaveChanges();
            return EmailTracker;
        }

        internal List<Administrator> List()
        {
            List<Administrator> Administrator = new List<Administrator>();
            try
            {
                Administrator = context.Administrator.Include("Store").ToList();
                return Administrator;
            }
            catch (Exception ex)
            {
                Administrator[0].ErrorMessage = ex.Message;
                return Administrator;
            }
        }

        internal List<EmailTracker> ListEmailTracker()
        {
            List<EmailTracker> EmailTracker = new List<EmailTracker>();
            EmailTracker = context.EmailTracker.ToList();
            return EmailTracker;
        }

        internal Administrator Update(Administrator Administrator)
        {
            try
            {
                var entity = context.Administrator.Where(c => c.AdministratorId == Administrator.AdministratorId).AsQueryable().FirstOrDefault();
                if (entity == null)
                {
                    context.Administrator.Add(Administrator);
                }
                else
                {
                    context.Entry(entity).CurrentValues.SetValues(Administrator);
                }
                context.SaveChanges();
                return Administrator;
            }
            catch (Exception ex)
            {
                Administrator.ErrorMessage = ex.Message;
                return Administrator;
            }
        }

        internal AdminActivity CreateActivity(AdminActivity adminActivity)
        {
            try
            {
                context.AdminActivity.Add(adminActivity);
                context.SaveChanges();
                return adminActivity;
            }
            catch (Exception ex)
            {
                adminActivity.ErrorMessage = ex.Message;
                return adminActivity;
            }
        }

        internal List<AdminActivity> ListActivity()
        {
            List<AdminActivity> Administrator = new List<AdminActivity>();
            try
            {
                Administrator = context.AdminActivity.Include("Administrator").ToList();
                return Administrator;
            }
            catch (Exception ex)
            {
                Administrator[0].ErrorMessage = ex.Message;
                return Administrator;
            }
        }

        internal List<AdminActivity> ListActivityByAdmin(int adminId)
        {
            List<AdminActivity> Administrator = new List<AdminActivity>();
            try
            {
                Administrator = context.AdminActivity.Include("Administrator").Where(m => m.Administrators_Id == adminId).ToList();
                return Administrator;
            }
            catch (Exception ex)
            {
                Administrator[0].ErrorMessage = ex.Message;
                return Administrator;
            }
        }
    }
}