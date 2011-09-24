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
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void LoadData()
        {
            ICouponDAO couponDAO = _factoryDAO.GetCouponDAO();
            List<Coupon> coupons = couponDAO.GetAllCouponsByCategory(1);
            Coupon test1 = new Coupon();
            test1.Value = "Simply Orange";
            test1.Image = 9;
            test1.Details = "buy now!";
            test1.Discount = "0.75";
            test1.ID = 98679;
            Coupon test2 = new Coupon();
            coupons.Add(test1);
            coupons.Add(test2);

            rptCoupons.DataSource = coupons;
            rptCoupons.DataBind();
        }
        protected void rptCoupons_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item != null && e.Item.DataItem != null)
                {
                    Coupon coupon = new Coupon();
                    coupon = (Coupon)e.Item.DataItem;
                    GFCK.UserControls.Coupon.home list = (GFCK.UserControls.Coupon.home)e.Item.FindControl("CouponDisplay");
                    if (coupon != null && list != null)
                    {
                        list.Name = coupon.Value;
                        list.Picture = coupon.Image.ToString();
                        list.Description = coupon.Details;
                        list.Amount = coupon.Discount;
                        list.ID = coupon.ID.ToString();
                    }
                }
            }


        }
    }
}
