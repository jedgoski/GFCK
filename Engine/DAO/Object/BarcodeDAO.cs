using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Domain.Object;
using Engine.Util;
using Engine.DAO.Domain;
using log4net;
using System.Data;

namespace Engine.DAO.Object
{
    public class BarcodeDAO : SqlDataHelper, IBarcodeDAO
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(BarcodeDAO));
        public string _connectionString;
        public BarcodeDAO(string connectionString)
            : base(connectionString)
        {
            _connectionString = connectionString;
        }

        public List<BarcodeType> GetAllActiveBarcodeTypes()
        {
            List<BarcodeType> barcodeTypes = null;
            _log.DebugFormat("dbo.GetAllActiveBarcodeTypes");
            try
            {
                BarcodeType barcodeType = new BarcodeType();
                barcodeTypes = new List<BarcodeType>();
                DataSet ds = GetDatasetByCommand("dbo.GetAllActiveBarcodeTypes");
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    barcodeType.ID = Convert.ToInt64(row["ID"]);
                    barcodeType.Name = Convert.ToString(row["Name"]);
                    barcodeType.Enabled = Convert.ToBoolean(row["Enabled"]);
                    barcodeTypes.Add(barcodeType);
                }

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex);
            }

            return barcodeTypes;
        }
    }
        
}
