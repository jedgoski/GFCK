using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using Engine.DAO.Object;
using Engine.Domain.Object;
using System.Web.UI.HtmlControls;
using Engine.DAO.Domain;

namespace GFCK.Admin
{
    public partial class ManufacturerAdmin : System.Web.UI.Page
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(ManufacturerAdmin));
        FactoryDAO _factoryDAO = FactoryDAO.GetInstance();
        
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            try
            {
                BindEvents();
                LoadData();
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occurred: Exception={0}", ex.Message);
                lblError.Visible = true;
                lblDeleteError.Visible = false;
                lblDeleteSuccessfull.Visible = false;
            }
        }

        protected void BindEvents()
        {
            rptManufacuturers.ItemDataBound += new RepeaterItemEventHandler(rptManufacuturers_ItemDataBound);
            rptManufacuturers.ItemCommand += new RepeaterCommandEventHandler(rptManufacuturers_ItemCommand);
        }

        void rptManufacuturers_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if(e.CommandName == "Delete")
            {
                if (!string.IsNullOrEmpty(e.CommandArgument.ToString()))
                {
                    IMerchantDAO merchantDAO = _factoryDAO.GetMerchantDAO();
                    Merchant merchant = merchantDAO.GetMerchant(Convert.ToInt64(e.CommandArgument));
                    merchant.Deleted = true;
                    if (merchantDAO.UpdateMerchant(merchant))
                    {
                        // Delete was successfull
                        lblDeleteSuccessfull.Visible = true;
                        lblError.Visible = false;
                        lblDeleteError.Visible = false;
                    }
                    else
                    {
                        lblDeleteError.Visible = true;
                        lblError.Visible = false;
                        lblDeleteSuccessfull.Visible = false;
                    }
                }
            }
            LoadData();
        }

        void rptManufacuturers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Merchant merchant = (Merchant)e.Item.DataItem;

                Label lblManufacturerName = (Label)e.Item.FindControl("lblManufacturerName");
                Label lblEmail = (Label)e.Item.FindControl("lblEmail");
                HtmlAnchor lnkEdit = (HtmlAnchor)e.Item.FindControl("lnkEdit");
                HtmlAnchor lnkView = (HtmlAnchor)e.Item.FindControl("lnkView");
                LinkButton lnkDelete = (LinkButton)e.Item.FindControl("lnkDelete");

                lblManufacturerName.Text = merchant.MerchantName;
                lblEmail.Text = merchant.Email;
                lnkEdit.HRef = string.Format(lnkEdit.HRef, merchant.ID);
                lnkView.HRef = string.Format(lnkView.HRef, merchant.ID);
                lnkDelete.CommandArgument = Convert.ToString(merchant.ID);
            }
        }

        protected void LoadData()
        {
            IMerchantDAO merchantDAO = _factoryDAO.GetMerchantDAO();
            List<Merchant> merchants = merchantDAO.GetAllActiveMerchants();
            rptManufacuturers.DataSource = merchants;
            rptManufacuturers.DataBind();
        }
    }
}