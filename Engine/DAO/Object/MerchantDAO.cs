using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.DAO.Domain;
using log4net;

namespace Engine.DAO.Object
{
    public class MerchantDAO : IMerchantDAO
    {
        //TODO: Need to get log4net up
        public static readonly ILog _log = LogManager.GetLogger(typeof(MerchantDAO));
        //public ManufacturerDAO(string connectionString): base(connectionString)
        //{
        //    ConnectionString = connectionString;
        //}

        
    }
}
