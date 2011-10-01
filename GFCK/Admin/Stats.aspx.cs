using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Engine.DAO.Object;
using log4net;
using Engine.DAO.Domain;
using Engine.Domain.Object;
using System.Web.Security;

namespace GFCK.Admin
{
    public partial class Stats : System.Web.UI.Page
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(Stats));
        FactoryDAO _factoryDAO = FactoryDAO.GetInstance();
        long _manufacturerID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ManufacturerID"]))
            {
                _manufacturerID = Convert.ToInt64(Request.QueryString["ManufacturerID"]);
            }

            if (!IsPostBack)
            {
                GetStats();
            }
        }

        protected void GetStats()
        {
            IMerchantDAO merchantDAO = _factoryDAO.GetMerchantDAO();
            ICouponDAO couponDAO = _factoryDAO.GetCouponDAO();
            Merchant merchant = merchantDAO.GetMerchant(_manufacturerID);
            List<Coupon> coupons = couponDAO.GetAllCouponsForMerchantID(_manufacturerID);

            litName.Text = merchant.MerchantName;

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

            Literal litCoupon = (Literal)e.Item.FindControl("litCoupon");
            Literal litStats = (Literal)e.Item.FindControl("litStats");

            if (litCoupon == null || litStats == null)
            {
                return;
            }

            litCoupon.Text = c.Name;
            litStats.Text = c.Clicks.ToString();
        }

    }
}