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

        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string emailFrom = Server.HtmlEncode(txtEmail.Text);
                //string emailTo = ConfigurationManager.AppSettings["ContactFormEmailTo"];
                string emailSubject = ConfigurationManager.AppSettings["ContactFormEmailSubject"];
                string emailHost = ConfigurationManager.AppSettings["MailHost"];
                string reasonEmail = "admin@glutenfreecouponking.com";
                switch (ddlReason.SelectedValue)
                {
                    case "advertise":
                        reasonEmail = "advertise@glutenfreecouponking.com";
                        break;
                    case "affiliate":
                        reasonEmail = "affiliate@glutenfreecouponking.com";
                        break;
                    case "feedback":
                        reasonEmail = "feedback@glutenfreecouponking.com";
                        break;
                    case "support":
                        reasonEmail = "support@glutenfreecouponking.com";
                        break;
                    case "paypal":
                        reasonEmail = "paypal@glutenfreecouponking.com";
                        break;
                }

                StringBuilder body = new StringBuilder();
                body.AppendFormat("First Name: {0}<br />", Server.HtmlEncode(txtFirstName.Text));
                body.AppendFormat("Last Name: {0}<br />", Server.HtmlEncode(txtLastName.Text));
                body.AppendFormat("Phone number: {0}<br />", Server.HtmlEncode(txtPhoneNumber.Text));
                body.AppendFormat("Comments: {0}", Server.HtmlEncode(txtComments.Text));
                if (Globals.SendMail(emailFrom, reasonEmail, emailSubject, body.ToString(), emailHost))
                {
                    // Success
                    divForm.Visible = false;
                    divThankYou.Visible = true;
                }
                else
                {
                    _log.ErrorFormat("Could not send email");
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