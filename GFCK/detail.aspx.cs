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
    public partial class detail : System.Web.UI.Page
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(detail));
        FactoryDAO _factoryDAO = FactoryDAO.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            string ip = Request.UserHostAddress;
            long couponID = 0;
            divPrint.Visible = true;
            
            if(Request.QueryString["id"] != null && Request.QueryString["id"] != ""){
                couponID = Convert.ToInt64(Request.QueryString["id"]);
                Session["id"] = couponID;
            }

            CouponDAO _couponDAO = (CouponDAO)_factoryDAO.GetCouponDAO();
            List<CouponPrint> prints = _couponDAO.GetCouponPrintsForCouponID(couponID);
            if (prints.Count > 0)
            {
                CouponPrint p = prints.First(i => i.IPAddress == ip);
                if (p != null)
                {
                    divPrint.Visible = false;
                }
            }
        }
    }
}