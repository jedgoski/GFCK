using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using Engine.Util;
using Engine.DAO.Domain;
using Engine.Domain.Object;
using System.Data;

namespace Engine.DAO.Object
{
    public class TemplateDAO : SqlDataHelper, ITemplateDAO
    {
        public static readonly ILog _log = LogManager.GetLogger(typeof(TemplateDAO));
        public string _connectionString;
        public TemplateDAO(string connectionString) : base(connectionString)
        {   
              _connectionString = connectionString;
        }


        public List<Template> GetAllActiveTemplates()
        {
            List<Template> templates = null;
            _log.DebugFormat("dbo.GetAllActiveTemplates");
            try
            {

                
                templates = new List<Template>();
                DataSet ds = GetDatasetByCommand("dbo.GetAllActiveTemplates");
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    Template template = new Template();
                    template.ID = Convert.ToInt64(row["ID"]);
                    template.Name = Convert.ToString(row["Name"]);
                    template.Deleted = Convert.ToBoolean(row["Deleted"]);
                    templates.Add(template);
                }

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Exception Occured: Exception={0}", ex);
            }

            return templates;
        }
    }
}
