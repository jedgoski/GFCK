using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using log4net;
using System.Net;

namespace Engine.Util
{
    public class Globals
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(Globals));
        
        public static bool SendMail(string fromAddress, string toAddress, string subject, string body, string host )
        {   
            bool success = false;
            try
            {
                string[] addresses = toAddress.Split(';');
                MailMessage mailObj = new MailMessage(fromAddress, addresses[0], subject, body);
                if (addresses.Length > 1)
                {
                    for (int ct = 1; ct < addresses.Length; ct++)
                    {
                        mailObj.To.Add(new MailAddress(addresses[ct]));
                    }
                }
                mailObj.IsBodyHtml = true;
                SmtpClient smtpServer = new SmtpClient(host);
                smtpServer.Credentials = new NetworkCredential("webuser@s385376672.onlinehome.us", "91ut3nfr33");
                smtpServer.Send(mailObj);
                success = true;
            }
            catch(Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex.Message);
            }

            return success;
            
        }
    }
}
