using DDWBlogger.Project.Source.Core.dal;
using DDWBlogger.Project.Source.Helper;
using DDWBlogger.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DDWBlogger.Project.Source.Core.bal
{
    public static class bAdministrator
    {
        public static Administrator Create(Administrator Administrator)
        {
            dAdministrator _dAdministrator = new dAdministrator();
            Administrator = _dAdministrator.Create(Administrator);
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Administrator", "New Administrator " + Administrator.EmailId +
                    "( " + Administrator.AdministratorId + "  and " + Administrator.AdminCode + " ) created successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "New Administrator Created", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return Administrator;
        }

        public static EmailTracker CreateEmailTracker(EmailTracker EmailTracker)
        {
            dAdministrator _dAdministrator = new dAdministrator();
            return _dAdministrator.CreateEmailTracker(EmailTracker);
        }

        public static List<Administrator> List()
        {
            dAdministrator _dAdministrator = new dAdministrator();
            return _dAdministrator.List();
        }

        public static List<EmailTracker> ListEmailTracker()
        {
            dAdministrator _dAdministrator = new dAdministrator();
            return _dAdministrator.ListEmailTracker();
        }

        public static Administrator Update(Administrator Administrator)
        {
            dAdministrator _dAdministrator = new dAdministrator();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Administrator", "Administrator Updation done on " + Administrator.EmailId +
                    "( " + Administrator.AdministratorId + "  and " + Administrator.AdminCode + " ) successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Administrator Updation", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _dAdministrator.Update(Administrator);
        }

        public static AdminActivity Create(AdminActivity adminActivity)
        {
            dAdministrator _dAdministrator = new dAdministrator();
            return _dAdministrator.CreateActivity(adminActivity);
        }

        public static List<AdminActivity> ListActivity()
        {
            dAdministrator _dAdministrator = new dAdministrator();
            return _dAdministrator.ListActivity();
        }

        public static List<AdminActivity> ListActivityByAdmin(int adminId)
        {
            dAdministrator _dAdministrator = new dAdministrator();
            return _dAdministrator.ListActivityByAdmin(adminId);
        }
    }
}