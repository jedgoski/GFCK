using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Util;
using log4net;
using Engine.DAO.Domain;
using Engine.Domain.Object;
using System.Data;

namespace Engine.DAO.Object
{
    public class CouponDAO : SqlDataHelper, ICouponDAO
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(CouponDAO));
        private FactoryDAO _factoryDAO = FactoryDAO.GetInstance();
        public string _connectionString;
        public CouponDAO(string connectionString) : base(connectionString)
        {   
              _connectionString = connectionString;
        }

        public List<Coupon> GetAllCouponsForMerchantID(Int64 ID)
        {
            List<Coupon> coupons = null;
            _log.DebugFormat(@"dbo.GetAllCouponsForMerchantID: MerchantID={0}", ID);
            try
            {

                
                coupons = new List<Coupon>();
                AddSQLParameter("@MerchantID", SqlDbType.BigInt, 6, ID);
                DataSet ds = GetDatasetByCommand("dbo.GetAllCouponsForMerchantID");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Coupon coupon = new Coupon();
                    coupon.ID = Convert.ToInt64(row["ID"]);
                    coupon.MerchantID = Convert.ToInt64(row["MerchantID"]);
                    coupon.TemplateID = Convert.ToInt64(row["TemplateID"]);
                    coupon.CategoryID = Convert.ToInt32(row["CategoryID"]);
                    coupon.Name = Convert.ToString(row["Name"]);
                    coupon.CategoryName = (row["CategoryName"] == DBNull.Value) ? "" : Convert.ToString(row["CategoryName"]);
                    coupon.Image = (row["Image"] == DBNull.Value) ? new byte[0] : (Byte[])row["Image"];
                    coupon.Value = Convert.ToString(row["Value"]);
                    coupon.Discount = (row["Discount"] == DBNull.Value) ? "" : Convert.ToString(row["Discount"]);
                    coupon.Details = (row["Details"] == DBNull.Value) ? "" : Convert.ToString(row["Details"]);
                    coupon.Terms = (row["Terms"] == DBNull.Value) ? "" : Convert.ToString(row["Terms"]);
                    coupon.StartDate = row["StartDate"] != DBNull.Value ? Convert.ToDateTime(row["StartDate"]) : DateTime.MinValue;
                    coupon.ExpirationDate = (row["ExpirationDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ExpirationDate"]);
                    coupon.GlutenFreeFacility = Convert.ToBoolean(row["GlutenFreeFacility"]);
                    coupon.ContainGluten20PPM = Convert.ToBoolean(row["ContainGluten20PPM"]);
                    coupon.LessThan5PPM = Convert.ToBoolean(row["LessThan5PPM"]);
                    coupon.CaseinFree = Convert.ToBoolean(row["CaseinFree"]);
                    coupon.SoyFree = Convert.ToBoolean(row["SoyFree"]);
                    coupon.NutFree = Convert.ToBoolean(row["NutFree"]);
                    coupon.EggFree = Convert.ToBoolean(row["EggFree"]);
                    coupon.CornFree = Convert.ToBoolean(row["CornFree"]);
                    coupon.YeastFree = Convert.ToBoolean(row["YeastFree"]);
                    coupon.Barcode1Type = (row["Barcode1Type"] == DBNull.Value) ? "" : Convert.ToString(row["Barcode1Type"]);
                    coupon.Barcode1Value = (row["Barcode1Value"] == DBNull.Value) ? "" : Convert.ToString(row["Barcode1Value"]);
                    coupon.Barcode2Type = (row["Barcode2Type"] == DBNull.Value) ? "" : Convert.ToString(row["Barcode2Type"]);
                    coupon.Barcode2Value = (row["Barcode2Value"] == DBNull.Value) ? "" : Convert.ToString(row["Barcode2Value"]);
                    coupon.NumberOfCoupons = (row["NumberOfCoupons"] == DBNull.Value) ? 0 : Convert.ToInt32(row["NumberOfCoupons"]);
                    coupon.BottomAdvertisement = (row["BottomAdvertisement"] == DBNull.Value) ? "" : Convert.ToString(row["BottomAdvertisement"]);
                    coupon.CreatedDate = row["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.MinValue;
                    coupon.UpdatedDate = row["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedDate"]) : DateTime.MinValue;
                    coupon.Enabled = Convert.ToBoolean(row["Enabled"]);
                    coupon.Clicks = (row["total"] == DBNull.Value) ? 0 : Convert.ToInt32(row["total"]);
                    coupons.Add(coupon);
                }

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex);
            }

            return coupons;
        }

        public List<Coupon> GetAllCouponsByCategory(int categoryID)
        {
            List<Coupon> coupons = null;
            _log.DebugFormat(@"dbo.GetAllCouponsByCategory: categoryID={0}", categoryID);
            try
            {

                coupons = new List<Coupon>();
                AddSQLParameter("@categoryID", SqlDbType.Int, categoryID);
                DataSet ds = GetDatasetByCommand("dbo.GetAllCouponsByCategoryID");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Coupon coupon = new Coupon();
                    coupon.ID = Convert.ToInt64(row["ID"]);
                    coupon.MerchantID = Convert.ToInt64(row["MerchantID"]);
                    coupon.TemplateID = Convert.ToInt64(row["TemplateID"]);
                    coupon.CategoryID = Convert.ToInt32(row["CategoryID"]);
                    coupon.CategoryName = (row["CategoryName"] == DBNull.Value) ? "" : Convert.ToString(row["CategoryName"]);
                    coupon.Name = Convert.ToString(row["Name"]);
                    coupon.Image = (row["Image"] == DBNull.Value) ? new byte[0] : (Byte[])row["Image"];
                    coupon.Value = Convert.ToString(row["Value"]);
                    coupon.Discount = (row["Discount"] == DBNull.Value) ? "" : Convert.ToString(row["Discount"]);
                    coupon.Details = (row["Details"] == DBNull.Value) ? "" : Convert.ToString(row["Details"]);
                    coupon.Terms = (row["Terms"] == DBNull.Value) ? "" : Convert.ToString(row["Terms"]);
                    coupon.StartDate = row["StartDate"] != DBNull.Value ? Convert.ToDateTime(row["StartDate"]) : DateTime.MinValue;
                    coupon.ExpirationDate = (row["ExpirationDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ExpirationDate"]);
                    coupon.GlutenFreeFacility = Convert.ToBoolean(row["GlutenFreeFacility"]);
                    coupon.ContainGluten20PPM = Convert.ToBoolean(row["ContainGluten20PPM"]);
                    coupon.LessThan5PPM = Convert.ToBoolean(row["LessThan5PPM"]);
                    coupon.CaseinFree = Convert.ToBoolean(row["CaseinFree"]);
                    coupon.SoyFree = Convert.ToBoolean(row["SoyFree"]);
                    coupon.NutFree = Convert.ToBoolean(row["NutFree"]);
                    coupon.EggFree = Convert.ToBoolean(row["EggFree"]);
                    coupon.CornFree = Convert.ToBoolean(row["CornFree"]);
                    coupon.YeastFree = Convert.ToBoolean(row["YeastFree"]);
                    coupon.Barcode1Type = (row["Barcode1Type"] == DBNull.Value) ? "" : Convert.ToString(row["Barcode1Type"]);
                    coupon.Barcode1Value = (row["Barcode1Value"] == DBNull.Value) ? "" : Convert.ToString(row["Barcode1Value"]);
                    coupon.Barcode2Type = (row["Barcode2Type"] == DBNull.Value) ? "" : Convert.ToString(row["Barcode2Type"]);
                    coupon.Barcode2Value = (row["Barcode2Value"] == DBNull.Value) ? "" : Convert.ToString(row["Barcode2Value"]);
                    coupon.NumberOfCoupons = (row["NumberOfCoupons"] == DBNull.Value) ? 0 : Convert.ToInt32(row["NumberOfCoupons"]);
                    coupon.BottomAdvertisement = (row["BottomAdvertisement"] == DBNull.Value) ? "" : Convert.ToString(row["BottomAdvertisement"]);
                    coupon.CreatedDate = row["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.MinValue;
                    coupon.UpdatedDate = row["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedDate"]) : DateTime.MinValue;
                    coupon.Enabled = Convert.ToBoolean(row["Enabled"]);
                    coupons.Add(coupon);
                }

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex);
            }

            return coupons;
        }

        public Coupon GetCoupon(Int64 ID)
        {
            Coupon coupon = null;
            _log.DebugFormat(@"dbo.GetCoupon: ID={0}", ID);
            try
            {

                coupon = new Coupon();

                AddSQLParameter("@CouponID", SqlDbType.BigInt, 6, ID);
                DataSet ds = GetDatasetByCommand("dbo.GetCoupon");
                DataRow row = ds.Tables[0].Rows[0];

                coupon.ID = Convert.ToInt64(row["ID"]);
                coupon.MerchantID = Convert.ToInt64(row["MerchantID"]);
                coupon.TemplateID = Convert.ToInt64(row["TemplateID"]);
                coupon.CategoryID = Convert.ToInt32(row["CategoryID"]);
                coupon.CategoryName = (row["CategoryName"] == DBNull.Value) ? "" : Convert.ToString(row["CategoryName"]);
                coupon.Name = Convert.ToString(row["Name"]);
                coupon.Image = (row["Image"] == DBNull.Value) ? new byte[0] : (Byte[])row["Image"];
                coupon.Value = Convert.ToString(row["Value"]);
                coupon.Discount = (row["Discount"] == DBNull.Value) ? "" : Convert.ToString(row["Discount"]);
                coupon.Details = (row["Details"] == DBNull.Value) ? "" : Convert.ToString(row["Details"]);
                coupon.Terms = (row["Terms"] == DBNull.Value) ? "" : Convert.ToString(row["Terms"]);
                coupon.StartDate = row["StartDate"] != DBNull.Value ? Convert.ToDateTime(row["StartDate"]) : DateTime.MinValue;
                coupon.ExpirationDate = (row["ExpirationDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["ExpirationDate"]);
                coupon.GlutenFreeFacility = Convert.ToBoolean(row["GlutenFreeFacility"]);
                coupon.ContainGluten20PPM = Convert.ToBoolean(row["ContainGluten20PPM"]);
                coupon.LessThan5PPM = Convert.ToBoolean(row["LessThan5PPM"]);
                coupon.CaseinFree = Convert.ToBoolean(row["CaseinFree"]);
                coupon.SoyFree = Convert.ToBoolean(row["SoyFree"]);
                coupon.NutFree = Convert.ToBoolean(row["NutFree"]);
                coupon.EggFree = Convert.ToBoolean(row["EggFree"]);
                coupon.CornFree = Convert.ToBoolean(row["CornFree"]);
                coupon.YeastFree = Convert.ToBoolean(row["YeastFree"]);
                coupon.Barcode1Type = (row["Barcode1Type"] == DBNull.Value) ? "" : Convert.ToString(row["Barcode1Type"]);
                coupon.Barcode1Value = (row["Barcode1Value"] == DBNull.Value) ? "" : Convert.ToString(row["Barcode1Value"]);
                coupon.Barcode2Type = (row["Barcode2Type"] == DBNull.Value) ? "" : Convert.ToString(row["Barcode2Type"]);
                coupon.Barcode2Value = (row["Barcode2Value"] == DBNull.Value) ? "" : Convert.ToString(row["Barcode2Value"]);
                coupon.NumberOfCoupons = (row["NumberOfCoupons"] == DBNull.Value) ? 0 : Convert.ToInt32(row["NumberOfCoupons"]);
                coupon.BottomAdvertisement = (row["BottomAdvertisement"] == DBNull.Value) ? "" : Convert.ToString(row["BottomAdvertisement"]);
                coupon.CreatedDate = row["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.MinValue;
                coupon.UpdatedDate = row["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedDate"]) : DateTime.MinValue;
                coupon.Enabled = Convert.ToBoolean(row["Enabled"]);

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex);
            }

            return coupon;
        }

        public bool UpdateCoupon(Coupon coupon)
        {
            bool success = false;
            _log.DebugFormat(@"dbo.UpdateCoupon:
                                ID={0} 
                                MerchantID={1},
                                TemplateID={2},
                                CategoryID={3},
                                Value={4},
                                Discount={5},
                                Details={6},
                                Terms={7},
                                StartDate={8},
                                ExpirationDate={9},
                                GlutenFreeFacility={10},
                                ContainGluten20PPM={11},
                                LessThan5PPM={12},
                                CaseinFree={13},
                                SoyFree={14},
                                NutFree={15},
                                EggFree={16},
                                CornFree={17},
                                YeastFree={18},
                                Barcode1Type={19},
                                Barcode1Value={20},
                                Barcode2Type={21},
                                Barcode2Value={22},
                                NumberOfCoupons={23},
                                BottomAdvertisement={24},
                                CreatedDate={25},
                                UpdatedDate={26},
                                Enabled={27}", 
                                coupon.ID,
                                coupon.MerchantID,
                                coupon.TemplateID,
                                coupon.CategoryID,
                                coupon.Value,
                                coupon.Discount,
                                coupon.Details,
                                coupon.Terms,
                                coupon.StartDate,
                                coupon.ExpirationDate,
                                coupon.GlutenFreeFacility,
                                coupon.ContainGluten20PPM,
                                coupon.LessThan5PPM,
                                coupon.CaseinFree,
                                coupon.SoyFree,
                                coupon.NutFree,
                                coupon.EggFree,
                                coupon.CornFree,
                                coupon.YeastFree,
                                coupon.Barcode1Type,
                                coupon.Barcode1Value,
                                coupon.Barcode2Type,
                                coupon.Barcode2Value,
                                coupon.NumberOfCoupons,
                                coupon.BottomAdvertisement,
                                coupon.CreatedDate,
                                coupon.UpdatedDate,
                                coupon.Enabled
                                );
            try
            {
                AddSQLParameter("@CouponID", SqlDbType.BigInt, coupon.ID);
                AddSQLParameter("@MerchantID", SqlDbType.BigInt, coupon.MerchantID);
                AddSQLParameter("@TemplateID", SqlDbType.BigInt, coupon.TemplateID);
                AddSQLParameter("@CategoryID", SqlDbType.Int, coupon.CategoryID);
                AddSQLParameter("@Image", SqlDbType.Image, coupon.Image);
                AddSQLParameter("@Value", SqlDbType.NVarChar, 50, coupon.Value);
                AddSQLParameter("@Discount", SqlDbType.NVarChar, 50, coupon.Discount);
                AddSQLParameter("@Details", SqlDbType.NText, coupon.Details);
                AddSQLParameter("@Terms", SqlDbType.NText, coupon.Terms);
                AddSQLParameter("@StartDate", SqlDbType.DateTime, 12, coupon.StartDate);
                AddSQLParameter("@ExpirationDate", SqlDbType.DateTime, 12, coupon.ExpirationDate);
                AddSQLParameter("@GlutenFreeFacility", SqlDbType.Bit, 2, coupon.GlutenFreeFacility);
                AddSQLParameter("@ContainGluten20PPM", SqlDbType.Bit, 2, coupon.ContainGluten20PPM);
                AddSQLParameter("@LessThan5PPM", SqlDbType.Bit, 2, coupon.LessThan5PPM);
                AddSQLParameter("@CaseinFree", SqlDbType.Bit, 2, coupon.CaseinFree);
                AddSQLParameter("@SoyFree", SqlDbType.Bit, 2, coupon.SoyFree);
                AddSQLParameter("@NutFree", SqlDbType.Bit, 2, coupon.NutFree);
                AddSQLParameter("@EggFree", SqlDbType.Bit, 2, coupon.EggFree);
                AddSQLParameter("@CornFree", SqlDbType.Bit, 2, coupon.CornFree);
                AddSQLParameter("@YeastFree", SqlDbType.Bit, 2, coupon.YeastFree);
                AddSQLParameter("@Barcode1Type", SqlDbType.NVarChar, 50, coupon.Barcode1Type);
                AddSQLParameter("@Barcode1Value", SqlDbType.NVarChar, 50, coupon.Barcode1Value);
                AddSQLParameter("@Barcode2Type", SqlDbType.NVarChar, 50, coupon.Barcode2Type);
                AddSQLParameter("@Barcode2Value", SqlDbType.NVarChar, 50, coupon.Barcode2Value);
                AddSQLParameter("@NumberOfCoupons", SqlDbType.Int, 2, coupon.NumberOfCoupons);
                AddSQLParameter("@BottomAdvertisement", SqlDbType.NVarChar, 255, coupon.BottomAdvertisement);
                AddSQLParameter("@Enabled", SqlDbType.Bit, 2, coupon.Enabled);
                AddSQLParameter("@Name", SqlDbType.NVarChar, 100, coupon.Name);
                GetExecuteNonQueryByCommand("dbo.UpdateCoupon");

                success = true;
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex);
            }

            return success;
        }

        public bool AddCoupon(Coupon coupon)
        {
            bool success = false;
            _log.DebugFormat(@"dbo.AddCoupon: 
                                 ID={0} 
                                MerchantID={1},
                                TemplateID={2},
                                CategoryID={3},
                                Value={4},
                                Discount={5},
                                Details={6},
                                Terms={7},
                                StartDate={8},
                                ExpirationDate={9},
                                GlutenFreeFacility={10},
                                ContainGluten20PPM={11},
                                LessThan5PPM={12},
                                CaseinFree={13},
                                SoyFree={14},
                                NutFree={15},
                                EggFree={16},
                                CornFree={17},
                                YeastFree={18},
                                Barcode1Type={20},
                                Barcode1Value={21},
                                Barcode2Type={23},
                                Barcode2Value={24},
                                NumberOfCoupons={25},
                                BottomAdvertisement={26},
                                CreatedDate={27},
                                UpdatedDate={28},
                                Deleted={29},
                                Name={30}",
                                coupon.ID,
                                coupon.MerchantID,
                                coupon.TemplateID,
                                coupon.CategoryID,
                                coupon.Value,
                                coupon.Discount,
                                coupon.Details,
                                coupon.Terms,
                                coupon.StartDate,
                                coupon.ExpirationDate,
                                coupon.GlutenFreeFacility,
                                coupon.ContainGluten20PPM,
                                coupon.LessThan5PPM,
                                coupon.CaseinFree,
                                coupon.SoyFree,
                                coupon.NutFree,
                                coupon.EggFree,
                                coupon.CornFree,
                                coupon.YeastFree,
                                coupon.Barcode1Type,
                                coupon.Barcode1Value,
                                coupon.Barcode2Type,
                                coupon.Barcode2Value,
                                coupon.NumberOfCoupons,
                                coupon.BottomAdvertisement,
                                coupon.CreatedDate,
                                coupon.UpdatedDate,
                                coupon.Enabled,
                                coupon.Name
                                );
            try
            {


                AddSQLParameter("@MerchantID", SqlDbType.BigInt, coupon.MerchantID);
                AddSQLParameter("@TemplateID", SqlDbType.BigInt, coupon.TemplateID);
                AddSQLParameter("@CategoryID", SqlDbType.Int, coupon.CategoryID);
                AddSQLParameter("@Image", SqlDbType.Image, coupon.Image);
                AddSQLParameter("@Value", SqlDbType.NVarChar, 50, coupon.Value);
                AddSQLParameter("@Discount", SqlDbType.NVarChar, 50, coupon.Discount);
                AddSQLParameter("@Details", SqlDbType.NText, coupon.Details);
                AddSQLParameter("@Terms", SqlDbType.NText, coupon.Terms);
                AddSQLParameter("@StartDate", SqlDbType.DateTime, 12, coupon.StartDate);
                AddSQLParameter("@ExpirationDate", SqlDbType.DateTime, 12, coupon.ExpirationDate);
                AddSQLParameter("@GlutenFreeFacility", SqlDbType.Bit, 2, coupon.GlutenFreeFacility);
                AddSQLParameter("@ContainGluten20PPM", SqlDbType.Bit, 2, coupon.ContainGluten20PPM);
                AddSQLParameter("@LessThan5PPM", SqlDbType.Bit, 2, coupon.LessThan5PPM);
                AddSQLParameter("@CaseinFree", SqlDbType.Bit, 2, coupon.CaseinFree);
                AddSQLParameter("@SoyFree", SqlDbType.Bit, 2, coupon.SoyFree);
                AddSQLParameter("@NutFree", SqlDbType.Bit, 2, coupon.NutFree);
                AddSQLParameter("@EggFree", SqlDbType.Bit, 2, coupon.EggFree);
                AddSQLParameter("@CornFree", SqlDbType.Bit, 2, coupon.CornFree);
                AddSQLParameter("@YeastFree", SqlDbType.Bit, 2, coupon.YeastFree);
                AddSQLParameter("@Barcode1Type", SqlDbType.NVarChar, 50, coupon.Barcode1Type);
                AddSQLParameter("@Barcode1Value", SqlDbType.NVarChar, 50, coupon.Barcode1Value);
                AddSQLParameter("@Barcode2Type", SqlDbType.NVarChar, 50, coupon.Barcode2Type);
                AddSQLParameter("@Barcode2Value", SqlDbType.NVarChar, 50, coupon.Barcode2Value);
                AddSQLParameter("@NumberOfCoupons", SqlDbType.Int, 2, coupon.NumberOfCoupons);
                AddSQLParameter("@BottomAdvertisement", SqlDbType.NVarChar, 255, coupon.BottomAdvertisement);
                AddSQLParameter("@Enabled", SqlDbType.Bit, 2, coupon.Enabled);
                AddSQLParameter("@Name", SqlDbType.NVarChar, 100, coupon.Name);
                GetExecuteNonQueryByCommand("dbo.AddCoupon");
                success = true;

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex);
            }

            return success;
        }


        public bool AddCouponPrint(CouponPrint couponPrint)
        {
            bool success = false;
            _log.DebugFormat(@"dbo.AddCouponPrint: 
                                CouponID={0},
                                PrintedDate={1},
                                IPAddress={2}",
                                couponPrint.CouponID,
                                couponPrint.PrintedDate,
                                couponPrint.IPAddress
                                );
            try
            {

                AddSQLParameter("@CouponID", SqlDbType.BigInt, 6, couponPrint.CouponID);
                AddSQLParameter("@IPAddress", SqlDbType.VarChar, 50, couponPrint.IPAddress);
                
                GetExecuteNonQueryByCommand("dbo.AddCouponPrint");

                success = true;

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex);
            }

            return success;
        }

        public List<CouponPrint> GetCouponPrintsForCouponID(Int64 couponID)
        {
            List<CouponPrint> couponPrints = null;
            _log.DebugFormat(@"dbo.GetCouponPrintsForCouponID: CouponID={0}", couponID);
            try
            {

                CouponPrint couponPrint = new CouponPrint();
                couponPrints = new List<CouponPrint>();
                AddSQLParameter("@CouponID", SqlDbType.BigInt, 6, couponID);
                DataSet ds = GetDatasetByCommand("dbo.GetCouponPrintsForCouponID");
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    couponPrint.ID = Convert.ToInt64(row["ID"]);
                    couponPrint.CouponID = Convert.ToInt64(row["CouponID"]);
                    couponPrint.PrintedDate = Convert.ToDateTime(row["PrintedDate"]);
                    couponPrint.IPAddress = Convert.ToString(row["IPAddress"]);
                    
                    couponPrints.Add(couponPrint);
                }

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex);
            }

            return couponPrints;
        }
    }
}
