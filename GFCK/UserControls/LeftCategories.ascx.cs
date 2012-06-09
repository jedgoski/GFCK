using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GFCK.UserControls
{
    public partial class LeftCategories : System.Web.UI.UserControl
    {
        public bool Admin = false;
        public bool Manufacturer = false;
        int _categoryID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            categories.Visible = true;
            if (Request.QueryString["c"] != null)
            {
                _categoryID = Convert.ToInt32(Request.QueryString["c"]);
                if (_categoryID == 5)
                {
                    //don't display for restaurants(5)
                    categories.Visible = false;
                }
            }

            if (!IsPostBack)
            {
                string filter = (Session["filter"] == null) ? "" : Session["filter"].ToString();
                if (filter != "")
                {
                    char[] filterValues = filter.ToCharArray();
                    //chkGF.Checked = (filterValues[0] == '1') ? true : false;
                    chkCDF.Checked = (filterValues[1] == '1') ? true : false;
                    chkSF.Checked = (filterValues[2] == '1') ? true : false;
                    chkCF.Checked = (filterValues[3] == '1') ? true : false;
                    chkEF.Checked = (filterValues[4] == '1') ? true : false;
                    chkNF.Checked = (filterValues[5] == '1') ? true : false;
                    chkYF.Checked = (filterValues[6] == '1') ? true : false;
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            CheckAdmin();
        }

        protected void CheckAdmin()
        {
            categories.Visible = false;
            manufacturerCategories.Visible = false;
            adminCategories.Visible = false;

            if (Admin)
            {
                adminCategories.Visible = true;
            }
            else if (Manufacturer)
            {
                manufacturerCategories.Visible = true;
            }
            else
            {
                categories.Visible = true;
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string filter = "0000000";
            filter = ApplyFilter(filter, true, 0);
            filter = ApplyFilter(filter, chkCDF.Checked, 1);
            filter = ApplyFilter(filter, chkSF.Checked, 2);
            filter = ApplyFilter(filter, chkCF.Checked, 3);
            filter = ApplyFilter(filter, chkEF.Checked, 4);
            filter = ApplyFilter(filter, chkNF.Checked, 5);
            filter = ApplyFilter(filter, chkYF.Checked, 6);

            Session["filter"] = filter;
            string url = (_categoryID > 0) ? String.Format("/default.aspx?c={0}", _categoryID.ToString()) : "/default.aspx";
            Response.Redirect(url);
        }

        private string ApplyFilter(string str, bool val, int place)
        {
            char[] vals = str.ToCharArray();
            vals[place] = val ? '1' : '0';
            return new string(vals);
        }
    }
}