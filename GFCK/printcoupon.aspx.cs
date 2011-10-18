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