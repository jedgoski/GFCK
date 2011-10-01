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
    }
}