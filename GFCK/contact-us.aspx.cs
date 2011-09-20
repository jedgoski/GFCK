using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Engine.Util;
using System.Text;
using System.Configuration;
using log4net;
namespace GFCK
{
    public partial class contact_us : System.Web.UI.Page
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(contact_us));

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            try
            {
                string emailFrom = txtEmail.Text;
                string emailTo = ConfigurationManager.AppSettings["ContactFormEmailTo"];
                string emailSubject = ConfigurationManager.AppSettings["ContactFormEmailSubject"];
                string emailHost = ConfigurationManager.AppSettings["MailHost"];
                StringBuilder body = new StringBuilder();
                body.AppendFormat("First Name: {0}", txtFirstName.Text);
                body.AppendFormat("Last Name: {1}", txtLastName.Text);
                body.AppendFormat("Phone number: {2}", txtPhoneNumber.Text);
                body.AppendFormat("Comments: {3}", txtComments.Text);
                if (Globals.SendMail(emailFrom, emailTo, emailSubject, body.ToString(), emailHost))
                {
                    // Success
                    divForm.Visible = false;
                    divThankYou.Visible = true;
                }
                else
                {
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occurred: Exception={0}", ex.Message);
                lblError.Visible = true;
            }
        }

    }
}