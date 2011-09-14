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
                    merchant.FirstName = Convert.ToString(row["FirstName"]);
                    merchant.LastName = Convert.ToString(row["LastName"]);
                    merchant.MerchantName = Convert.ToString(row["MerchantName"]);
                    merchant.Description = Convert.ToString(row["Description"]);
                    merchant.Email = Convert.ToString(row["Email"]);
                    merchant.PhoneNumber = Convert.ToString(row["PhoneNumber"]);
                    merchant.Address = Convert.ToString(row["Address"]);
                    merchant.CreatedDate = Convert.ToDateTime(row["CreatedDate"]);
                    merchant.UpdatedDate = Convert.ToDateTime(row["UpdatedDate"]);
                    merchant.Enabled = Convert.ToBoolean(row["Enabled"]);
                }

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex);
            }

            return merchant;
        }

        public List<Merchant> GetAllActiveMerchants()
        {
            List<Merchant> merchants = null;
            _log.DebugFormat("dbo.GetAllActiveMerchants");
            try
            {   
                
                Merchant merchant = new Merchant();
                merchants = new List<Merchant>();
                DataSet ds = GetDatasetByCommand("dbo.GetAllActiveMerchants");
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    merchant.ID = Convert.ToInt64(row["ID"]);
                    merchant.FirstName = Convert.ToString(row["FirstName"]);
                    merchant.LastName = Convert.ToString(row["LastName"]);
                    merchant.MerchantName = Convert.ToString(row["MerchantName"]);
                    merchant.Description = Convert.ToString(row["Description"]);
                    merchant.Email = Convert.ToString(row["Email"]);
                    merchant.PhoneNumber = Convert.ToString(row["PhoneNumber"]);
                    merchant.Address = Convert.ToString(row["Address"]);
                    merchant.CreatedDate = row["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(row["CreatedDate"]) : DateTime.MinValue;
                    merchant.UpdatedDate = row["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedDate"]) : DateTime.MinValue;
                    merchant.Enabled = Convert.ToBoolean(row["Enabled"]);
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
                            Enabled={9}",
                             merchant.ID,
                             merchant.FirstName,
                             merchant.LastName,
                             merchant.Description,
                             merchant.Email,
                             merchant.PhoneNumber,
                             merchant.Address,
                             merchant.CreatedDate,
                             merchant.UpdatedDate,
                             merchant.Enabled,
                             merchant.MerchantName

                             );
            try
            {
                merchant = new Merchant();
                AddSQLParameter("@MerchantID", SqlDbType.BigInt, 6, merchant.ID);
                AddSQLParameter("@FirstName", SqlDbType.VarChar, 50, merchant.FirstName);
                AddSQLParameter("@LastName", SqlDbType.VarChar, 50, merchant.LastName);
                AddSQLParameter("@MerchantName", SqlDbType.VarChar, 50, merchant.MerchantName);
                AddSQLParameter("@Description", SqlDbType.VarChar, -1, merchant.Description);
                AddSQLParameter("@Email", SqlDbType.VarChar, 50, merchant.Email);
                AddSQLParameter("@PhoneNumber", SqlDbType.VarChar, 50, merchant.PhoneNumber);
                AddSQLParameter("@Address", SqlDbType.VarChar, 255, merchant.Address);
                AddSQLParameter("@Enabled", SqlDbType.Bit, 2, merchant.Enabled);
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
                            FirstName{1},
                            LastName{2},
                            MerchantName={10}
                            Description={3},
                            Email={4},
                            PhoneNumber={5},
                            Address={6},
                            CreatedDate={7},
                            UpdatedDate={8},
                            Enabled={9}",
                             merchant.ID,
                             merchant.FirstName,
                             merchant.LastName,
                             merchant.Description,
                             merchant.Email,
                             merchant.PhoneNumber,
                             merchant.Address,
                             merchant.CreatedDate,
                             merchant.UpdatedDate,
                             merchant.Enabled,
                             merchant.MerchantName
                             );
            try
            {
                merchant = new Merchant();
                AddSQLParameter("@FirstName", SqlDbType.VarChar, 50, merchant.FirstName);
                AddSQLParameter("@LastName", SqlDbType.VarChar, 50, merchant.LastName);
                AddSQLParameter("@MerchantName", SqlDbType.VarChar, 50, merchant.MerchantName);
                AddSQLParameter("@Description", SqlDbType.VarChar, -1, merchant.Description);
                AddSQLParameter("@Email", SqlDbType.VarChar, 50, merchant.Email);
                AddSQLParameter("@PhoneNumber", SqlDbType.VarChar, 50, merchant.PhoneNumber);
                AddSQLParameter("@Address", SqlDbType.VarChar, 255, merchant.Address);
                AddSQLParameter("@Enabled", SqlDbType.Bit, 2, merchant.Enabled);
                GetExecuteNonQueryByCommand("dbo.AddMerchant");
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
