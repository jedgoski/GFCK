using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Engine.DAO.Object;
using Engine.DAO.Domain;
using Engine.Domain.Object;

namespace GFCK
{
    public partial class _Default : System.Web.UI.Page
    {
        FactoryDAO _factoryDAO = FactoryDAO.GetInstance();
        int _categoryID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["c"] != null)
                _categoryID = Convert.ToInt32(Request.QueryString["c"]);

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void LoadData()
        {
            string filter = (Session["filter"] == null) ? "" : Session["filter"].ToString();

            ICouponDAO couponDAO = _factoryDAO.GetCouponDAO();
            List<Coupon> coupons = couponDAO.GetAllCouponsByCategory(_categoryID, filter);

            rptCoupons.DataSource = coupons;
            rptCoupons.DataBind();
        }

        protected void rptCoupons_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item != null && e.Item.DataItem != null)
                {
                    e.Item.Visible = false;

                    Coupon coupon = new Coupon();
                    coupon = (Coupon)e.Item.DataItem;
                    GFCK.UserControls.Coupon.home CouponDisplay = (GFCK.UserControls.Coupon.home)e.Item.FindControl("cd");
                    if (coupon != null && CouponDisplay != null)
                    {
                        //if the number of coupons set up by the manufacturer has already been reached, don't display.
                        if (coupon.Clicks >= coupon.NumberOfCoupons)
                        {
                            return;
                        }

                        //if the coupon has expired, don't display - already built into the SP

                        IMerchantDAO merchantDAO = _factoryDAO.GetMerchantDAO();

                        Merchant m = merchantDAO.GetMerchant(coupon.MerchantID);
                        CouponDisplay.Name = m.MerchantName;
                        CouponDisplay.Picture = string.Format("https://s3.amazonaws.com/gfck/coupon/{0}", coupon.Image); //"https://s3.amazonaws.com/gfck/coupon/Carvel/3.gif";// coupon.Image.ToString();
                        CouponDisplay.Description = coupon.Details;
                        CouponDisplay.Amount = coupon.Value;
                        CouponDisplay.CouponID = coupon.ID.ToString();
                    }
                }
            }


        }
    }
}
