using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Engine.DAO.Domain;

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
            _connectionString = ConfigurationManager.ConnectionStrings["GFCK"].ConnectionString;
        }

        public IMerchantDAO GetMerchantDAO()
        {
            return new MerchantDAO(_connectionString);
        }

        public ICategoryDAO GetCategoryDAO()
        {
            return new CategoryDAO(_connectionString);
        }

        public IBarcodeDAO GetBarcodeDAO()
        {
            return new BarcodeDAO(_connectionString);
        }

        public ICouponDAO GetCouponDAO()
        {
            return new CouponDAO(_connectionString);
        }

        public ITemplateDAO GetTemplateDAO()
        {
            return new TemplateDAO(_connectionString);
        }

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
