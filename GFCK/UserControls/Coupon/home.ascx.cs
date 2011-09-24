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
        public string ID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblName.Text = Name;
            linkImage.HRef = string.Format("/detail.aspx?id={0}", ID);
            linkName.HRef = string.Format("/detail.aspx?id={0}", ID);
            imgProduct.Src = Picture;
            litPrice.Text = Amount;
            litDesc.Text = Description;
        }
    }
}