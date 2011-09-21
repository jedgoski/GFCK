using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Util;
using log4net;
using Engine.Domain.Object;
using System.Data;
using Engine.DAO.Domain;

namespace Engine.DAO.Object
{
   public class CategoryDAO: SqlDataHelper, ICategoryDAO
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(CategoryDAO));
        public string _connectionString;
        public CategoryDAO(string connectionString) : base(connectionString)
        {   
              _connectionString = connectionString;
        }

        public List<Category> GetAllActiveCategories()
        {
            List<Category> categories = null;
            _log.DebugFormat("dbo.GetAllActiveCategories");
            try
            {

                Category category = new Category();
                categories = new List<Category>();
                DataSet ds = GetDatasetByCommand("dbo.GetAllActiveCategories");
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    category.ID = Convert.ToInt64(row["ID"]);
                    category.Name = Convert.ToString(row["Name"]);
                    categories.Add(category);
                }

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex);
            }

            return categories;
        }

    }
}
