using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Engine.DAO.Object;
using log4net;
using Engine.DAO.Domain;
using Engine.Domain.Object;
using System.Web.Security;

namespace GFCK.Admin
{
    public partial class Stats : System.Web.UI.Page
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(Stats));
        FactoryDAO _factoryDAO = FactoryDAO.GetInstance();
        long _manufacturerID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ManufacturerID"]))
            {
                _manufacturerID = Convert.ToInt64(Request.QueryString["ManufacturerID"]);
            }

            BindEvents();

            if (!IsPostBack)
            {
                GetStats(DateTime.MinValue, DateTime.MaxValue);
            }
        }

        protected void BindEvents()
        {
            ddlFilter1.SelectedIndexChanged += new EventHandler(ddlFilter1_SelectedIndexChanged);
            btnGo.Click += new ImageClickEventHandler(btnGo_Click);
            btnBack.Click +=new ImageClickEventHandler(btnBack_Click);
        }

        void btnGo_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtStartDate.Text) && !string.IsNullOrEmpty(txtEndDate.Text))
            {
                DateTime startDate = Convert.ToDateTime(txtStartDate.Text);
                DateTime endDate = Convert.ToDateTime(txtEndDate.Text);
                GetStats(startDate, endDate);
            }

        }

        void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/admin/default.aspx");
        }

        void ddlFilter1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            DateTime thisMonthsStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime thisMonthsEndDate = thisMonthsStartDate.AddMonths(1).AddDays(-1);
            DateTime LastMonthsDate = thisMonthsStartDate.AddMonths(-1);
            DateTime LastMonthsEndDate = thisMonthsStartDate.AddDays(-1);


            switch (ddlFilter1.SelectedValue)
            {
                case "all": startDate = DateTime.MinValue;
                    endDate = DateTime.MaxValue;
                    break;

                case "current": startDate = thisMonthsStartDate;
                    endDate = thisMonthsEndDate;
                    break;

                case "last": startDate = LastMonthsDate;
                    endDate = LastMonthsEndDate;
                    break;

                default: startDate = DateTime.MinValue;
                    endDate = DateTime.MaxValue;
                    break;
            }
            GetStats(startDate, endDate);
        }

        protected void GetStats(DateTime startDate, DateTime endDate)
        {
            IMerchantDAO merchantDAO = _factoryDAO.GetMerchantDAO();
            ICouponDAO couponDAO = _factoryDAO.GetCouponDAO();
            Merchant merchant = merchantDAO.GetMerchant(_manufacturerID);

            List<CouponPrint> couponPrints = couponDAO.GetCouponPrintsByMerchantID(_manufacturerID, startDate, endDate);

            litName.Text = merchant.MerchantName;

            if (couponPrints.Count == 0)
            {
                litNoDataFound.Visible = true;
            }
            else
            {
                litNoDataFound.Visible = false;
                rptCoupons.DataSource = couponPrints;
                rptCoupons.DataBind();
            }

        }

        protected void rptCoupons_ItemDataBound(object source, RepeaterItemEventArgs e)
        {
            if (e.Item == null || e.Item.DataItem == null)
            {
                return;
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Visible = false;

                CouponPrint cp = (CouponPrint)e.Item.DataItem;

                if (cp == null)
                {
                    return;
                }

                Literal litCoupon = (Literal)e.Item.FindControl("litCoupon");
                Literal litStats = (Literal)e.Item.FindControl("litStats");

                if (litCoupon == null || litStats == null)
                {
                    return;
                }

                litCoupon.Text = cp.Name;
                litStats.Text = cp.TotalPrints.ToString();

                e.Item.Visible = true;
            }
        }
    }
}