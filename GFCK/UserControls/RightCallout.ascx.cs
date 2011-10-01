using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GFCK.UserControls
{
    public partial class RightCallout : System.Web.UI.UserControl
    {
        public bool Admin = false;

        protected override void OnInit(EventArgs e)
        {
            CheckAdmin();
            base.OnInit(e);
        }

        protected void CheckAdmin()
        {
            if (Admin)
            {
                manufacturers.Visible = true;
                information.Visible = false;
            }
            else
            {
                manufacturers.Visible = false;
                information.Visible = true;
            }
        }

    }
}