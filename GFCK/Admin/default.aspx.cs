﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Engine.DAO.Object;
using Engine.DAO.Domain;
using Engine.Domain.Object;

namespace GFCK.Admin
{
    public partial class _default : System.Web.UI.Page
    {
        FactoryDAO _factoryDAO = FactoryDAO.GetInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void LoadData()
        {
            IMerchantDAO merchantDAO = _factoryDAO.GetMerchantDAO();
            List<Merchant> merchants = merchantDAO.GetAllActiveMerchants();
            rptManufacturers.DataSource = merchants;
            rptManufacturers.DataBind();
        }

        protected void rptManufacturers_ItemDataBound(object source, RepeaterItemEventArgs e)
        {
            if (e.Item == null || e.Item.DataItem == null)
            {
                return;
            }
            
            Merchant m = (Merchant)e.Item.DataItem;

            if (m == null)
            {
                return;
            }

            Literal litName = (Literal)e.Item.FindControl("litName");
            HtmlAnchor linkEdit = (HtmlAnchor)e.Item.FindControl("linkEdit");
            HtmlAnchor linkDelete = (HtmlAnchor)e.Item.FindControl("linkDelete");
            HtmlAnchor linkStats = (HtmlAnchor)e.Item.FindControl("linkStats");

            if (litName == null || linkEdit == null || linkDelete == null || linkStats == null)
            {
                return;
            }

            litName.Text = m.MerchantName;
            linkEdit.HRef = string.Format("/admin/action.aspx?manufacturerid={0}&Mode=Edit", m.ID);
            linkDelete.HRef = string.Format("/admin/action.aspx?manufacturerid={0}&Mode=Delete", m.ID);
            linkStats.HRef = string.Format("/admin/stats.aspx?manufacturerid={0}", m.ID);
        }


    }
}