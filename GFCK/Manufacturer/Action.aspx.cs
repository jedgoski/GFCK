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
            string accessKeyID = WebConfigurationManager.AppSettings["AWSAccessKey"];
            string secretAccessKeyID = WebConfigurationManager.AppSettings["AWSSecretKey"];

            client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKeyID, secretAccessKeyID);
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
                coupon.LessThan5PPM = chkLessThan5PPM.Checked;
                coupon.CaseinFree = chkCaseinFree.Checked;
                coupon.SoyFree = chkSoyFree.Checked;
                coupon.NutFree = chkNutFree.Checked;
                coupon.EggFree = chkEggFree.Checked;
                coupon.CornFree = chkCornFree.Checked;
                coupon.YeastFree = chkYeastFree.Checked;
                coupon.Barcode1Type = ddlBarcode1Type.Value;
                coupon.Barcode1Value = txtBarcode1Value.Text;
                coupon.Barcode2Type = ddlBarcode2Type.Value;
                coupon.Barcode2Value = txtBarcode2Value.Text;
                coupon.NumberOfCoupons = Convert.ToInt32(txtNumberOfCoupons.Text);
                coupon.BottomAdvertisement = txtBottomAdvertisement.Text;
                coupon.Enabled = false;

                if (_couponID == 0)
                {
                   // _couponID = couponDAO.AddCoupon(coupon);
                    _couponID = 7;
                    // Need to add a record
                    if (_couponID > 0)
                    {
                        try
                        {
                            FileUpload img = (FileUpload)imgUpload;
                            Byte[] imgByte = new byte[0];
                            if (img.HasFile && img.PostedFile != null)
                            {
                                //To create a PostedFile
                                HttpPostedFile File = imgUpload.PostedFile;
                                //Create byte Array with file len
                                imgByte = new Byte[File.ContentLength];
                                //force the control to load data in array
                                File.InputStream.Read(imgByte, 0, File.ContentLength);

                                PutObjectRequest request = new PutObjectRequest();
                                string keyname = string.Format("{0}/{1}", _merchantname, File.FileName.Replace(File.FileName.Substring(0,File.FileName.IndexOf(".")),_couponID.ToString()));
                                request.WithBucketName("gfck").WithContentType(File.ContentType).WithCannedACL(S3CannedACL.PublicRead).WithKey(string.Format("coupon/{0}",keyname)).WithInputStream(File.InputStream);
                                S3Response response = client.PutObject(request);
                                response.Dispose();

                                coupon.Image = keyname;
                                couponDAO.UpdateCoupon(coupon);
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
                        }
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
        }
        protected void LoadEdit()
        {
            divAddCoupon.Visible = false;
            divEditCoupon.Visible = true;
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
            //ITemplateDAO templateDAO = _factoryDAO.GetTemplateDAO();
            //IBarcodeDAO barcodeDAO = _factoryDAO.GetBarcodeDAO();
            
            List<Category> categories = categoryDAO.GetAllActiveCategories();
            ddlCategory.DataSource = categories;
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();

            //List<Template> templates = templateDAO.GetAllActiveTemplates();
            //ddlTemplate.DataSource = templates;
            //ddlTemplate.DataTextField = "Name";
            //ddlTemplate.DataValueField = "ID";
            //ddlTemplate.DataBind();

            //List<BarcodeType> barcodeTypes = barcodeDAO.GetAllActiveBarcodeTypes();
            //ddlBarcode1TypeID.DataSource = barcodeTypes;
            //ddlBarcode1TypeID.DataTextField = "Name";
            //ddlBarcode1TypeID.DataValueField = "ID";
            //ddlBarcode1TypeID.DataBind();

            //ddlBarcode2TypeID.DataSource = barcodeTypes;
            //ddlBarcode2TypeID.DataTextField = "Name";
            //ddlBarcode2TypeID.DataValueField = "ID";
            //ddlBarcode2TypeID.DataBind();

        }

        protected void LoadData()
        {
            LoadDDL();
            ICouponDAO couponDAO = _factoryDAO.GetCouponDAO();
            Coupon coupon = couponDAO.GetCoupon(_couponID);
            //ddlTemplate.SelectedValue = Convert.ToString(coupon.TemplateID);
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
            ddlBarcode1Type.Value = coupon.Barcode1Type;
            txtBarcode1Value.Text = coupon.Barcode1Value;
            ddlBarcode2Type.Value = coupon.Barcode2Type;
            txtBarcode2Value.Text = coupon.Barcode2Value;
            txtNumberOfCoupons.Text = coupon.NumberOfCoupons.ToString();
            txtBottomAdvertisement.Text = coupon.BottomAdvertisement;
        }
    }
}