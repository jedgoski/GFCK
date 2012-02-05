using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Engine.DAO.Object;
using Engine.DAO.Domain;
using Engine.Domain.Object;
using System.Web.Security;
using log4net;

namespace GFCK.Manufacturer
{
    public partial class _default : System.Web.UI.Page
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(_default));
        FactoryDAO _factoryDAO = FactoryDAO.GetInstance();
        long _manufacturerID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            MembershipUser user = Membership.GetUser();
            IMerchantDAO merchantDAO = _factoryDAO.GetMerchantDAO();

            Merchant m = merchantDAO.GetMerchantByUserID((Guid)user.ProviderUserKey);
            litManufacturer.Text = m.MerchantName;
            _manufacturerID = m.ID;
                    
            LoadData();
        }

        protected void LoadData()
        {
            ICouponDAO couponDAO = _factoryDAO.GetCouponDAO();
            List<Coupon> coupons = couponDAO.GetAllCouponsForMerchantID(_manufacturerID);
            rptCoupons.DataSource = coupons;
            rptCoupons.DataBind();
        }

        protected void rptCoupons_ItemDataBound(object source, RepeaterItemEventArgs e)
        {
            if (e.Item == null || e.Item.DataItem == null)
            {
                return;
            }

            Coupon c = (Coupon)e.Item.DataItem;

            if (c == null)
            {
                return;
            }
            
            HtmlImage img = (HtmlImage)e.Item.FindControl("img");
            Literal litCouponName = (Literal)e.Item.FindControl("litCouponName");
            Literal litCategory = (Literal)e.Item.FindControl("litCategory");
            Literal litValue = (Literal)e.Item.FindControl("litValue");
            Literal litClicks = (Literal)e.Item.FindControl("litClicks");
            Literal litExpires = (Literal)e.Item.FindControl("litExpires");
            HtmlAnchor linkEdit = (HtmlAnchor)e.Item.FindControl("linkEdit");
            HtmlAnchor linkDelete = (HtmlAnchor)e.Item.FindControl("linkDelete");

            if (img == null || litCouponName == null || litCategory == null || litValue == null || litClicks == null || litExpires == null || linkEdit == null || linkDelete == null)
            {
                return;
            }

            //does this really work?  If not, will need to make a page handler and link to that page.
            string strPicture = string.Format("https://s3.amazonaws.com/gfck/coupon/{0}", c.Image);
            if (c.Image != "") img.Src = strPicture;
            litCouponName.Text = (c.Name.Length > 32) ? String.Format("{0}...", c.Name.Substring(0,30)) : c.Name; 
            litCategory.Text = c.CategoryName; 
            litValue.Text = c.Value;
            litClicks.Text = string.Format("{0} of {1}", c.Clicks, c.NumberOfCoupons);
            litExpires.Text = Convert.ToDateTime(c.ExpirationDate).ToShortDateString();
            linkEdit.HRef = string.Format("/manufacturer/action.aspx?couponid={0}&Mode=Edit", c.ID);
            if (c.Enabled)
            {
                linkDelete.InnerText = "Inactivate";
                linkDelete.HRef = string.Format("/manufacturer/action.aspx?couponid={0}&Mode=Inactivate", c.ID);
            }
            else
            {
                linkDelete.InnerText = "Activate";
                linkDelete.HRef = string.Format("/manufacturer/action.aspx?couponid={0}&Mode=Activate", c.ID);
            }
        }

    }
}