using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Engine.DAO.Domain;
using System.Web.UI.HtmlControls;
using Engine.Domain.Object;
using log4net;
using Engine.DAO.Object;

namespace GFCK.Admin
{
    public partial class CouponPrint : System.Web.UI.Page
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(CouponPrint));
        FactoryDAO _factoryDAO = FactoryDAO.GetInstance();
        Int64 _merchantID = 0;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            try
            {
                BindEvents();
                LoadData();
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occurred: Exception={0}", ex.Message);
                lblError.Visible = true;
                lblDeleteError.Visible = false;
                lblDeleteSuccessfull.Visible = false;
            }
        }

        protected void BindEvents()
        {
            rptCoupons.ItemDataBound += new RepeaterItemEventHandler(rptCoupons_ItemDataBound);
            rptCoupons.ItemCommand += new RepeaterCommandEventHandler(rptCoupons_ItemCommand);
        }

        void rptCoupons_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))
                {
                    ICouponDAO couponDAO = _factoryDAO.GetCouponDAO();
                    Coupon coupon = couponDAO.GetCoupon(Convert.ToInt64(e.CommandArgument));
                    coupon.Enabled = true;
                    if (couponDAO.UpdateCoupon(coupon))
                    {
                        // Delete was successfull
                        lblDeleteSuccessfull.Visible = true;
                        lblError.Visible = false;
                        lblDeleteError.Visible = false;
                    }
                    else
                    {
                        lblDeleteError.Visible = true;
                        lblError.Visible = false;
                        lblDeleteSuccessfull.Visible = false;
                    }
                }
            }
        }

        void rptCoupons_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Coupon coupon = (Coupon)e.Item.DataItem;

                Label lblValue = (Label)e.Item.FindControl("lblValue");
                Label lblDiscount = (Label)e.Item.FindControl("lblDiscount");
                Label lblStartDate = (Label)e.Item.FindControl("lblStartDate");
                Label lblExpirationDate = (Label)e.Item.FindControl("lblExpirationDate");


                HtmlAnchor lnkEdit = (HtmlAnchor)e.Item.FindControl("lnkEdit");
                HtmlAnchor lnkView = (HtmlAnchor)e.Item.FindControl("lnkView");
                LinkButton lnkDelete = (LinkButton)e.Item.FindControl("lnkDelete");

                lblValue.Text = coupon.Value;
                lblDiscount.Text = coupon.Discount;
                lblStartDate.Text = Convert.ToDateTime(coupon.StartDate).ToShortDateString();
                lblExpirationDate.Text = Convert.ToDateTime(coupon.ExpirationDate).ToShortDateString();
                lnkEdit.HRef = string.Format(lnkEdit.HRef, coupon.ID);
                lnkView.HRef = string.Format(lnkView.HRef, coupon.ID);
                lnkDelete.CommandArgument = Convert.ToString(coupon.ID);
            }
        }

        protected void LoadData()
        {
            ICouponDAO couponDAO = _factoryDAO.GetCouponDAO();
            List<Coupon> coupons = couponDAO.GetAllCouponsForMerchantID(_merchantID);
            rptCoupons.DataSource = coupons;
            rptCoupons.DataBind();
        }
    }
}