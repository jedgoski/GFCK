using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Engine.DAO.Object;
using log4net;
using Engine.Domain.Object;
using System.Text.RegularExpressions;

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
            if(!String.IsNullOrEmpty(Request.QueryString["test"]) && Request.QueryString["test"] == "true")
                Session["id"] = 3;
            if (Session["id"] != null)
            {
                couponID = Convert.ToInt64(Session["id"]);
                CouponDAO _couponDAO = (CouponDAO)_factoryDAO.GetCouponDAO();

                //get the number of prints
                List<CouponPrint> prints = _couponDAO.GetCouponPrintsForCouponID(couponID);
                int numPrints = prints.Count;

                //Get the coupon info for display
                Coupon c = _couponDAO.GetCoupon(couponID);
                litExpDate.Text = Convert.ToDateTime(c.ExpirationDate).ToString("MM/dd/yyyy");
                img.Src = String.Format("https://s3.amazonaws.com/gfck/coupon/{0}", c.Image);
                string strDotScan = GenerateDotScan(c.MerchantID, c.ID, numPrints);
                //dotscan.Src = String.Format("BarcodeHandler.ashx?code=PDF417&modulewidth=.3&unit=mm&Data={0}", strDotScan);
                dotscan.Src = String.Format("http://www.tec-it.com/aspx/service/tbarcode/barcode.ashx?accesskey=demo&code=PDF417&modulewidth=min&Data={0}", strDotScan);
                litDotScan.Text = strDotScan;
                litValue.Text = c.Value;// String.Format("{0:C}", Convert.ToDecimal(c.Value));
                litName.Text = (c.Name.ToLower().IndexOf("on ") == 0) ? c.Name : String.Format("on {0}", c.Name);
                litTerms.Text = c.Terms.Replace("Retailer:", "<b>Retailer:</b>").Replace("Consumer:", "<b>Consumer:</b>");
                imgBarcode1.Src = String.Format("http://www.tec-it.com/aspx/service/tbarcode/barcode.ashx?accesskey=demo&code=UPCA&modulewidth=min&dpi=76&Data={0}", c.Barcode1Value);
                imgBarcode2.Src = String.Format("http://www.tec-it.com/aspx/service/tbarcode/barcode.ashx?accesskey=demo&code=RSSExpandedStacked&modulewidth=min&Data={0}", c.Barcode2Value);
                imgBanner.Src = String.Format("https://s3.amazonaws.com/gfck/coupon/{0}", c.BottomAdvertisement); // "/images/banner2.jpg";
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

        private string GenerateDotScan(long merchantID, long couponID, int prints)
        {
            string mCode = Regex.Replace(merchantID.ToString(), @"\d+", m => m.Value.PadLeft(4, '0'));
            string cCode = Regex.Replace(couponID.ToString(), @"\d+", m => m.Value.PadLeft(8, '0'));
            cCode = cCode.Insert(4, " ");
            string pCode = Regex.Replace(prints.ToString(), @"\d+", m => m.Value.PadLeft(4, '0'));

            return String.Format("{0} {1} {2}", mCode, cCode, pCode);
        }
    }
}