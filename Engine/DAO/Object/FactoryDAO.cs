using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Engine.DAO.Object
{
    public sealed class FactoryDAO
    {
        private string _connectionString = string.Empty;

        public FactoryDAO(string conn)
        {
            _connectionString = conn;
        }

        public FactoryDAO()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["GFC"].ConnectionString;
        }

        //public ISSODAO GetSSODAO()
        //{
        //    return new SSODAO(_connectionString);
        //}

        public static FactoryDAO GetInstance()
        {
            return Nested.instance;
        }

        class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly FactoryDAO instance = new FactoryDAO();
        }
    }
}
