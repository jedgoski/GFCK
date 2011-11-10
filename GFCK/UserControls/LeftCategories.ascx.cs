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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string filter = (Session["filter"] == null) ? "" : Session["filter"].ToString();
                if (filter != "")
                {
                    char[] filterValues = filter.ToCharArray();
                    chkGF.Checked = (filterValues[0] == '1') ? true : false;
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
            filter = ApplyFilter(filter, chkGF.Checked, 0);
            filter = ApplyFilter(filter, chkCDF.Checked, 1);
            filter = ApplyFilter(filter, chkSF.Checked, 2);
            filter = ApplyFilter(filter, chkCF.Checked, 3);
            filter = ApplyFilter(filter, chkEF.Checked, 4);
            filter = ApplyFilter(filter, chkNF.Checked, 5);
            filter = ApplyFilter(filter, chkYF.Checked, 6);

            Session["filter"] = filter;
            Response.Redirect("/default.aspx");
        }

        private string ApplyFilter(string str, bool val, int place)
        {
            char[] vals = str.ToCharArray();
            vals[place] = val ? '1' : '0';
            return new string(vals);
        }
    }
}