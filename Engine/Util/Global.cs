using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using log4net;

namespace Engine.Util
{
    public class Global
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(Global));
        public static bool SendMail(string fromAddress, string toAddress, string subject, string body, string host )
        {   
            bool success = false;
            try
            {
                MailMessage mailObj = new MailMessage(fromAddress, toAddress, subject, body);
                SmtpClient smtpServer = new SmtpClient(host);
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
