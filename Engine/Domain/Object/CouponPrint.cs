using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine.Domain.Object
{
    public class CouponPrint
    {
        public Int64 ID { get; set; }
        public String Name { get; set; }
        public Int64 CouponID { get; set; }
        public DateTime PrintedDate { get; set; }
        public String IPAddress { get; set; }
        public Int32 TotalPrints { get; set; }
    }
}
