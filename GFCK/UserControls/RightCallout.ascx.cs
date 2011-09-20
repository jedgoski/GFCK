using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Engine.DAO.Object;
using Engine.DAO.Domain;
using Engine.Domain.Object;
using log4net;

namespace GFCK.UserControls
{
    public partial class RightCallout : System.Web.UI.UserControl
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(RightCallout));
        FactoryDAO _factoryDAO = FactoryDAO.GetInstance();
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            LoadData();
        }

        protected void LoadData()
        {   
            IMerchantDAO merchantDAO = _factoryDAO.GetMerchantDAO();
            List<Merchant> merchants = merchantDAO.GetAllActiveMerchants();
            ddlManufacturers.DataSource = merchants;
            ddlManufacturers.DataValueField = "ID";
            ddlManufacturers.DataTextField = "MerchantName";
            ddlManufacturers.DataBind();
            ListItem li = new ListItem("Select One", "-1");
            ddlManufacturers.Items.Insert(0, li);

        }
    }
}