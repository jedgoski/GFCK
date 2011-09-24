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
                    coupon.CategoryID = Convert.ToInt64(row["CategoryID"]);
                    coupon.CategoryName = Convert.ToString(row["CategoryName"]);
                    coupon.Image = (Byte[])row["Image"];
                    coupon.Value = Convert.ToString(row["Value"]);
                    coupon.Discount = Convert.ToString(row["Discount"]);
                    coupon.Details = Convert.ToString(row["Details"]);
                    coupon.Terms = Convert.ToString(row["Terms"]);
                    coupon.StartDate = row["StartDate"] != DBNull.Value ? Convert.ToDateTime(row["StartDate"]) : DateTime.MinValue;
                    coupon.ExpirationDate = Convert.ToDateTime(row["ExpirationDate"]);
                    coupon.GlutenFreeFacility = Convert.ToBoolean(row["GlutenFreeFacility"]);
                    coupon.ContainGluten20PPM = Convert.ToBoolean(row["ContainGluten20PPM"]);
                    coupon.LessThan5PPM = Convert.ToBoolean(row["LessThan5PPM"]);
                    coupon.CaseinFree = Convert.ToBoolean(row["CaseinFree"]);
                    coupon.SoyFree = Convert.ToBoolean(row["SoyFree"]);
                    coupon.NutFree = Convert.ToBoolean(row["NutFree"]);
                    coupon.EggFree = Convert.ToBoolean(row["EggFree"]);
                    coupon.CornFree = Convert.ToBoolean(row["CornFree"]);
                    coupon.YeastFree = Convert.ToBoolean(row["YeastFree"]);
                    coupon.Barcode1Enabled = Convert.ToBoolean(row["Barcode1Enabled"]);
                    coupon.Barcode1TypeID = Convert.ToInt64(row["Barcode1TypeID"]);
                    coupon.Barcode1TypeName = Convert.ToString(row["Barcode1TypeName"]);
                    coupon.Barcode1Value = Convert.ToString(row["Barcode1Value"]);
                    coupon.Barcode2Enabled = Convert.ToBoolean(row["Barcode2Enabled"]);
                    coupon.Barcode2TypeID = Convert.ToInt64(row["Barcode2TypeID"]);
                    coupon.Barcode2TypeName = Convert.ToString(row["Barcode2TypeName"]);
                    coupon.Barcode2Value = Convert.ToString(row["Barcode2Value"]);
                    coupon.NumberOfCoupons = Convert.ToInt32(row["NumberOfCoupons"]);
                    coupon.BottomAdvertisement = Convert.ToString(row["BottomAdvertisement"]);
                    coupon.CreatedDate = row["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.MinValue;
                    coupon.UpdatedDate = row["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedDate"]) : DateTime.MinValue;
                    coupon.Deleted = Convert.ToBoolean(row["Deleted"]);
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
                    coupon.CategoryID = Convert.ToInt64(row["CategoryID"]);
                    coupon.CategoryName = Convert.ToString(row["CategoryName"]);
                    coupon.Image = Convert.ToByte(row["Image"]);
                    coupon.Value = Convert.ToString(row["Value"]);
                    coupon.Discount = Convert.ToString(row["Discount"]);
                    coupon.Details = Convert.ToString(row["Details"]);
                    coupon.Terms = Convert.ToString(row["Terms"]);
                    coupon.StartDate = row["StartDate"] != DBNull.Value ? Convert.ToDateTime(row["StartDate"]) : DateTime.MinValue;
                    coupon.ExpirationDate = Convert.ToDateTime(row["ExpirationDate"]);
                    coupon.GlutenFreeFacility = Convert.ToBoolean(row["GlutenFreeFacility"]);
                    coupon.ContainGluten20PPM = Convert.ToBoolean(row["ContainGluten20PPM"]);
                    coupon.LessThan5PPM = Convert.ToBoolean(row["LessThan5PPM"]);
                    coupon.CaseinFree = Convert.ToBoolean(row["CaseinFree"]);
                    coupon.SoyFree = Convert.ToBoolean(row["SoyFree"]);
                    coupon.NutFree = Convert.ToBoolean(row["NutFree"]);
                    coupon.EggFree = Convert.ToBoolean(row["EggFree"]);
                    coupon.CornFree = Convert.ToBoolean(row["CornFree"]);
                    coupon.YeastFree = Convert.ToBoolean(row["YeastFree"]);
                    coupon.Barcode1Enabled = Convert.ToBoolean(row["Barcode1Enabled"]);
                    coupon.Barcode1TypeID = Convert.ToInt64(row["Barcode1TypeID"]);
                    coupon.Barcode1TypeName = Convert.ToString(row["Barcode1TypeName"]);
                    coupon.Barcode1Value = Convert.ToString(row["Barcode1Value"]);
                    coupon.Barcode2Enabled = Convert.ToBoolean(row["Barcode2Enabled"]);
                    coupon.Barcode2TypeID = Convert.ToInt64(row["Barcode2TypeID"]);
                    coupon.Barcode2TypeName = Convert.ToString(row["Barcode2TypeName"]);
                    coupon.Barcode2Value = Convert.ToString(row["Barcode2Value"]);
                    coupon.NumberOfCoupons = Convert.ToInt32(row["NumberOfCoupons"]);
                    coupon.BottomAdvertisement = Convert.ToString(row["BottomAdvertisement"]);
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
                coupon.CategoryID = Convert.ToInt64(row["CategoryID"]);
                coupon.CategoryName = Convert.ToString(row["CategoryName"]);
                coupon.Image = (Byte[])row["Image"];
                coupon.Value = Convert.ToString(row["Value"]);
                coupon.Discount = Convert.ToString(row["Discount"]);
                coupon.Details = Convert.ToString(row["Details"]);
                coupon.Terms = Convert.ToString(row["Terms"]);
                coupon.StartDate = row["StartDate"] != DBNull.Value ? Convert.ToDateTime(row["StartDate"]) : DateTime.MinValue;
                coupon.ExpirationDate = Convert.ToDateTime(row["ExpirationDate"]);
                coupon.GlutenFreeFacility = Convert.ToBoolean(row["GlutenFreeFacility"]);
                coupon.ContainGluten20PPM = Convert.ToBoolean(row["ContainGluten20PPM"]);
                coupon.LessThan5PPM = Convert.ToBoolean(row["LessThan5PPM"]);
                coupon.CaseinFree = Convert.ToBoolean(row["CaseinFree"]);
                coupon.SoyFree = Convert.ToBoolean(row["SoyFree"]);
                coupon.NutFree = Convert.ToBoolean(row["NutFree"]);
                coupon.EggFree = Convert.ToBoolean(row["EggFree"]);
                coupon.CornFree = Convert.ToBoolean(row["CornFree"]);
                coupon.YeastFree = Convert.ToBoolean(row["YeastFree"]);
                coupon.Barcode1Enabled = Convert.ToBoolean(row["Barcode1Enabled"]);
                coupon.Barcode1TypeID = Convert.ToInt64(row["Barcode1TypeID"]);
                coupon.Barcode1TypeName = Convert.ToString(row["Barcode1TypeName"]);
                coupon.Barcode1Value = Convert.ToString(row["Barcode1Value"]);
                coupon.Barcode2Enabled = Convert.ToBoolean(row["Barcode2Enabled"]);
                coupon.Barcode2TypeID = Convert.ToInt64(row["Barcode2TypeID"]);
                coupon.Barcode2TypeName = Convert.ToString(row["Barcode2TypeName"]);
                coupon.Barcode2Value = Convert.ToString(row["Barcode2Value"]);
                coupon.NumberOfCoupons = Convert.ToInt32(row["NumberOfCoupons"]);
                coupon.BottomAdvertisement = Convert.ToString(row["BottomAdvertisement"]);
                coupon.CreatedDate = row["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.MinValue;
                coupon.UpdatedDate = row["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedDate"]) : DateTime.MinValue;
                coupon.Deleted = Convert.ToBoolean(row["Deleted"]);

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
                                Barcode1Enabled={19},
                                Barcode1TypeID={20},
                                Barcode1Value={21},
                                Barcode2Enabled={22},
                                Barcode2TypeID={23},
                                Barcode2Value={24},
                                NumberOfCoupons={25},
                                BottomAdvertisement={26},
                                CreatedDate={27},
                                UpdatedDate={28},
                                Deleted={29}", 
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
                                coupon.Barcode1Enabled,
                                coupon.Barcode1TypeID,
                                coupon.Barcode1Value,
                                coupon.Barcode2Enabled,
                                coupon.Barcode2TypeID,
                                coupon.Barcode2Value,
                                coupon.NumberOfCoupons,
                                coupon.BottomAdvertisement,
                                coupon.CreatedDate,
                                coupon.UpdatedDate,
                                coupon.Deleted
                                );
            try
            {
                AddSQLParameter("@CouponID", SqlDbType.BigInt, 6, coupon.ID);
                AddSQLParameter("@MerchantID", SqlDbType.BigInt, 6, coupon.MerchantID);
                AddSQLParameter("@TemplateID", SqlDbType.BigInt, 6, coupon.TemplateID);
                AddSQLParameter("@CategoryID", SqlDbType.BigInt, 6, coupon.CategoryID);
                AddSQLParameter("@Image", SqlDbType.Image, 8000, coupon.Image);
                AddSQLParameter("@Value", SqlDbType.VarChar, 50, coupon.Value);
                AddSQLParameter("@Discount", SqlDbType.VarChar, 255, coupon.Discount);
                AddSQLParameter("@Details", SqlDbType.VarChar, 255, coupon.Details);
                AddSQLParameter("@Terms", SqlDbType.VarChar, 255, coupon.Terms);
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
                AddSQLParameter("@Barcode1Enabled", SqlDbType.Bit, 2, coupon.Barcode1Enabled);
                AddSQLParameter("@Barcode1TypeID", SqlDbType.BigInt, 6, coupon.Barcode1TypeID);
                AddSQLParameter("@Barcode1Value", SqlDbType.VarChar, 50, coupon.Barcode1Value);
                AddSQLParameter("@Barcode2Enabled", SqlDbType.Bit, 2, coupon.Barcode2Enabled);
                AddSQLParameter("@Barcode2TypeID", SqlDbType.BigInt, 6, coupon.Barcode2TypeID);
                AddSQLParameter("@Barcode2Value", SqlDbType.VarChar, 50, coupon.Barcode2Value);
                AddSQLParameter("@NumberOfCoupons", SqlDbType.Int, 2, coupon.NumberOfCoupons);
                AddSQLParameter("@BottomAdvertisement", SqlDbType.VarChar, 255, coupon.BottomAdvertisement);
                AddSQLParameter("@Deleted", SqlDbType.Bit, 2, coupon.Deleted);
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
                                Barcode1Enabled={19},
                                Barcode1TypeID={20},
                                Barcode1Value={21},
                                Barcode2Enabled={22},
                                Barcode2TypeID={23},
                                Barcode2Value={24},
                                NumberOfCoupons={25},
                                BottomAdvertisement={26},
                                CreatedDate={27},
                                UpdatedDate={28},
                                Deleted={29}",
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
                                coupon.Barcode1Enabled,
                                coupon.Barcode1TypeID,
                                coupon.Barcode1Value,
                                coupon.Barcode2Enabled,
                                coupon.Barcode2TypeID,
                                coupon.Barcode2Value,
                                coupon.NumberOfCoupons,
                                coupon.BottomAdvertisement,
                                coupon.CreatedDate,
                                coupon.UpdatedDate,
                                coupon.Deleted
                                );
            try
            {


                AddSQLParameter("@MerchantID", SqlDbType.BigInt, 6, coupon.MerchantID);
                AddSQLParameter("@TemplateID", SqlDbType.BigInt, 6, coupon.TemplateID);
                AddSQLParameter("@CategoryID", SqlDbType.BigInt, 6, coupon.CategoryID);
                AddSQLParameter("@Image", SqlDbType.Image, 8000, coupon.Image);
                AddSQLParameter("@Value", SqlDbType.VarChar, 50, coupon.Value);
                AddSQLParameter("@Discount", SqlDbType.VarChar, 255, coupon.Discount);
                AddSQLParameter("@Details", SqlDbType.VarChar, 255, coupon.Details);
                AddSQLParameter("@Terms", SqlDbType.VarChar, 255, coupon.Terms);
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
                AddSQLParameter("@Barcode1Enabled", SqlDbType.Bit, 2, coupon.Barcode1Enabled);
                AddSQLParameter("@Barcode1TypeID", SqlDbType.BigInt, 6, coupon.Barcode1TypeID);
                AddSQLParameter("@Barcode1Value", SqlDbType.VarChar, 50, coupon.Barcode1Value);
                AddSQLParameter("@Barcode2Enabled", SqlDbType.Bit, 2, coupon.Barcode2Enabled);
                AddSQLParameter("@Barcode2TypeID", SqlDbType.BigInt, 6, coupon.Barcode2TypeID);
                AddSQLParameter("@Barcode2Value", SqlDbType.VarChar, 50, coupon.Barcode2Value);
                AddSQLParameter("@NumberOfCoupons", SqlDbType.Int, 2, coupon.NumberOfCoupons);
                AddSQLParameter("@BottomAdvertisement", SqlDbType.VarChar, 255, coupon.BottomAdvertisement);
                AddSQLParameter("@Deleted", SqlDbType.Bit, 2, coupon.Deleted);
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
