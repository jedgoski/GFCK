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

namespace GFCK.Admin
{
    public partial class ManufacturerActionAction : System.Web.UI.Page
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(ManufacturerActionAction));
        FactoryDAO _factoryDAO = FactoryDAO.GetInstance();
        string _mode = null;
        long _manufacturerID = 0;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            try
            {
                BindEvents();
                GetMode();
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occurred: Exception={0}", ex.Message);
                lblError.Visible = true;
            }
        }


        protected void BindEvents()
        {
            btnSave.Click += new EventHandler(btnSave_Click);
        }

        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IMerchantDAO merchantDAO = _factoryDAO.GetMerchantDAO();
                Merchant merchant = new Merchant();
                merchant.MerchantName = txtManufacturerName.Text;
                merchant.FirstName = txtFirstName.Text;
                merchant.LastName = txtLastName.Text;
                merchant.Email = txtEmail.Text;
                merchant.PhoneNumber = txtPhoneNumber.Text;
                merchant.Address = txtAddress.Text;
                merchant.Description = txtDescription.Text;
                
                if (_manufacturerID == 0)
                {
                    // Need to add a record
                    if (merchantDAO.AddMerchant(merchant))
                    {
                        // The add was successfull
                        lblAddSuccessfull.Visible = true;
                    }
                    else
                    {
                        lblError.Visible = true;
                        _log.Debug("Unable to Add a Manufacturer.");
                    }
                }
                else
                {
                    // Need to update the record
                    if(merchantDAO.UpdateMerchant(merchant))
                    {
                        // Update was successfull
                        lblEditSuccessfull.Visible = true;
                    }
                    else
                    {
                        lblError.Visible = true;
                        _log.Debug("Unable to Update a Manufacturer.");
                    }
                }

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occurred: Exception={0}", ex.Message);
                lblError.Visible = true;
            }
        }

        protected void GetMode()
        {
            // Lets get the query string variables that can be passed in.
          
            if (!string.IsNullOrEmpty(Request.QueryString["ManufacturerID"]))
            {
                _manufacturerID = Convert.ToInt64(Request.QueryString["ManufacturerID"]);
            }
            else
            {
                _log.Debug("ManufacturerID was not found.");
            }

            if (!string.IsNullOrEmpty(Request.QueryString["Mode"]))
            {
                _mode = Request.QueryString["Mode"];
            }
            else
            {
                _log.Debug("Mode was not found, redirect to the Manufacturer Admin page.");
                Response.Redirect("/Admin/ManufacturerAdmin.aspx");
            }


            switch (_mode)
            {
                case "Add": LoadAdd(); break;
                case "View": LoadView(); break;
                case "Edit": LoadEdit(); break;
            }
           

        }

        protected void LoadAdd()
        {
            divAddManufacturer.Visible = true;
            divEditManufacturer.Visible = false;
            divViewManufacturer.Visible = false;
        }
        protected void LoadView()
        {
            divAddManufacturer.Visible = false;
            divEditManufacturer.Visible = false;
            divViewManufacturer.Visible = true;
            btnSave.Visible = false;
            LoadData();
        }
        protected void LoadEdit()
        {
            divAddManufacturer.Visible = false;
            divEditManufacturer.Visible = true;
            divViewManufacturer.Visible = false;
            LoadData();
        }

        protected void LoadData()
        {
            IMerchantDAO merchantDAO = _factoryDAO.GetMerchantDAO();
            Merchant merchant = merchantDAO.GetMerchant(_manufacturerID);
            txtManufacturerName.Text = merchant.MerchantName;
            txtFirstName.Text = merchant.FirstName;
            txtLastName.Text = merchant.LastName;
            txtEmail.Text = merchant.Email;
            txtPhoneNumber.Text = merchant.PhoneNumber;
            txtAddress.Text = merchant.Address;
            txtDescription.Text = merchant.Description;
        }
    }
}