using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.DAO.Domain;
using Engine.Domain.Object;
using System.Data.SqlClient;
using log4net;
using System.Data;
using Engine.Util;

namespace Engine.DAO.Object
{
    public class MerchantDAO : SqlDataHelper, IMerchantDAO
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(MerchantDAO));
        public string _connectionString;

        public MerchantDAO(string connectionString): base(connectionString)
        {   
              _connectionString = connectionString;
        }

        public Merchant GetMerchant(Int64 ID)
        {
            Merchant merchant = null;
            _log.DebugFormat("dbo.GetMerchant: MerchantID={0}", ID);
            try
            {
                merchant = new Merchant();
                AddSQLParameter("@MerchantID", SqlDbType.BigInt, 6, ID);
                DataSet ds = GetDatasetByCommand("dbo.GetMerchant");
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    merchant.ID = Convert.ToInt64(row["ID"]);
                    merchant.UserID = (Guid)row["UserID"];
                    merchant.MerchantName = (row["MerchantName"] == DBNull.Value) ? "" : Convert.ToString(row["MerchantName"]);
                    merchant.UserName = Convert.ToString(row["UserName"]);

                    merchant.FirstName = (row["FirstName"] == DBNull.Value) ? "" : Convert.ToString(row["FirstName"]);
                    merchant.LastName = (row["LastName"] == DBNull.Value) ? "" : Convert.ToString(row["LastName"]);
                    merchant.Email = (row["Email"] == DBNull.Value) ? "" : Convert.ToString(row["Email"]);
                    merchant.PhoneNumber = (row["PhoneNumber"] == DBNull.Value) ? "" : Convert.ToString(row["PhoneNumber"]);
                    merchant.Description = (row["Description"] == DBNull.Value) ? "" : Convert.ToString(row["Description"]);

                    merchant.FirstNameBilling = (row["FirstNameBilling"] == DBNull.Value) ? "" : Convert.ToString(row["FirstNameBilling"]);
                    merchant.LastNameBilling = (row["LastNameBilling"] == DBNull.Value) ? "" : Convert.ToString(row["LastNameBilling"]);
                    merchant.EmailBilling = (row["EmailBilling"] == DBNull.Value) ? "" : Convert.ToString(row["EmailBilling"]);
                    merchant.PhoneNumberBilling = (row["PhoneNumberBilling"] == DBNull.Value) ? "" : Convert.ToString(row["PhoneNumberBilling"]);
                    merchant.DescriptionBilling = (row["DescriptionBilling"] == DBNull.Value) ? "" : Convert.ToString(row["DescriptionBilling"]);
                    merchant.Address = (row["Address"] == DBNull.Value) ? "" : Convert.ToString(row["Address"]);
                    merchant.Address2 = (row["Address2"] == DBNull.Value) ? "" : Convert.ToString(row["Address2"]);
                    merchant.City = (row["City"] == DBNull.Value) ? "" : Convert.ToString(row["City"]);
                    merchant.State = (row["State"] == DBNull.Value) ? "" : Convert.ToString(row["State"]);
                    merchant.Zip = (row["Zip"] == DBNull.Value) ? "" : Convert.ToString(row["Zip"]);

                    merchant.CreatedDate = (row["CreatedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["CreatedDate"]);
                    merchant.UpdatedDate = (row["UpdatedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["UpdatedDate"]);
                    merchant.Deleted = Convert.ToBoolean(row["Deleted"]);
                }

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex);
            }

            return merchant;
        }

        public Merchant GetMerchantByUserID(Guid userID)
        {
            Merchant merchant = null;
            _log.DebugFormat("dbo.GetMerchantByUserID: userID={0}", userID);
            try
            {
                merchant = new Merchant();
                AddSQLParameter("@UserID", SqlDbType.UniqueIdentifier, userID);
                DataSet ds = GetDatasetByCommand("dbo.GetMerchantByUserID");
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    merchant.ID = Convert.ToInt64(row["ID"]);
                    merchant.UserID = (Guid)row["UserID"];
                    merchant.MerchantName = (row["MerchantName"] == DBNull.Value) ? "" : Convert.ToString(row["MerchantName"]);
                    merchant.UserName = Convert.ToString(row["UserName"]);

                    merchant.FirstName = (row["FirstName"] == DBNull.Value) ? "" : Convert.ToString(row["FirstName"]);
                    merchant.LastName = (row["LastName"] == DBNull.Value) ? "" : Convert.ToString(row["LastName"]);
                    merchant.Email = (row["Email"] == DBNull.Value) ? "" : Convert.ToString(row["Email"]);
                    merchant.PhoneNumber = (row["PhoneNumber"] == DBNull.Value) ? "" : Convert.ToString(row["PhoneNumber"]);
                    merchant.Description = (row["Description"] == DBNull.Value) ? "" : Convert.ToString(row["Description"]);

                    merchant.FirstNameBilling = (row["FirstNameBilling"] == DBNull.Value) ? "" : Convert.ToString(row["FirstNameBilling"]);
                    merchant.LastNameBilling = (row["LastNameBilling"] == DBNull.Value) ? "" : Convert.ToString(row["LastNameBilling"]);
                    merchant.EmailBilling = (row["EmailBilling"] == DBNull.Value) ? "" : Convert.ToString(row["EmailBilling"]);
                    merchant.PhoneNumberBilling = (row["PhoneNumberBilling"] == DBNull.Value) ? "" : Convert.ToString(row["PhoneNumberBilling"]);
                    merchant.DescriptionBilling = (row["DescriptionBilling"] == DBNull.Value) ? "" : Convert.ToString(row["DescriptionBilling"]);
                    merchant.Address = (row["Address"] == DBNull.Value) ? "" : Convert.ToString(row["Address"]);
                    merchant.Address2 = (row["Address2"] == DBNull.Value) ? "" : Convert.ToString(row["Address2"]);
                    merchant.City = (row["City"] == DBNull.Value) ? "" : Convert.ToString(row["City"]);
                    merchant.State = (row["State"] == DBNull.Value) ? "" : Convert.ToString(row["State"]);
                    merchant.Zip = (row["Zip"] == DBNull.Value) ? "" : Convert.ToString(row["Zip"]);

                    merchant.CreatedDate = (row["CreatedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["CreatedDate"]);
                    merchant.UpdatedDate = (row["UpdatedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["UpdatedDate"]);
                    merchant.Deleted = Convert.ToBoolean(row["Deleted"]);
                }

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex);
            }

            return merchant;
        }
        
        public List<Merchant> GetMerchantsByFilter(int deleted)
        {
            List<Merchant> merchants = null;
            _log.DebugFormat("dbo.GetAllMerchants: deleted={0}", deleted);
            try
            {
                int? bitDeleted = null;
                if (deleted > -1) bitDeleted = deleted;
                AddSQLParameter("@Deleted", SqlDbType.Bit, bitDeleted);
                merchants = new List<Merchant>();
                DataSet ds = GetDatasetByCommand("dbo.GetAllMerchants");
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    Merchant merchant = new Merchant();
                    merchant.ID = Convert.ToInt64(row["ID"]);
                    merchant.UserID = (Guid)row["UserID"];
                    merchant.MerchantName = (row["MerchantName"] == DBNull.Value) ? "" : Convert.ToString(row["MerchantName"]);

                    merchant.FirstName = (row["FirstName"] == DBNull.Value) ? "" : Convert.ToString(row["FirstName"]);
                    merchant.LastName = (row["LastName"] == DBNull.Value) ? "" : Convert.ToString(row["LastName"]);
                    merchant.Email = (row["Email"] == DBNull.Value) ? "" : Convert.ToString(row["Email"]);
                    merchant.PhoneNumber = (row["PhoneNumber"] == DBNull.Value) ? "" : Convert.ToString(row["PhoneNumber"]);
                    merchant.Description = (row["Description"] == DBNull.Value) ? "" : Convert.ToString(row["Description"]);

                    merchant.FirstNameBilling = (row["FirstNameBilling"] == DBNull.Value) ? "" : Convert.ToString(row["FirstNameBilling"]);
                    merchant.LastNameBilling = (row["LastNameBilling"] == DBNull.Value) ? "" : Convert.ToString(row["LastNameBilling"]);
                    merchant.EmailBilling = (row["EmailBilling"] == DBNull.Value) ? "" : Convert.ToString(row["EmailBilling"]);
                    merchant.PhoneNumberBilling = (row["PhoneNumberBilling"] == DBNull.Value) ? "" : Convert.ToString(row["PhoneNumberBilling"]);
                    merchant.DescriptionBilling = (row["DescriptionBilling"] == DBNull.Value) ? "" : Convert.ToString(row["DescriptionBilling"]);
                    merchant.Address = (row["Address"] == DBNull.Value) ? "" : Convert.ToString(row["Address"]);
                    merchant.Address2 = (row["Address2"] == DBNull.Value) ? "" : Convert.ToString(row["Address2"]);
                    merchant.City = (row["City"] == DBNull.Value) ? "" : Convert.ToString(row["City"]);
                    merchant.State = (row["State"] == DBNull.Value) ? "" : Convert.ToString(row["State"]);
                    merchant.Zip = (row["Zip"] == DBNull.Value) ? "" : Convert.ToString(row["Zip"]);

                    merchant.CreatedDate = (row["CreatedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["CreatedDate"]);
                    merchant.UpdatedDate = (row["UpdatedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["UpdatedDate"]);
                    merchant.Deleted = Convert.ToBoolean(row["Deleted"]);
                    merchants.Add(merchant);
                }

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex);
            }

            return merchants;
        }
        
        public List<Merchant> GetAllActiveMerchants()
        {
            List<Merchant> merchants = null;
            _log.DebugFormat("dbo.GetAllActiveMerchants");
            try
            {

                
                merchants = new List<Merchant>();
                DataSet ds = GetDatasetByCommand("dbo.GetAllActiveMerchants");
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    Merchant merchant = new Merchant();
                    merchant.ID = Convert.ToInt64(row["ID"]);
                    merchant.UserID = (Guid)row["UserID"];
                    merchant.MerchantName = (row["MerchantName"] == DBNull.Value) ? "" : Convert.ToString(row["MerchantName"]);

                    merchant.FirstName = (row["FirstName"] == DBNull.Value) ? "" : Convert.ToString(row["FirstName"]);
                    merchant.LastName = (row["LastName"] == DBNull.Value) ? "" : Convert.ToString(row["LastName"]);
                    merchant.Email = (row["Email"] == DBNull.Value) ? "" : Convert.ToString(row["Email"]);
                    merchant.PhoneNumber = (row["PhoneNumber"] == DBNull.Value) ? "" : Convert.ToString(row["PhoneNumber"]);
                    merchant.Description = (row["Description"] == DBNull.Value) ? "" : Convert.ToString(row["Description"]);

                    merchant.FirstNameBilling = (row["FirstNameBilling"] == DBNull.Value) ? "" : Convert.ToString(row["FirstNameBilling"]);
                    merchant.LastNameBilling = (row["LastNameBilling"] == DBNull.Value) ? "" : Convert.ToString(row["LastNameBilling"]);
                    merchant.EmailBilling = (row["EmailBilling"] == DBNull.Value) ? "" : Convert.ToString(row["EmailBilling"]);
                    merchant.PhoneNumberBilling = (row["PhoneNumberBilling"] == DBNull.Value) ? "" : Convert.ToString(row["PhoneNumberBilling"]);
                    merchant.DescriptionBilling = (row["DescriptionBilling"] == DBNull.Value) ? "" : Convert.ToString(row["DescriptionBilling"]);
                    merchant.Address = (row["Address"] == DBNull.Value) ? "" : Convert.ToString(row["Address"]);
                    merchant.Address2 = (row["Address2"] == DBNull.Value) ? "" : Convert.ToString(row["Address2"]);
                    merchant.City = (row["City"] == DBNull.Value) ? "" : Convert.ToString(row["City"]);
                    merchant.State = (row["State"] == DBNull.Value) ? "" : Convert.ToString(row["State"]);
                    merchant.Zip = (row["Zip"] == DBNull.Value) ? "" : Convert.ToString(row["Zip"]);

                    merchant.CreatedDate = (row["CreatedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["CreatedDate"]);
                    merchant.UpdatedDate = (row["UpdatedDate"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(row["UpdatedDate"]);
                    merchant.Deleted = Convert.ToBoolean(row["Deleted"]);
                    merchants.Add(merchant);
                }

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex);
            }

            return merchants;
        }

        public bool UpdateMerchant(Merchant merchant)
        {
            bool success = false;
            _log.DebugFormat(@"dbo.UpdateMerchant: ID={0},
                            FirstName={1},
                            LastName={2},
                            MerchantName={10},
                            Description={3},
                            Email={4},
                            PhoneNumber={5},
                            Address={6},
                            CreatedDate={7},
                            UpdatedDate={8},
                            Deleted={9}",
                             merchant.ID,
                             merchant.FirstName,
                             merchant.LastName,
                             merchant.Description,
                             merchant.Email,
                             merchant.PhoneNumber,
                             merchant.Address,
                             merchant.CreatedDate,
                             merchant.UpdatedDate,
                             merchant.Deleted,
                             merchant.MerchantName

                             );
            try
            {
                AddSQLParameter("@ID", SqlDbType.BigInt, merchant.ID);
                AddSQLParameter("@MerchantName", SqlDbType.NVarChar, merchant.MerchantName);

                AddSQLParameter("@FirstName", SqlDbType.NVarChar, merchant.FirstName);
                AddSQLParameter("@LastName", SqlDbType.NVarChar, merchant.LastName);
                AddSQLParameter("@Email", SqlDbType.NVarChar, merchant.Email);
                AddSQLParameter("@PhoneNumber", SqlDbType.NVarChar, merchant.PhoneNumber);
                AddSQLParameter("@Description", SqlDbType.NVarChar, merchant.Description);

                AddSQLParameter("@FirstNameBilling", SqlDbType.NVarChar, merchant.FirstNameBilling);
                AddSQLParameter("@LastNameBilling", SqlDbType.NVarChar, merchant.LastNameBilling);
                AddSQLParameter("@EmailBilling", SqlDbType.NVarChar, merchant.EmailBilling);
                AddSQLParameter("@PhoneNumberBilling", SqlDbType.NVarChar, merchant.PhoneNumberBilling);
                AddSQLParameter("@DescriptionBilling", SqlDbType.NVarChar, merchant.DescriptionBilling);
                AddSQLParameter("@Address", SqlDbType.NVarChar, merchant.Address);
                AddSQLParameter("@Address2", SqlDbType.NVarChar, merchant.Address2);
                AddSQLParameter("@City", SqlDbType.NVarChar, merchant.City);
                AddSQLParameter("@State", SqlDbType.NVarChar, merchant.State);
                AddSQLParameter("@Zip", SqlDbType.NVarChar, merchant.Zip);

                AddSQLParameter("@Deleted", SqlDbType.Bit, merchant.Deleted);
                GetExecuteNonQueryByCommand("dbo.UpdateMerchant");
                success = true;
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex);
            }

            return success;
        }

        public bool AddMerchant(Merchant merchant)
        {
            bool success = false;
            _log.DebugFormat(@"dbo.AddMerchant: ID={0},
                            UserID={1},
                            FirstName{2},
                            LastName{3},
                            MerchantName={4}
                            Description={5},
                            Email={6},
                            PhoneNumber={7},
                            Address={8},
                            CreatedDate={9},
                            UpdatedDate={10},
                            Deleted={11}",
                             merchant.ID,
                             merchant.UserID,
                             merchant.FirstName,
                             merchant.LastName,
                             merchant.Description,
                             merchant.Email,
                             merchant.PhoneNumber,
                             merchant.Address,
                             merchant.CreatedDate,
                             merchant.UpdatedDate,
                             merchant.Deleted,
                             merchant.MerchantName
                             );
            try
            {
                AddSQLParameter("@UserID", SqlDbType.UniqueIdentifier, merchant.UserID);
                AddSQLParameter("@MerchantName", SqlDbType.NVarChar, merchant.MerchantName);

                AddSQLParameter("@FirstName", SqlDbType.NVarChar, merchant.FirstName);
                AddSQLParameter("@LastName", SqlDbType.NVarChar, merchant.LastName);
                AddSQLParameter("@Email", SqlDbType.NVarChar, merchant.Email);
                AddSQLParameter("@PhoneNumber", SqlDbType.NVarChar, merchant.PhoneNumber);
                AddSQLParameter("@Description", SqlDbType.NVarChar, merchant.Description);

                AddSQLParameter("@FirstNameBilling", SqlDbType.NVarChar, merchant.FirstNameBilling);
                AddSQLParameter("@LastNameBilling", SqlDbType.NVarChar, merchant.LastNameBilling);
                AddSQLParameter("@EmailBilling", SqlDbType.NVarChar, merchant.EmailBilling);
                AddSQLParameter("@PhoneNumberBilling", SqlDbType.NVarChar, merchant.PhoneNumberBilling);
                AddSQLParameter("@DescriptionBilling", SqlDbType.NVarChar, merchant.DescriptionBilling);
                AddSQLParameter("@Address", SqlDbType.NVarChar, merchant.Address);
                AddSQLParameter("@Address2", SqlDbType.NVarChar, merchant.Address2);
                AddSQLParameter("@City", SqlDbType.NVarChar, merchant.City);
                AddSQLParameter("@State", SqlDbType.NVarChar, merchant.State);
                AddSQLParameter("@Zip", SqlDbType.NVarChar, merchant.Zip);

                AddSQLParameter("@Deleted", SqlDbType.Bit, merchant.Deleted);
                GetExecuteNonQueryByCommand("dbo.AddMerchant");
                success = true;
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex);
            }

            return success;
        }

        public bool AddUserToMerchant(Guid userID, long merchantID)
        {
            bool success = false;
            _log.DebugFormat(@"dbo.AddUserToMerchant: UserID={1},
                            merchantID{2}",
                             userID,
                             merchantID
                             );
            try
            {
                AddSQLParameter("@UserID", SqlDbType.UniqueIdentifier, userID);
                AddSQLParameter("@MerchantID", SqlDbType.BigInt, merchantID);
                GetExecuteNonQueryByCommand("dbo.AddUserToMerchant");
                success = true;
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex);
            }

            return success;
        }

    }
}
