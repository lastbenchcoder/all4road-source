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
    public class bContactOwner
    {
        public static ContactOwner Create(ContactOwner ContactOwner)
        {
            dContactOwner _dContactOwner = new dContactOwner();
            ContactOwner = _dContactOwner.Create(ContactOwner);
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Contact Detail", "New Ads " + ContactOwner.Contact_Address +
                    "( " + ContactOwner.Contact_Owner_Id + "  and " + ContactOwner.Contact_Owner_Code + " ) created successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "New ContactOwner Created", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return ContactOwner;
        }

        public static List<ContactOwner> List()
        {
            dContactOwner _dContactOwner = new dContactOwner();
            return _dContactOwner.List();
        }

        public static ContactOwner Update(ContactOwner ContactOwner)
        {
            dContactOwner _dContactOwner = new dContactOwner();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Contact Detail", "Contact Owner Updation done on " + ContactOwner.Contact_Address +
                    "( " + ContactOwner.Contact_Owner_Id + "  and " + ContactOwner.Contact_Owner_Code + " ) successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Contact Owner Updation", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _dContactOwner.Update(ContactOwner);
        }

        public static int Delete(ContactOwner ContactOwner)
        {
            dContactOwner _dContactOwner = new dContactOwner();
            if (Convert.ToBoolean(ConfigurationSettings.AppSettings["IsEmailEnable"]))
            {
                string mailBody = MailHelper.ActivityMail("Contact Detail", "Contact Owner Deletion done on " + ContactOwner.Contact_Address +
                    "( " + ContactOwner.Contact_Owner_Id + "  and " + ContactOwner.Contact_Owner_Code + " ) successfully.",
                    1, DateTime.Now.ToString());

                MailHelper.SendEmail(MailHelper.EmailToSend(), "Contact Owner Deletion", mailBody, "Rachna Teracotta : Activity Admin");
            }
            return _dContactOwner.Delete(ContactOwner);
        }
    }
}