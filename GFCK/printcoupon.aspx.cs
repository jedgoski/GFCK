using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Engine.DAO.Object;
using log4net;
using Engine.Domain.Object;

namespace GFCK
{
    public partial class printcoupon : System.Web.UI.Page
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(printcoupon));
        FactoryDAO _factoryDAO = FactoryDAO.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            string ip = Request.UserHostAddress;
            long couponID = 0;

            if (Session["id"] != null)
            {
                couponID = Convert.ToInt64(Session["id"]);
                CouponDAO _couponDAO = (CouponDAO)_factoryDAO.GetCouponDAO();
                
                //Get the coupon info for display
                Coupon c = _couponDAO.GetCoupon(couponID);
                litExpDate.Text = Convert.ToDateTime(c.ExpirationDate).ToString("MM/dd/yyyy");
                img.Src = String.Format("https://s3.amazonaws.com/gfck/coupon/{0}", c.Image);
                dotscan.Src = String.Format("BarcodeHandler.ashx?code=PDF417&modulewidth=.3&unit=mm&Data=1234 5678 9012 3456");
                litDotScan.Text = "1234 5678 9012 3456";
                litValue.Text = String.Format("{0:C}", Convert.ToDecimal(c.Value));
                litDesc.Text = c.Details;
                imgBarcode1.Src = String.Format("/BarcodeHandler.ashx?code=UPCA&modulewidth=.4&unit=mm&Data={0}", c.Barcode1Value);
                imgBarcode2.Src = String.Format("/BarcodeHandler.ashx?code=RSSExpandedStacked&modulewidth=0.35&unit=mm&Data={0}", c.Barcode2Value);
                imgBanner.Src = "/images/banner2.jpg";
                imgBanner.Visible = true;

                //mark the coupon as printed
                CouponPrint checkprint = new CouponPrint();
                checkprint.CouponID = couponID;
                checkprint.IPAddress = ip;
                checkprint.PrintedDate = DateTime.Now;
                _couponDAO.AddCouponPrint(checkprint);
                Session["id"] = null;
            }

        }
    }
}