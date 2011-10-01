using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GFCK.UserControls.Coupon
{
    public partial class home : System.Web.UI.UserControl
    {
        public string Name { get; set; } 
        public string Picture { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string CouponID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreRender += new EventHandler(home_PreRender);
        }

        void home_PreRender(object sender, EventArgs e)
        {
            lblName.Text = Name;
            linkImage.HRef = string.Format("/detail.aspx?id={0}", CouponID);
            linkName.HRef = string.Format("/detail.aspx?id={0}", CouponID);
            imgProduct.Src = Picture;
            litPrice.Text = Amount;
            litDesc.Text = Description;
        }
    }
}