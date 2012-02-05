using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using log4net;
using Engine.DAO.Object;
using Engine.DAO.Domain;
using Engine.Domain.Object;
using System.Web.Security;
using Amazon.S3;
using Amazon.S3.Model;
//using IDAutomation;
using IDAutomation_FontEncoder;
///using IDAutomation.DatabarServerControl;

namespace GFCK.Manufacturer
{
    public partial class Action : System.Web.UI.Page
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(Action));
        FactoryDAO _factoryDAO = FactoryDAO.GetInstance();
        long _couponID = 0;
        long _manufacturerID = 0;
        string _merchantname = "";
        static string bucketName;
        static string keyName;
        static AmazonS3 client;

        protected void Page_Load(object sender, EventArgs e)
        {
            //IDAutomation.DatabarServerControl.DatabarBarcode MyBarCode = new IDAutomation.DatabarServerControl.DatabarBarcode();
            ////MyBarCode.SymbologyID = IDAutomation.DatabarServerControl.DatabarBarcode.Symbologies.DatabarStacked;
            //MyBarCode.DataToEncode = "123456789858758769698012";
            //MyBarCode.SymbologyID = DatabarBarcode.Symbologies.DatabarStackedOmnidirectional;
            //MyBarCode.XtoYRatio = 5;
            //MyBarCode.SaveImageAs(@"C:\Users\Jed\GFCK\GFCK\Manufacturer\barcodes\Test39.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            
            //clsBarCode barcodeObject = new clsBarCode();
            //barcodeObject.UPCA("0123456789012");
            //barcodeObject = null;

            if (!string.IsNullOrEmpty(Request.QueryString["CouponID"]))
            {
                _couponID = Convert.ToInt64(Request.QueryString["CouponID"]);
            }

            MembershipUser user = Membership.GetUser();
            IMerchantDAO merchantDAO = _factoryDAO.GetMerchantDAO();
            Merchant m = merchantDAO.GetMerchantByUserID((Guid)user.ProviderUserKey);
            _manufacturerID = m.ID;
            _merchantname = m.MerchantName;

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
                ICouponDAO couponDAO = _factoryDAO.GetCouponDAO();
                Coupon coupon = new Coupon();
                coupon.TemplateID = 1; // Convert.ToInt64(ddlTemplate.SelectedValue);
                coupon.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                coupon.MerchantID = _manufacturerID;

                //coupon.Image = imgByte;
                coupon.Name = txtName.Text;
                coupon.Value = txtValue.Text;
                coupon.Discount = txtDiscount.Text;
                coupon.Details = txtDetails.Text;
                coupon.Terms = txtTerms.Text;
                coupon.StartDate = Convert.ToDateTime(txtStartDate.Text);
                coupon.ExpirationDate = Convert.ToDateTime(txtExpirationDate.Text);
                coupon.GlutenFreeFacility = chkGlutenFreeFacility.Checked;
                coupon.ContainGluten20PPM = chkContainGluten20PPM.Checked;
                coupon.LessThan10PPM = chkLessThan10PPM.Checked;
                coupon.LessThan5PPM = chkLessThan5PPM.Checked;
                coupon.CaseinFree = chkCaseinFree.Checked;
                coupon.SoyFree = chkSoyFree.Checked;
                coupon.NutFree = chkNutFree.Checked;
                coupon.EggFree = chkEggFree.Checked;
                coupon.CornFree = chkCornFree.Checked;
                coupon.YeastFree = chkYeastFree.Checked;
                coupon.Barcode1Type = "UPCACCA";
                coupon.Barcode1Value = txtBarcode1Value.Text;
                coupon.Barcode2Type = "RSSExpandedStacked";
                coupon.Barcode2Value = txtBarcode2Value.Text;
                coupon.NumberOfCoupons = Convert.ToInt32(txtNumberOfCoupons.Text);
                coupon.BottomAdvertisement = "keep";
                coupon.Enabled = Convert.ToBoolean(txtEnabled.Value);

                if (_couponID == 0)
                {
                    // Need to add a record
                    _couponID = couponDAO.AddCoupon(coupon);
                }
                if (_couponID > 0)
                {
                    coupon.ID = _couponID;
                }

                try
                {
                    bool success = false;
                    string err = "";
                    FileUpload img = (FileUpload)imgUpload;
                    if (!CheckFileType(img.PostedFile.FileName))
                    {
                        err = "Sorry, Please only upload images for coupon.";
                    }
                    if (img.HasFile && img.PostedFile != null && img.PostedFile.ContentLength > 5242880)
                    {
                        err = "Sorry, File size is too large. Coupon image needs to be under 5MB.";
                    }
                    else if (img.HasFile && img.PostedFile != null)
                    {
                        //To create a PostedFile
                        HttpPostedFile File = imgUpload.PostedFile;
                        success = AddImageToAmazon(coupon, File, "");
                    }
                    else
                    {
                        coupon.Image = "keep";
                        success = couponDAO.UpdateCoupon(coupon);
                    }
                    // Need to update the record
                    if (success)
                    {
                        // Update was successfull
                        lblEditSuccessfull.Visible = true;
                        lblError.Visible = false;
                        lblAddSuccessfull.Visible = false;
                    }
                    else
                    {
                        if (err != "") lblError.Text = err;
                        lblError.Visible = true;
                        lblAddSuccessfull.Visible = false;
                        lblEditSuccessfull.Visible = false;
                        _log.DebugFormat("Unable to Update the Coupon. {0}", err);
                    }
                }
                catch (AmazonS3Exception amazonS3Exception)
                {
                    if (amazonS3Exception.ErrorCode != null &&
                        (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                        amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                    {
                        _log.Error("Please check the provided AWS Credentials.");
                    }
                    else
                    {
                        _log.Error(string.Format("An error occurred with the message '{0}' when writing an object", amazonS3Exception.Message));
                    }
                    lblError.Visible = true;
                    lblAddSuccessfull.Visible = false;
                    lblEditSuccessfull.Visible = false;
                    _log.Debug("Unable to Add a Coupon.");
                }

                //upload marketing image now only if no errors
                if (!lblError.Visible)
                {
                    try
                    {
                        bool success = false;
                        string err = "";
                        FileUpload img = (FileUpload)imgUploadMarketing;
                        if (!CheckFileType(img.PostedFile.FileName))
                        {
                            err = "Sorry, Please only upload images for advertisement.";
                        }
                        if (img.HasFile && img.PostedFile != null && img.PostedFile.ContentLength > 10485760)
                        {
                            err = "Sorry, File size is too large. Advertisement image needs to be under 10MB.";
                        }
                        else if (img.HasFile && img.PostedFile != null)
                        {
                            //To create a PostedFile
                            HttpPostedFile File = imgUploadMarketing.PostedFile;
                            success = AddImageToAmazon(coupon, File, "_marketing");
                        }
                        else
                        {
                            coupon.BottomAdvertisement = "keep";
                            success = couponDAO.UpdateCoupon(coupon);
                        }
                        // Need to update the record
                        if (success)
                        {
                            // Update was successfull
                            lblEditSuccessfull.Visible = true;
                            lblError.Visible = false;
                            lblAddSuccessfull.Visible = false;
                        }
                        else
                        {
                            if (err != "") lblError.Text = err;
                            lblError.Visible = true;
                            lblAddSuccessfull.Visible = false;
                            lblEditSuccessfull.Visible = false;
                            _log.DebugFormat("Unable to Update the Coupon. {0}", err);
                        }
                    }
                    catch (AmazonS3Exception amazonS3Exception)
                    {
                        if (amazonS3Exception.ErrorCode != null &&
                            (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                            amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                        {
                            _log.Error("Please check the provided AWS Credentials.");
                        }
                        else
                        {
                            _log.Error(string.Format("An error occurred with the message '{0}' when writing an object", amazonS3Exception.Message));
                        }
                        lblError.Visible = true;
                        lblAddSuccessfull.Visible = false;
                        lblEditSuccessfull.Visible = false;
                        _log.Debug("Unable to Add a Coupon.");
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
        private bool CheckFileType(string fileName){
            string ext = System.IO.Path.GetExtension(fileName);
            switch (ext.ToLower()){
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }
        private bool AddImageToAmazon(Coupon coupon, HttpPostedFile File, string ext)
        {
            string accessKeyID = WebConfigurationManager.AppSettings["AWSAccessKey"];
            string secretAccessKeyID = WebConfigurationManager.AppSettings["AWSSecretKey"];

            client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKeyID, secretAccessKeyID);

            ICouponDAO couponDAO = _factoryDAO.GetCouponDAO();
            Byte[] imgByte = new byte[0];
            //Create byte Array with file len
            imgByte = new Byte[File.ContentLength];
            //force the control to load data in array
            File.InputStream.Read(imgByte, 0, File.ContentLength);
            string keyname = string.Format("{0}/{1}", _merchantname, File.FileName.Replace(File.FileName.Substring(0, File.FileName.IndexOf(".")), string.Format("{0}{1}", _couponID.ToString(), ext)));
            /*try
            {
                //first try deleting old item if applicable
                DeleteObjectRequest delete_request = new DeleteObjectRequest();
                delete_request.WithBucketName("gfck").WithKey(string.Format("coupon/{0}", keyname));
                S3Response delete_response = client.DeleteObject(delete_request);
                delete_response.Dispose();
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error trying to delete object from bucket: {0} with exception {1}", keyname, ex.Message);
            }*/

            PutObjectRequest request = new PutObjectRequest();
            request.WithBucketName("gfck").WithContentType(File.ContentType).WithCannedACL(S3CannedACL.PublicRead).WithKey(string.Format("coupon/{0}", keyname)).WithInputStream(File.InputStream);
            S3Response response = client.PutObject(request);
            response.Dispose();
            if (ext == "")
            {
                coupon.Image = keyname;
            }
            else
            {
                coupon.BottomAdvertisement = keyname;
            }
            return couponDAO.UpdateCoupon(coupon);
        }

        protected void GetMode()
        {
            // Lets get the query string variables that can be passed in.
            string _mode = "";
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
                Response.Redirect("/Manufacturer/");
            }


            switch (_mode)
            {
                case "Add": LoadAdd(); break;
                case "Edit": LoadEdit(); break;
                case "Activate": Activate(true); break;
                case "Inactivate": Activate(false); break;
            }


        }

        protected void LoadAdd()
        {
            divAddCoupon.Visible = true;
            divEditCoupon.Visible = false;
            LoadDDL();
            lblCurrent.Visible = false;
            imgCurrent.Visible = false;
        }
        
        protected void LoadEdit()
        {
            divAddCoupon.Visible = false;
            divEditCoupon.Visible = true;
            lblCurrent.Visible = true;
            imgCurrent.Visible = true;
            LoadData();
        }
        
        protected void Activate(bool active)
        {
            ICouponDAO couponDAO = _factoryDAO.GetCouponDAO();
            Coupon coupon = couponDAO.GetCoupon(_couponID);
            coupon.Enabled = active;

            // Need to update the record
            if (couponDAO.UpdateCoupon(coupon))
            {
                // Update was successfull
                Response.Redirect("/Manufacturer/");
            }
            else
            {
                lblError.Visible = true;
                lblAddSuccessfull.Visible = false;
                lblEditSuccessfull.Visible = false;
                _log.Debug("Unable to Update the Coupon.");
            }
        }

        protected void LoadDDL()
        {
            ICategoryDAO categoryDAO = _factoryDAO.GetCategoryDAO();
            
            List<Category> categories = categoryDAO.GetAllActiveCategories();
            ddlCategory.DataSource = categories;
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();

        }

        protected void LoadData()
        {
            LoadDDL();
            ICouponDAO couponDAO = _factoryDAO.GetCouponDAO();
            Coupon coupon = couponDAO.GetCoupon(_couponID);

            ddlCategory.SelectedValue = Convert.ToString(coupon.CategoryID);
            txtName.Text = coupon.Name;
            if (!String.IsNullOrEmpty(coupon.Image))
            {
                imgCurrent.Src = string.Format("https://s3.amazonaws.com/gfck/coupon/{0}", coupon.Image);
            }
            else
            {
                lblCurrent.Visible = false;
                imgCurrent.Visible = false;
            }
            txtValue.Text = coupon.Value;
            txtDiscount.Text = coupon.Discount;
            txtDetails.Text = coupon.Details;
            txtTerms.Text = coupon.Terms;
            txtStartDate.Text = Convert.ToDateTime(coupon.StartDate).ToShortDateString();
            txtExpirationDate.Text = Convert.ToDateTime(coupon.ExpirationDate).ToShortDateString();
            chkGlutenFreeFacility.Checked = coupon.GlutenFreeFacility;
            chkContainGluten20PPM.Checked = coupon.ContainGluten20PPM;
            chkLessThan10PPM.Checked = coupon.LessThan10PPM;
            chkLessThan5PPM.Checked = coupon.LessThan5PPM;
            chkCaseinFree.Checked = coupon.CaseinFree;
            chkSoyFree.Checked = coupon.SoyFree;
            chkNutFree.Checked = coupon.NutFree;
            chkEggFree.Checked = coupon.EggFree;
            chkCornFree.Checked = coupon.CornFree;
            chkYeastFree.Checked = coupon.YeastFree;
            //ddlBarcode1Type.Value = coupon.Barcode1Type;
            txtBarcode1Value.Text = coupon.Barcode1Value;
            //ddlBarcode2Type.Value = coupon.Barcode2Type;
            txtBarcode2Value.Text = coupon.Barcode2Value;
            txtNumberOfCoupons.Text = coupon.NumberOfCoupons.ToString();
            if (!String.IsNullOrEmpty(coupon.BottomAdvertisement))
            {
                litImageMarketing.Text = string.Format("<a target='_blank' href='https://s3.amazonaws.com/gfck/coupon/{0}'>current image</a>", coupon.BottomAdvertisement);
            }
            else
            {
                lblCurrentMarketing.Visible = false;
                litImageMarketing.Visible = false;
            }
            txtEnabled.Value = coupon.Enabled.ToString();
        }
    }
}