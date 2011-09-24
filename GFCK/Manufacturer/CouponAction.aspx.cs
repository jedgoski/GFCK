using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using Engine.DAO.Object;
using Engine.DAO.Domain;
using Engine.Domain.Object;

namespace GFCK.Manufacturer
{
    public partial class CouponAction : System.Web.UI.Page
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(CouponAction));
        FactoryDAO _factoryDAO = FactoryDAO.GetInstance();
        string _mode = null;
        long _couponID = 0;
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
                lblAddSuccessfull.Visible = false;
                lblEditSuccessfull.Visible = false;
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
                ICouponDAO couponDAO = _factoryDAO.GetCouponDAO();
                Coupon coupon = new Coupon();
                coupon.TemplateID = Convert.ToInt64(ddlTemplate.SelectedValue);
                coupon.CategoryID = Convert.ToInt64(ddlCategory.SelectedValue);
                // TODO: Hardcoded 1 for testing purposes.. this needs to be updated.
                coupon.MerchantID = 1;
                
                FileUpload img = (FileUpload)imgUpload;
                Byte[] imgByte = null;
                if (img.HasFile && img.PostedFile != null)
                {
                    //To create a PostedFile
                    HttpPostedFile File = imgUpload.PostedFile;
                    //Create byte Array with file len
                    imgByte = new Byte[File.ContentLength];
                    //force the control to load data in array
                    File.InputStream.Read(imgByte, 0, File.ContentLength);
                }
                coupon.Image = imgByte;
                
                coupon.Value = txtValue.Text;
                coupon.Discount = txtDiscount.Text;
                coupon.Details = txtDetails.Text;
                coupon.Terms = txtTerms.Text;
                coupon.StartDate = Convert.ToDateTime(txtStartDate.Text);
                coupon.ExpirationDate = Convert.ToDateTime(txtExpirationDate.Text);
                coupon.GlutenFreeFacility = chkGlutenFreeFacility.Checked;
                coupon.ContainGluten20PPM = chkContainGluten20PPM.Checked;
                coupon.LessThan5PPM = chkLessThan5PPM.Checked;
                coupon.CaseinFree = chkCaseinFree.Checked;
                coupon.SoyFree = chkSoyFree.Checked;
                coupon.NutFree = chkNutFree.Checked;
                coupon.EggFree = chkEggFree.Checked;
                coupon.CornFree = chkCornFree.Checked;
                coupon.YeastFree = chkYeastFree.Checked;
                coupon.Barcode1Enabled = chkBarcode1Enabled.Checked;
                coupon.Barcode1TypeID = Convert.ToInt64(ddlBarcode1TypeID.SelectedValue);
                coupon.Barcode1Value = txtBarcode1Value.Text;
                coupon.Barcode2Enabled = chkBarcode2Enabled.Checked;
                coupon.Barcode2TypeID = Convert.ToInt64(ddlBarcode2TypeID.SelectedValue);
                coupon.Barcode2Value = txtBarcode2Value.Text;
                coupon.NumberOfCoupons = Convert.ToInt32(txtNumberOfCoupons.Text);
                coupon.BottomAdvertisement = txtBottomAdvertisement.Text;
                coupon.Deleted = false;

                if (_couponID == 0)
                {
                    // Need to add a record
                    if (couponDAO.AddCoupon(coupon))
                    {
                        // The add was successfull
                        lblAddSuccessfull.Visible = true;
                        lblEditSuccessfull.Visible = false;
                        lblError.Visible = false;
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblAddSuccessfull.Visible = false;
                        lblEditSuccessfull.Visible = false;
                        _log.Debug("Unable to Add a Coupon.");
                    }
                }
                else
                {
                    // Need to update the record
                    if (couponDAO.UpdateCoupon(coupon))
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
                        _log.Debug("Unable to Update the Coupon.");
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

        protected void GetMode()
        {
            // Lets get the query string variables that can be passed in.

            if (!string.IsNullOrEmpty(Request.QueryString["CouponID"]))
            {
                _couponID = Convert.ToInt64(Request.QueryString["CouponID"]);
            }
            else
            {
                _log.Debug("CouponID was not found.");
            }

            if (!string.IsNullOrEmpty(Request.QueryString["Mode"]))
            {
                _mode = Request.QueryString["Mode"];
            }
            else
            {
                _log.Debug("Mode was not found, redirect to the Coupons page.");
                Response.Redirect("/Manufacturer/Coupons.aspx");
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
            divAddCoupon.Visible = true;
            divEditCoupon.Visible = false;
            divViewCoupon.Visible = false;
            LoadDDL();
        }
        protected void LoadView()
        {
            divAddCoupon.Visible = false;
            divEditCoupon.Visible = false;
            divViewCoupon.Visible = true;
            btnSave.Visible = false;
            LoadData();
        }
        protected void LoadEdit()
        {
            divAddCoupon.Visible = false;
            divEditCoupon.Visible = true;
            divViewCoupon.Visible = false;
            LoadData();
        }

        protected void LoadDDL()
        {
            ICategoryDAO categoryDAO = _factoryDAO.GetCategoryDAO();
            ITemplateDAO templateDAO = _factoryDAO.GetTemplateDAO();
            IBarcodeDAO barcodeDAO = _factoryDAO.GetBarcodeDAO();
            
            List<Category> categories = categoryDAO.GetAllActiveCategories();
            ddlCategory.DataSource = categories;
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();

            List<Template> templates = templateDAO.GetAllActiveTemplates();
            ddlTemplate.DataSource = templates;
            ddlTemplate.DataTextField = "Name";
            ddlTemplate.DataValueField = "ID";
            ddlTemplate.DataBind();

            List<BarcodeType> barcodeTypes = barcodeDAO.GetAllActiveBarcodeTypes();
            ddlBarcode1TypeID.DataSource = barcodeTypes;
            ddlBarcode1TypeID.DataTextField = "Name";
            ddlBarcode1TypeID.DataValueField = "ID";
            ddlBarcode1TypeID.DataBind();

            ddlBarcode2TypeID.DataSource = barcodeTypes;
            ddlBarcode2TypeID.DataTextField = "Name";
            ddlBarcode2TypeID.DataValueField = "ID";
            ddlBarcode2TypeID.DataBind();

        }

        protected void LoadData()
        {
            LoadDDL();
            ICouponDAO couponDAO = _factoryDAO.GetCouponDAO();
            Coupon coupon = couponDAO.GetCoupon(_couponID);
            ddlTemplate.SelectedValue = Convert.ToString(coupon.TemplateID);
            ddlCategory.SelectedValue = Convert.ToString(coupon.CategoryID);
            // Need to save image

            txtValue.Text = coupon.Value;
            txtDiscount.Text = coupon.Discount;
            txtDetails.Text = coupon.Details;
            txtTerms.Text = coupon.Terms;
            txtStartDate.Text = Convert.ToDateTime(coupon.StartDate).ToShortDateString();
            txtExpirationDate.Text = Convert.ToDateTime(coupon.ExpirationDate).ToShortDateString();
            chkGlutenFreeFacility.Checked = coupon.GlutenFreeFacility;
            chkContainGluten20PPM.Checked = coupon.ContainGluten20PPM;
            chkLessThan5PPM.Checked = coupon.LessThan5PPM;
            chkCaseinFree.Checked = coupon.CaseinFree;
            chkSoyFree.Checked = coupon.SoyFree;
            chkNutFree.Checked = coupon.NutFree;
            chkEggFree.Checked = coupon.EggFree;
            chkCornFree.Checked = coupon.CornFree;
            chkYeastFree.Checked = coupon.YeastFree;
            chkBarcode1Enabled.Checked = coupon.Barcode1Enabled;
            ddlBarcode1TypeID.SelectedValue = Convert.ToString(coupon.Barcode1TypeID);
            txtBarcode1Value.Text = coupon.Barcode1Value;
            chkBarcode2Enabled.Checked = coupon.Barcode2Enabled;
            ddlBarcode2TypeID.SelectedValue = Convert.ToString(coupon.Barcode2TypeID);
            txtBarcode2Value.Text = coupon.Barcode2Value;
            txtNumberOfCoupons.Text = Convert.ToString(coupon.NumberOfCoupons);
            txtBottomAdvertisement.Text = coupon.BottomAdvertisement;
        }
    }
}