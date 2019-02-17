using DDWBlogger.Project.Source.Enums;
using DDWBlogger.Project.Source.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using DDWBlogger.Project.Source.Core.bal;
using System.Web;

namespace DDWBlogger.Project.Source.Helper
{
    public class MailHelper
    {
        private static string DomainUrl = ConfigurationSettings.AppSettings["DomainUrl"].ToString();
        private static string AppName = ConfigurationSettings.AppSettings["AppName"].ToString();
        private static string MailFrom = ConfigurationSettings.AppSettings["MailFrom"].ToString();
        private static string SmtpClient = ConfigurationSettings.AppSettings["SmtpClient"].ToString();
        private static string SmtpPort = ConfigurationSettings.AppSettings["SmtpPort"].ToString();
        private static string NetworkCredentialEmail = ConfigurationSettings.AppSettings["NetworkCredentialEmail"].ToString();
        private static string NetworkCredentialPwd = ConfigurationSettings.AppSettings["NetworkCredentialPwd"].ToString();
        public static string SendEmail(string ToEmailId, string Subject, string BodyMessage, string MailFrom)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(MailFrom, MailFrom);
                mailMessage.To.Add(new MailAddress(ToEmailId));
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = Subject;
                mailMessage.Body = BodyMessage;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.High;
                SmtpClient smtpClient = new SmtpClient(SmtpClient);
                smtpClient.Port = Convert.ToInt32(SmtpPort);
                System.Net.NetworkCredential MyCache = new System.Net.NetworkCredential(NetworkCredentialEmail, NetworkCredentialPwd);
                smtpClient.Credentials = MyCache;
                smtpClient.EnableSsl = false;
                smtpClient.Send(mailMessage);

                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message + "ToEmailId:";
            }
        }
        public static string PasswordResetLink(string host)
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/noimage.png' width='200'></div>"
                + "<div>"
             + "Dear User,<br />"
             + "<br />"
             + "Thanks for submitting the request, Please find your reset password link.<br />"
             + "<br />"
             + "<a href='" + host + "'>Click here to reset the password</a>"
             + "<br />"
             + "<br />"
             + "Thanks,<br />"
             + AppName + "  Admin"
             + "</div>";
            return result;
        }
        public static string PasswordResetSuccess()
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/logo.png' width='200'></div>"
                + "<div>"
             + "Dear User,<br />"
             + "<br />"
             + "Thanks for submitting the request, Your password has been updated successfully.<br />"
             + "<br />"
             + "Thanks,<br />"
             + AppName + "  Admin"
             + "</div>";
            return result;
        }
        public static string EmailSubscribe()
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/logo.png' width='200'></div>"
                + "<div>"
             + "Dear User,<br />"
             + "<br />"
             + "Thanks for submitting the request, Your Email Updated in our database.<br />"
             + "You will recieve all the updates from our application.<br />"
             + "<br />"
             + "Thanks,<br />"
             + AppName + "  Admin"
             + "</div>";
            return result;
        }
        public static string EmailArticleUploaded(string url, string title)
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/logo.png' width='200'></div>"
                + "<div>"
             + "Dear User,<br />"
             + "<br />"
             + "It's been good time, new article uploaded in our portal. We found it will helps to you.<br />"
             + "<h4>" + title + "</h4>"
             + "Click below link to read full article.<br />"
             + "<br />"
             + "<a href='" + url + "'>Click here to read full article</a>"
             + "<br />"
             + "Thanks,<br />"
             + AppName + "  Admin"
             + "</div>";
            return result;
        }

        public static string InvitationLink(string host)
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/logo.png' width='200'></div>"
                + "<div>"
             + "Dear User,<br />"
             + "<br />"
             + AppName + "  very happy to invite you. You are invited as one of our admin.<br />"
             + "<br />"
             + "<a href='" + host + "'>Click here to complete for your registration</a>"
             + "<br />"
             + "<br />"
             + "Thanks,<br />"
             + AppName + "  Admin"
             + "</div>";
            return result;
        }

        public static string RequestRaised()
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/logo.png' width='200'></div>"
               + "<div>"
            + "Dear User,<br />"
            + "<br />"
            + "Thanks for submitting the request, Your request is in under process. Further communication to be communicated via email.<br />"
            + "<br />"
            + "Thanks,<br />"
            + AppName + "  Admin"
            + "</div>";
            return result;
        }

        public static string VerifyEmailLink(string host, string user)
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/logo.png' width='200'></div>"
                + "<div>"
             + "Dear " + user + ",<br />"
             + "<br />"
             + "Thank you for registering with us, Please click below link to verify your email id.<br />"
             + "<br />"
             + "<a href='" + host + "'>Click here to verify your email id</a>"
             + "<br />"
             + "<br />"
             + "Thanks,<br />"
             + AppName + "  Store"
             + "</div>";
            return result;
        }

        public static string AccountCreated(string fullname, string emailId, string password, string role)
        {
            string result = "<div style='float:right;'><img src='" + DomainUrl + "content/logo.png' width='200'></div>"
               + "<div>"
            + "Dear " + fullname + ",<br />"
            + "<br />"
            + "Your account has been created successfully in " + AppName + " Please find your account detail, given below.<br />"
            + "<br />"
            + "EmailId : " + emailId
            + "<br />"
            + "Password : " + password
            + "<br />"
            + "Role : " + role
            + "<br />"
            + "Thanks,<br />"
            + AppName + "  Admin"
            + "</div>";
            return result;
        }

        public static string ActivityMail(string type, string description, int adminId, string dateofactivity)
        {
            Administrator Administrator = bAdministrator.List().Where(m => m.AdministratorId == adminId).FirstOrDefault();
            string result = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/admin_activity_email.html"));
            result = result.Replace("{RequestType}", type);
            result = result.Replace("{RequestDescription}", description);
            result = result.Replace("{RequestDateOfActivity}", dateofactivity);
            result = result.Replace("{RequestAdministrator}", Administrator.FirstName + " " + Administrator.LastName + "(" + Administrator.EmailId + ")");
            return result;
        }

        public static string EmailToSend()
        {
            string emailIdToSend = string.Empty;
            List<Administrator> Administrators = bAdministrator.List().Where(m => m.StatusId == Convert.ToInt32(eStatus.Active)).ToList();
            foreach (var item in Administrators)
            {
                if (item.Send_Activity_Mail == 1)
                {
                    if (!string.IsNullOrEmpty(emailIdToSend))
                    {
                        emailIdToSend = emailIdToSend + "," + item.EmailId;
                    }
                    else
                    {
                        emailIdToSend = item.EmailId;
                    }
                }
            }
            return emailIdToSend;
        }
    }
}
