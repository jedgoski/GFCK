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
    public partial class Action : System.Web.UI.Page
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(Action));
        FactoryDAO _factoryDAO = FactoryDAO.GetInstance();
        long _manufacturerID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            _manufacturerID = (string.IsNullOrEmpty(Request.QueryString["ManufacturerID"])) ? 0 : Convert.ToInt64(Request.QueryString["ManufacturerID"]);
            
            if (!IsPostBack)
            {
                try
                {
                    GetMode();
                }
                catch (Exception ex)
                {
                    _log.ErrorFormat("Exception Occurred: Exception={0}", ex.Message);
                    lblError.Visible = true;
                    lblAddSuccessfull.Visible = false;
                    lblEditSuccessfull.Visible = false;
                }
            }
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
                merchant.Address2 = txtAddress2.Text;
                merchant.City = txtCity.Text;
                merchant.State = txtState.Text;
                merchant.Zip = txtZip.Text;
                merchant.Description = txtDescription.Text;
                merchant.Deleted = false;
                
                if (_manufacturerID == 0)
                {   
                    // CReate a new user.
                    MembershipCreateStatus createStatus; 
                    MembershipUser newUser = Membership.CreateUser(txtUserName.Text, txtPassword.Text, txtEmail.Text,null, null, true, out createStatus);
                    
                    switch (createStatus)
                    {
                        case MembershipCreateStatus.Success:
                            Roles.AddUserToRole(newUser.UserName, "Manufacturer");
                            merchant.UserID = (Guid)newUser.ProviderUserKey;
                            AddManufacturerProfile(merchantDAO, merchant);
                            break;
                        default:
                            lblError.Text = createStatus.ToString();
                            lblError.Visible = true;
                            break;

                            // TODO: ceate additional status checks
                    }
                }
                else
                {
                    merchant.ID = _manufacturerID;
                    // Need to update the record
                    if(merchantDAO.UpdateMerchant(merchant))
                    {
                        // Update was successfull
                        lblEditSuccessfull.Visible = true;
                        lblError.Visible = false;
                        lblAddSuccessfull.Visible = false;
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblAddSuccessfull.Visible = false;
                        lblEditSuccessfull.Visible = false;
                        _log.Debug("Unable to Update the Manufacturer.");
                    }
                }

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occurred: Exception={0}", ex.Message);
                lblError.Visible = true;
                lblAddSuccessfull.Visible = false;
                lblEditSuccessfull.Visible = false;
            }
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                IMerchantDAO merchantDAO = _factoryDAO.GetMerchantDAO();
                // CReate a new user.
                MembershipCreateStatus createStatus;
                MembershipUser newUser = Membership.CreateUser(txtNewUserName.Text, txtNewPassword.Text, txtNewEmail.Text, null, null, true, out createStatus);

                switch (createStatus)
                {
                    case MembershipCreateStatus.Success:
                        Roles.AddUserToRole(newUser.UserName, "Manufacturer");
                        Guid UserID = (Guid)newUser.ProviderUserKey;
                        AddUserToMerchant(merchantDAO, UserID);
                        break;
                    default:
                        lblError.Text = createStatus.ToString();
                        lblError.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occurred: Exception={0}", ex.Message);
                lblError.Visible = true;
                lblAddSuccessfull.Visible = false;
                lblEditSuccessfull.Visible = false;
            }
        }

        private void AddUserToMerchant(IMerchantDAO merchantDAO, Guid UserID)
        {
            // Need to add a user to merchant
            if (merchantDAO.AddUserToMerchant(UserID, _manufacturerID))
            {
                // The add was successfull
                lblAddUserSuccess.Visible = true;
                lblAddSuccessfull.Visible = false;
                lblError.Visible = false;
                lblEditSuccessfull.Visible = false;
            }
            else
            {
                lblError.Visible = true;
                lblAddSuccessfull.Visible = false;
                lblAddUserSuccess.Visible = false;
                lblEditSuccessfull.Visible = false;
                _log.Debug("Unable to Add a new user.");
            }
        }
        
        protected void AddManufacturerProfile(IMerchantDAO merchantDAO, Merchant merchant)
        {
            // Need to add a record and create a new user
            if (merchantDAO.AddMerchant(merchant))
            {

                // The add was successfull
                lblAddSuccessfull.Visible = true;
                lblError.Visible = false;
                lblEditSuccessfull.Visible = false;
            }
            else
            {
                lblError.Visible = true;
                lblAddSuccessfull.Visible = false;
                lblEditSuccessfull.Visible = false;
                _log.Debug("Unable to Add a Manufacturer.");
            }
        }

        protected void GetMode()
        {
            // Lets get the query string variables that can be passed in.
            string _mode = "";    
      
            if (!string.IsNullOrEmpty(Request.QueryString["Mode"]))
            {
                _mode = Request.QueryString["Mode"];
            }
            else
            {
                _log.Debug("Mode was not found, redirect to the Manufacturer Admin page.");
                Response.Redirect("/Admin/");
            }

            switch (_mode)
            {
                case "Add": LoadAdd(); break;
                case "View": LoadView(); break;
                case "Edit": LoadEdit(); break;
                case "Delete": DeleteManufacturer(); break;
                case "Activate": ActivateManufacturer(); break;
            }
        }

        protected void LoadAdd()
        {
            divAddManufacturer.Visible = true;
            divEditManufacturer.Visible = false;
            divViewManufacturer.Visible = false;
            addUser.Visible = false;
        }
        
        protected void LoadView()
        {
            divAddManufacturer.Visible = false;
            divEditManufacturer.Visible = false;
            divViewManufacturer.Visible = true;
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
            txtConfirmPassword.Enabled = false;
            btnSave.Visible = false;
            LoadData();
        }
        
        protected void LoadEdit()
        {
            divAddManufacturer.Visible = false;
            divEditManufacturer.Visible = true;
            divViewManufacturer.Visible = false;
            addUser.Visible = true;
            txtUserName.Enabled = false;
            txtPassword.Enabled = false;
            txtConfirmPassword.Enabled = false;
            divPassword.Visible = false;
            LoadData();
        }

        protected void DeleteManufacturer()
        {
            //divAddManufacturer.Visible = false;
            //divEditManufacturer.Visible = true;
            //divViewManufacturer.Visible = false;
            //accountInformation.Visible = false;
            //profileInformation.Visible = false;
            //btnSave.Visible = false;
            
            IMerchantDAO merchantDAO = _factoryDAO.GetMerchantDAO();
            Merchant merchant = merchantDAO.GetMerchant(_manufacturerID);
            MembershipUser user =  Membership.GetUser((Guid)merchant.UserID);
            
            merchant.Deleted = true;
            user.IsApproved = false;
            if (merchantDAO.UpdateMerchant(merchant))
            {
                // Lock out the user
                Membership.UpdateUser(user);

                // Delete was successfull
                //lblDeleteSuccessfull.Visible = true;
                //lblError.Visible = false;
                Response.Redirect("/admin/default.aspx");
            }
            else
            {
                lblError.Visible = true;
                lblDeleteSuccessfull.Visible = false;
            }
        }

        protected void ActivateManufacturer()
        {
            //divAddManufacturer.Visible = false;
            //divEditManufacturer.Visible = true;
            //divViewManufacturer.Visible = false;
            //accountInformation.Visible = false;
            //profileInformation.Visible = false;
            //btnSave.Visible = false;

            IMerchantDAO merchantDAO = _factoryDAO.GetMerchantDAO();
            Merchant merchant = merchantDAO.GetMerchant(_manufacturerID);
            MembershipUser user = Membership.GetUser((Guid)merchant.UserID);
            merchant.Deleted = false;
            user.IsApproved = true;
            if (merchantDAO.UpdateMerchant(merchant))
            {
                // Activate the user
                Membership.UpdateUser(user);
                // Activation was successfull
                //lblActivateSuccessfull.Visible = true;
                //lblError.Visible = false;
                Response.Redirect("/admin/default.aspx");
            }
            else
            {
                lblError.Visible = true;
                lblActivateSuccessfull.Visible = false;
            }
        }

        protected void LoadData()
        {
            IMerchantDAO merchantDAO = _factoryDAO.GetMerchantDAO();
            Merchant merchant = merchantDAO.GetMerchant(_manufacturerID);
            txtUserName.Text = merchant.UserName;
            txtManufacturerName.Text = merchant.MerchantName;
            txtFirstName.Text = merchant.FirstName;
            txtLastName.Text = merchant.LastName;
            txtEmail.Text = merchant.Email;
            txtPhoneNumber.Text = merchant.PhoneNumber;
            txtAddress.Text = merchant.Address;
            txtAddress2.Text = merchant.Address2;
            txtCity.Text = merchant.City;
            txtState.Text = merchant.State;
            txtZip.Text = merchant.Zip;
            txtDescription.Text = merchant.Description;
        }
    }
}