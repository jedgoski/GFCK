using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
<<<<<<< HEAD
=======
using Engine.DAO.Object;
using Engine.DAO.Domain;
using Engine.Domain.Object;
using log4net;
>>>>>>> 0f2f6634e624608d4c66ca22cefa4f3132adc8a5

namespace GFCK.UserControls
{
    public partial class RightCallout : System.Web.UI.UserControl
    {
<<<<<<< HEAD
        protected void Page_Load(object sender, EventArgs e)
=======
        public static readonly ILog _log = LogManager.GetLogger(typeof(RightCallout));
        FactoryDAO _factoryDAO = FactoryDAO.GetInstance();
        protected override void OnInit(EventArgs e)
>>>>>>> 0f2f6634e624608d4c66ca22cefa4f3132adc8a5
        {

        }
    }
}