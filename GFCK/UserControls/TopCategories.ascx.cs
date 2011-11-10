using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GFCK.UserControls
{
    public partial class TopCategories : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["c"] != null)
            {
                int _categoryID = Convert.ToInt32(Request.QueryString["c"]);
                switch (_categoryID){
                    case 1:
                        liItem1.Attributes.Add("class", "active");
                        break;
                    case 2:
                        liItem2.Attributes.Add("class", "active");
                        break;
                    case 3:
                        liItem3.Attributes.Add("class", "active");
                        break;
                    case 4:
                        liItem4.Attributes.Add("class", "active");
                        break;
                    case 5:
                        liItem5.Attributes.Add("class", "active");
                        break;
                    case 6:
                        liItem6.Attributes.Add("class", "active");
                        break;
                    case 7:
                        liItem7.Attributes.Add("class", "active");
                        break;
                }
            }


        }
    }
}