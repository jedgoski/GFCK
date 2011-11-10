using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Engine.DAO.Object;
using log4net;
using Engine.Domain.Object;
using System.Web.UI.HtmlControls;

namespace GFCK
{
    public partial class detail : System.Web.UI.Page
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(detail));
        FactoryDAO _factoryDAO = FactoryDAO.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            CouponDAO _couponDAO = (CouponDAO)_factoryDAO.GetCouponDAO();
            long couponID = 0;
            if(Request.QueryString["id"] != null && Request.QueryString["id"] != ""){
                couponID = Convert.ToInt64(Request.QueryString["id"]);
                Session["id"] = couponID;
            }

            divPrint.Visible = false;
            int numprints = 3;
            numprints = CheckCouponAgainstIPAddress(_couponDAO, couponID);
            _log.DebugFormat("number of prints on couponid: {0}", couponID);
            if (numprints < 3)
            {
                divPrint.Visible = true;
            }
            Coupon c = _couponDAO.GetCoupon(couponID);
            imgProduct.Src = string.Format("https://s3.amazonaws.com/gfck/coupon/{0}", c.Image);
            litDescription.Text = c.Details;
            litTerms.Text = c.Terms;

            List<string> listItems = new List<string>();
            if (c.CaseinFree) listItems.Add("Casein Free");
            if (c.CornFree) listItems.Add("Corn Free");
            if (c.EggFree) listItems.Add("Egg Free");
            if (c.NutFree) listItems.Add("Nut Free");
            if (c.SoyFree) listItems.Add("Soy Free");
            if (c.YeastFree) listItems.Add("Yeast Free");
            if (c.ContainGluten20PPM) listItems.Add("Contains Gluten at 20PPM");
            if (c.LessThan5PPM) listItems.Add("Contains less than 5PPM of Gluten");
            if (c.GlutenFreeFacility) listItems.Add("Made in Gluten Free Facility");
            rptFree.DataSource = listItems;
            rptFree.DataBind();
        }

        protected void rptFree_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item != null && e.Item.DataItem != null)
                {
                    string item = e.Item.DataItem.ToString();
                    HtmlGenericControl liItem = (HtmlGenericControl)e.Item.FindControl("liItem");
                    if (item == null || liItem == null)
                    {
                        return;
                    }

                    liItem.InnerText = item;
                }
            }
        }

        private int CheckCouponAgainstIPAddress(CouponDAO _couponDAO, long couponID)
        {
            int numPrints = 0;
            string ip = Request.UserHostAddress;

            List<CouponPrint> prints = _couponDAO.GetCouponPrintsForCouponID(couponID);
            if (prints.Count > 0)
            {
                List<CouponPrint> p = prints.FindAll(i => i.IPAddress == ip);
                if (p != null)
                {
                    numPrints = p.Count;
                }
            }

            return numPrints;
        }
    }
}